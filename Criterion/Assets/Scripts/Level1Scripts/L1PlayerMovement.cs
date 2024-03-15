using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L1PlayerMovement : MonoBehaviour
{
    
    private CharacterController characterController;

    [SerializeField]
    private float speed = 12f;

    private float gravity = -49.5f;

    Vector3 velocity;

    [SerializeField]
    private Transform groundCheck;

    [SerializeField]
    private float groundDistance=0.4f;

    [SerializeField]
    private LayerMask groundMask;

    private bool isGrounded;

    private float jumpHeight = 5f;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position,groundDistance,groundMask);

        if(isGrounded&& velocity.y<0)
        {
            velocity.y = -2f;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;


        characterController.Move(move*speed*Time.deltaTime);

        if(Input.GetKeyDown(KeyCode.Space)&&isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight*-2f*gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        characterController.Move(velocity*Time.deltaTime);
    }
}
