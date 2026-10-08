using UnityEngine;

public class Level1 : MonoBehaviour
{
    [SerializeField] float Speed;
    Vector3 MoveDirection;
    [SerializeField] TriggerScript Trigger;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MoveDirection = new Vector3 (0, 0, -Speed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (!Trigger.Triggered)
        {
            transform.Translate(MoveDirection * Time.deltaTime);
        }
    }
}
