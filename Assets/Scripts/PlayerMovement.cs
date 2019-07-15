/*
    We can are going to use Character Controller componet, because RB is OP for this game
        1. Get DIR to move ->vector3
        2. Get velocity -> velocity = dir * speed
        3. Move -> velocity * deltaTime
        4. Check if we can jump else we should add gravity
        5. Make sure to store the Y velocity in variable or we will reset the velocity on every frame and the jump wont work properly
*/
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private CharacterController controller;
    private Vector3 moveForward;
    private Vector3 velocity;
    private float velocityY;
    private float velocityLeft;
    private float velocityRight;

    [SerializeField]
    private float speed = 10f;
    [SerializeField]
    private float jumpHeight = 5f;
    [SerializeField]
    private float gravity = 1f;
    [SerializeField]
    private float moveToLeft = -5f;
    [SerializeField]
    private float moveToRight = 5f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void FixedUpdate()
    {
        moveForward = Vector3.forward;
        velocity = moveForward * speed;

        if (controller.isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                velocityY = jumpHeight;
            }
        }

        if (Input.GetKey(KeyCode.A))
        {
            velocityLeft = moveToLeft;
            velocity.x = velocityLeft;
        }

        if (Input.GetKey(KeyCode.D))
        {
            velocityRight = moveToRight;
            velocity.x = velocityRight;
        }

        velocityY -= gravity;

        velocity.y = velocityY;
        controller.Move(velocity * Time.fixedDeltaTime);
    }
}
