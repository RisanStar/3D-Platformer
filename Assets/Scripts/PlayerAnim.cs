using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    public Animator anim;
    private Rigidbody rb;
    public LayerMask layerMask;
    public bool grounded;
    public float anima;
    private bool doubleJump = false;
    [SerializeField] AudioSource jumpSound;
   
    void Start()
    {
        this.rb = GetComponent<Rigidbody>();
    }

    public void Update()
    {
        Grounded();
        Jump();
        Move();
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && this.grounded)
        {
            Debug.Log("Jumped");
            this.rb.AddForce(Vector3.up * 6, ForceMode.Impulse);
            jumpSound.Play();
        }
        else
        {
            if(Input.GetButtonDown("Jump") && this.grounded && doubleJump)
            {
                this.rb.AddForce(Vector3.up * 2, ForceMode.Impulse);
                doubleJump = false;
            }
        }
            
    }
    private void Grounded()
    {
        if (Physics.CheckSphere(this.transform.position + Vector3.down, anima, layerMask))
        {
            this.grounded = true;
        }
        else
        {
            this.grounded = false;

        }
         this.anim.SetBool("Jump", !this.grounded);
         this.anim.SetBool("Fall", !this.grounded);
       
            

    }

    private void Move()
    {
        float verticalAxis = Input.GetAxis("Vertical");
        float horizontalAxis = Input.GetAxis("Horizontal");

        Vector3 movement = this.transform.forward * verticalAxis + this.transform.right * horizontalAxis;
        movement.Normalize();

        this.transform.position += movement * 0.01f;

        this.anim.SetFloat("Vertical", verticalAxis);
        this.anim.SetFloat("Horizontal", horizontalAxis);
    }
}
