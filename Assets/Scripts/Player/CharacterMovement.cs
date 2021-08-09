using System;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private CharacterController characterController;
    private float speed = 12f;
    private float gravity = -25f;
    private float jumpHeight = 3f;
    private Vector3 velocity;

    public Transform groundCheck;
    private float groundCheckRadius = 0.3f;
    public LayerMask groundMask;
    private bool isGrounded;

    public static event Action<ItemObject, int> OnTriggeredItem; 

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundMask);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity); // 0_- 
        }

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float xAxis = Input.GetAxis("Horizontal");
        float zAxis = Input.GetAxis("Vertical");

        Vector3 direction = transform.right * xAxis + transform.forward * zAxis;
        characterController.Move(direction * (speed * Time.deltaTime));
        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(groundCheck.position, groundCheckRadius);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Item item))
        {
            OnTriggeredItem?.Invoke(item.item,1);
        }
    }

    public void SetPlayerPosition(Vector3 position,Quaternion rotation)
    {
        characterController.enabled = false;
        transform.position = position;
        transform.rotation = rotation;
        characterController.enabled = true;
    }

}