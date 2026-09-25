using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] CharacterController controller;
    [SerializeField] float speed = 5f;
    [SerializeField] float rotationSpeed = 10f;

    private float rotationSmoothVelocity;
    private Vector3 velocity;
    private Vector3 currentMove = Vector3.zero;

    [Header("Jump")]
    [SerializeField] float jumpHeight = 2f;

    [Header("Ground Check")]
    [SerializeField] Transform groundCheck;
    [SerializeField] float sensorRadius = 0.4f;
    [SerializeField] LayerMask groundMask;

    private bool isRunning = false;

    [Header("Animation")]
    public Animator currentAnimator;

    private float smoothVelocity = 0f;
    private float velocitySmoothTime = 0.25f;
    private float velocitySmoothSpeed = 0f;

    private bool jumpAnimation = false;
    private bool myIsGrounded = false;

    [Header("Input")]
    private PlayerControls PlayerControls;
    private Vector2 CurrentMovement;
    private bool MovementPressed;

    private void OnEnable()
    {
        if (PlayerControls != null)
            PlayerControls.Player.Enable();
    }

    private void OnDisable()
    {
        if (PlayerControls != null)
            PlayerControls.Player.Disable();
    }

    private void Awake()
    {
        Time.timeScale = 1f;

        PlayerControls = new PlayerControls();

        // Movement
        PlayerControls.Player.Move.performed += ctx =>
        {
            CurrentMovement = ctx.ReadValue<Vector2>();

            MovementPressed =
                CurrentMovement.x != 0 ||
                CurrentMovement.y != 0;
        };

        PlayerControls.Player.Move.canceled += ctx =>
        {
            CurrentMovement = Vector2.zero;
            MovementPressed = false;
        };

        // Jump
        PlayerControls.Player.Jump.performed += ctx =>
        {
            if (IsGrounded())
            {
                velocity.y = Mathf.Sqrt(
                    jumpHeight * -2f * Physics.gravity.y
                );

                if (currentAnimator != null)
                    currentAnimator.SetTrigger("IsJumping");
            }
        };
    }

    private void Start()
    {
        if (currentAnimator == null)
        {
            Animator[] animators =
                GetComponentsInChildren<Animator>(true);

            foreach (Animator anim in animators)
            {
                if (anim.gameObject.activeInHierarchy)
                {
                    currentAnimator = anim;
                    break;
                }
            }
        }
    }

    private void Update()
    {
        MoveCharacter();
        HandleJumpAnimation();
    }

    // =========================================================
    // MOVEMENT
    // =========================================================

    private void MoveCharacter()
    {
        myIsGrounded = false;

        float x = CurrentMovement.x;
        float z = -CurrentMovement.y;

        Vector3 moveInput =
            new Vector3(x, 0f, z);

        Vector3 moveDirection =
            ConvertToCameraSpace(moveInput);

        if (currentAnimator != null)
        {
            currentAnimator.SetBool(
                "IsWalking",
                moveInput.magnitude > 0.1f
            );
        }

        // Ground gravity
        if (IsGrounded() && velocity.y < 0f)
            velocity.y = -2f;

        // Gravity
        velocity.y +=
            Physics.gravity.y * Time.deltaTime;

        // Movement speed
        float moveSpeedMultiplier = 1f;

        Vector3 targetMove =
            moveDirection *
            speed *
            moveSpeedMultiplier;

        // Smooth movement
        currentMove = Vector3.Lerp(
            currentMove,
            targetMove,
            Time.deltaTime * 3f
        );

        // Combine horizontal movement + vertical velocity
        Vector3 finalMove =
            currentMove +
            new Vector3(0f, velocity.y, 0f);

        controller.Move(
            finalMove * Time.deltaTime
        );

        // Animation vertical velocity
        if (currentAnimator != null)
        {
            currentAnimator.SetFloat(
                "VerticalVelocity",
                controller.velocity.y
            );
        }

        // Smooth animation movement speed
        float rawVelocity =
            new Vector3(
                controller.velocity.x,
                0f,
                controller.velocity.z
            ).magnitude;

        smoothVelocity = Mathf.SmoothDamp(
            smoothVelocity,
            rawVelocity,
            ref velocitySmoothSpeed,
            velocitySmoothTime
        );

        if (currentAnimator != null)
        {
            currentAnimator.SetFloat(
                "Velocity",
                smoothVelocity
            );
        }

        // Rotate toward movement direction
        RotateCharacter(moveDirection);
    }

    // =========================================================
    // ROTATION
    // =========================================================

    private void RotateCharacter(Vector3 moveDirection)
    {
        if (moveDirection.sqrMagnitude <= 0.01f)
            return;

        float targetAngle =
            Mathf.Atan2(
                moveDirection.x,
                moveDirection.z
            ) * Mathf.Rad2Deg;

        float smoothAngle =
            Mathf.SmoothDampAngle(
                transform.eulerAngles.y,
                targetAngle,
                ref rotationSmoothVelocity,
                0.15f
            );

        transform.rotation =
            Quaternion.Euler(
                0f,
                smoothAngle,
                0f
            );
    }

    // =========================================================
    // CAMERA-RELATIVE MOVEMENT
    // =========================================================

    private Vector3 ConvertToCameraSpace(Vector3 input)
    {
        if (Camera.main == null)
            return input;

        Vector3 camForward =
            Camera.main.transform.forward;

        Vector3 camRight =
            Camera.main.transform.right;

        // Prevent camera tilt from affecting movement
        camForward.y = 0f;
        camRight.y = 0f;

        camForward.Normalize();
        camRight.Normalize();

        return
            camForward * input.z +
            camRight * input.x;
    }

    // =========================================================
    // JUMPING
    // =========================================================

    private void HandleJumpAnimation()
    {
        if (currentAnimator == null)
            return;

        if (!controller.isGrounded && !jumpAnimation)
        {
            currentAnimator.SetTrigger(
                "StartJumpFall"
            );

            jumpAnimation = true;
        }
        else if (controller.isGrounded)
        {
            jumpAnimation = false;
        }
    }

    private bool IsGrounded()
    {
        return
            controller.isGrounded ||
            myIsGrounded ||
            Physics.CheckSphere(
                groundCheck.position,
                sensorRadius,
                groundMask
            );
    }
}
