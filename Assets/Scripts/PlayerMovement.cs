using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float movementSpeed = 5f;
    [SerializeField] float jumpForce = 5f;
    private bool doubleJump = false;

    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        rb.velocity = new Vector3(horizontalInput * movementSpeed, rb.velocity.y, verticalInput * movementSpeed);

        if (IsGrounded())
        {
            doubleJump = true;

            if (Input.GetButtonDown("Jump"))
            {
                rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
            }
        }
        else
        {
            if (Input.GetButtonDown("Jump") && doubleJump)
            {
                rb.velocity = new Vector3(rb.velocity.x, jumpForce * 1.1f, rb.velocity.z);
                doubleJump = false;
            }
        }      
           

            

     

    }

    bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, 1f, ground);
    }
}
