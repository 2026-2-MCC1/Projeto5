using UnityEngine;
public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] Transform groundCheck;
    [SerializeField] float groundRadius = 0.2f;
    [SerializeField] LayerMask groundLayer;

    Animator animator;
    Rigidbody rb;
    bool wasGrounded;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        bool isGrounded = Physics.CheckSphere(groundCheck.position, groundRadius, groundLayer);

        Vector3 horizontal = new Vector3(rb.linearVelocity.x, 0, rb.linearVelocity.z);
        animator.SetFloat("Speed", horizontal.magnitude);
        animator.SetBool("IsGrounded", isGrounded);

        //ativa o jump
        if (wasGrounded && !isGrounded && rb.linearVelocity.y > 0.1f)
        {
            animator.SetTrigger("Jump");
        }

        wasGrounded = isGrounded;
    }
}