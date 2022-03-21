using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float movementSpeed = 6f;
    [SerializeField] float jumpForce = 5f;


    private bool isGrounded = false;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        rb.velocity = new Vector3(horizontalInput * movementSpeed, rb.velocity.y, rb.velocity.z);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }
    }

    void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
    }

    private void OnCollisionEnter(Collision other) {
        
        if(other.transform.tag == "Plane")
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision other) {
        
        if(other.transform.tag == "Plane")
        {
            isGrounded = false;
        }
    }

    


}
