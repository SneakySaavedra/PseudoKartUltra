using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestKartScript : MonoBehaviour
{
    public float forAccel, revAccel, turnPower, gravity, airDrag, groundDrag, horVeloc;
    public bool isGrounded, isDrifting;
    public Transform groundPoint;
    public LayerMask groundLayer;

    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        drag();
        move();

        

        rb.AddForce(transform.up * -gravity);
    }
    void drag()
    {
        RaycastHit hit;
        if (Physics.Raycast(groundPoint.position, -transform.up, out hit, 1, groundLayer))
        {
            isGrounded = true;
            rb.drag = groundDrag;
        }
        else
        {
            isGrounded = false;
            rb.drag = airDrag;
        }
    }
    void move()
    {
        if (Input.GetAxis("Vertical") > 0)
        {
            rb.AddForce(transform.forward * forAccel * Input.GetAxis("Vertical"));
        } else if(Input.GetAxis("Vertical") < 0)
        {
            rb.AddForce(transform.forward * revAccel * Input.GetAxis("Vertical"));
        }

        if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0)
        {
            rb.AddTorque(transform.up * turnPower * Input.GetAxis("Horizontal") * Input.GetAxis("Vertical"));
        }
    }
}
