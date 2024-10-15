using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController characterController;
    public float speed = 10f;

    private float gravity = -9.81f;

    public Transform groundCheck;

    public float sphereRadius = 0.3f;

    public LayerMask groundMask;

    bool isGrounded;

    public float jumpeHigh = 3;
    

    Vector3 velocity;

       void Update()
    {

        isGrounded = Physics.CheckSphere(groundCheck.position,sphereRadius,groundMask);

        if(isGrounded && velocity.y <0)
        {
            velocity.y = -2f;
        }


        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z ;

        if(Input.GetKeyDown(KeyCode.Space )&& isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpeHigh * -2 * gravity);
        }
        velocity.y += gravity * Time.deltaTime;


        characterController.Move(move * speed * Time.deltaTime);

        characterController.Move(velocity*Time.deltaTime);

    }
}
