using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class characterController : MonoBehaviour
{



    public float speed = 10.0F;
    public LayerMask groundLayers;
    public float jumpForce = 6;
    private Rigidbody rb;
    public CapsuleCollider col;



    // Use this for initialization
    void Start()
    {

        rb = GetComponent<Rigidbody>();
        col = GetComponent<CapsuleCollider>();


        Cursor.lockState = CursorLockMode.Locked;
        


    }

    // Update is called once per frame
    void Update()
    {



        float translation = Input.GetAxis("Vertical") * speed;
        float straffe = Input.GetAxis("Horizontal") * speed;
        translation *= Time.deltaTime;
        straffe *= Time.deltaTime;

        transform.Translate(straffe, 0, translation);

        if (Input.GetKeyDown("escape"))
            Cursor.lockState = CursorLockMode.None;

        if (Input.GetKeyDown("tab"))
            Cursor.lockState = CursorLockMode.Locked;


        //jumping
        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }


    }

    private bool IsGrounded()
    {
        return Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x,
            col.bounds.min.y, col.bounds.center.z), col.radius * .9f, groundLayers);
        
    }
}
