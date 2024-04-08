using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class L1Plane : MonoBehaviour
{
    [SerializeField]
    private GameInput gameInput;

    private const string FINALPLAYER = "Player";

    private CharacterController characterController;

    private AudioSource planeSoundEffect;

    private float speed = 0;

    private float frontAccelaration = 1f;

    private float maxFrontSpeed = 200;

    private Transform propeller;

    private float wingTurnSpeed = 2f;

    private bool isFall=true;

    private const string FINALGROUND = "Ground";

    private float gravity = 0f;

    private float gravityScale = 3f;

    private bool isGrounded = true;

    [SerializeField]
    private LayerMask ground;
    private Transform body;

    private float sideSpeed=0f;

    // Start is called before the first frame update
    void Start()
    {
        Transform steeringWheel = transform.GetChild(0);
        steeringWheel.gameObject.SetActive(false);
        characterController = GetComponent<CharacterController>();
        planeSoundEffect = GetComponent<AudioSource>();
        body = transform.GetChild(1);
        propeller = body.GetChild(0);
        gameInput.onPlaneInteract += onPlaneInteracted;
        
    }

    private void onPlaneInteracted(object sender, EventArgs e)
    {
        livePlane();
    }

    void Update()
    {
        drive();
        Debug.Log(isGrounded);
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject gObject = other.gameObject;

        if (gObject.tag == FINALPLAYER)
        {
            recognizePlayer();
        }
        else if(gObject.tag == FINALGROUND)
        {
        }
    }

    private void OnTriggerExit(Collider other)
    {
        GameObject gObject = other.gameObject;

        if (gObject.tag == FINALPLAYER)
        {
            forgetPlayer();
        }
        else if (gObject.tag == FINALGROUND)
        {
        }

    }
    private void recognizePlayer()
    {
        Transform steeringWheelBox = transform.GetChild(0);
        steeringWheelBox.gameObject.SetActive(true);
    }

    private void forgetPlayer()
    {
        Transform steeringWheelBox = transform.GetChild(0);
        steeringWheelBox.gameObject.SetActive(false);
    }

    private void drive()
    {
        float frontDirection = gameInput.getPlaneMovementVectorNormalized().y;

        float sideDirection = gameInput.getHelicopterMovementVectorNormalized().x;

        float altitudeDirection = gameInput.getHelicopterAltitude();

        isGrounded = Physics.CheckSphere(transform.position,10f,ground);

            if (frontDirection > 0f)
            {
                if (speed > maxFrontSpeed)
                {
                    speed = maxFrontSpeed;
                }
                else
                {
                    speed += frontAccelaration;
                }
            }
            else
            {
                if (speed > 0)
                {
                    speed -= frontAccelaration;
                }
                else
                {
                    speed = 0f;
                }
            }

        float turnTo = sideDirection * 45f;

        if (frontDirection > 0)
        {
            transform.Rotate(0f, turnTo*Time.deltaTime, 0f);
            if (sideDirection > 0.5f)
            {
                body.localRotation = Quaternion.Euler(45f, 0f, 0f);
            }
            else if (sideDirection == 0f)
            {
                body.localRotation = Quaternion.Euler(0f, 0f, 0f);
            }
            else if (sideDirection < -0.5f)
            {
                body.localRotation = Quaternion.Euler(-45f, 0f, 0f);
            }
        }
        else if (frontDirection == 0)
        {
            if (speed > 0)
            {
                transform.Rotate(0f, turnTo*Time.deltaTime, 0f);
                if (sideDirection > 0.5f)
                {
                    body.localRotation = Quaternion.Euler(45f, 0f, 0f);
                }
                else if (sideDirection == 0f)
                {
                    body.localRotation = Quaternion.Euler(0f, 0f, 0f);
                }
                else if (sideDirection < -0.5f)
                {
                    body.localRotation = Quaternion.Euler(-45f, 0f, 0f);
                }
            }
            else
            {
                if(!isGrounded)
                {
                    //transform.localRotation = Quaternion.Slerp(transform.localRotation,Quaternion.Euler(0f,0f,45f),0.1f);
                    //characterController.Move(-transform.right *100f * Time.deltaTime);
                    if (sideDirection > 0.5f)
                    {
                        body.localRotation = Quaternion.Euler(45f, 0f, 0f);
                    }
                    else if (sideDirection == 0f)
                    {
                        body.localRotation = Quaternion.Euler(0f, 0f, 0f);
                    }
                    else if (sideDirection < -0.5f)
                    {
                        body.localRotation = Quaternion.Euler(-45f, 0f, 0f);
                    }
                }
                else
                {
                    
                }
            }

        }

        propeller.Rotate(new Vector3(speed*360f * wingTurnSpeed,0f, 0f) * Time.deltaTime, Space.Self);

        if(speed>150)
        {
            isFall = false;
        }else
        {
            isFall=true;
        }


        if(!isFall)
        {
            gravity = -9.81f*gravityScale;
        }
        else
        {
            gravity = 9.81f*gravityScale;
        }

        if(!isGrounded)
        {
            sideSpeed = 100f;
        }
        else
        {
            sideSpeed = 0f;
        }
        Vector3 move = -transform.right * speed + transform.forward*sideSpeed * Mathf.Sin((Mathf.PI / 180) * turnTo)+-transform.up*gravity;
        characterController.Move(move * Time.deltaTime);
    }

    private void livePlane()
    {
        Transform player = null;
        player = GameObject.Find("Player").transform;
        gameInput.getInputActs().Plane.Disable();
        player.position = new Vector3(player.position.x + 20f, player.position.y, player.position.z);
        player.GetComponent<L1Player>().enabled = true;
        player.GetComponent<L1Player>().enablePlayerInputActions();
        player.parent = null;
        enabled = false;
    }

    public void enterPlane()
    {
        enabled = true;
        Transform player = null;
        player = GameObject.Find("Player").transform;
        player.SetParent(transform);
        Transform playerPosition = transform.GetChild(2);
        player.localPosition = playerPosition.localPosition;
        player.localRotation = Quaternion.identity;
        player.GetComponent<L1Player>().enabled = false;
        gameInput.getInputActs().Player.Disable();
        gameInput.getInputActs().Plane.Enable();
    }

}
