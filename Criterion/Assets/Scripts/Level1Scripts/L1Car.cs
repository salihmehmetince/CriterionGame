using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class L1Car : L1Vehicle
{

    private Transform wheels;

    private Transform frontLeftWheel;
    private Transform frontRightWheel;
    private Transform backLeftWheel;
    private Transform backRightWheel;

    private float speed=0;

    private float frontAccelaration = 1f;

    private float maxFrontSpeed = 200;

    private float maxBackSpeed = -50f;

    protected override void Start()
    {
        gameInput.onCarInteract += onCarInteracted;
        Transform steeringWheel=transform.GetChild(0);
        steeringWheel.gameObject.SetActive(false);
        characterController = GetComponent<CharacterController>();
        vehicleSoundEffect = GetComponent<AudioSource>();
        gameInput.onHorn += gameInputOnHorn;
        wheels=transform.GetChild(1);
        frontLeftWheel = wheels.GetChild(0);
        frontRightWheel = wheels.GetChild(1);
        backLeftWheel = wheels.GetChild(2);
        backRightWheel = wheels.GetChild(3);
    }

    protected override void Update()
    {
        drive();
    }

    private void onCarInteracted(object sender, EventArgs e)
    {
        live();
    }


    private void gameInputOnHorn(object sender, EventArgs e)
    {
        vehicleSoundEffect.Play();
    }



    protected override void drive()
    {
        float z = gameInput.getCarMovementVectorNormalized().y;

        float x = gameInput.getCarMovementVectorNormalized().x;

        if(z>0f)
        {
            if(speed>maxFrontSpeed)
            {
                speed = maxFrontSpeed;
            }
            else
            {
                speed += frontAccelaration;
            }
        }
        else if(z==0f)
        {
            if(speed>0)
            {
                speed -= frontAccelaration;
            }else if(speed==0f)
            {
                speed = 0f;
            }
            else
            {
                speed+=frontAccelaration;
            }
            
        }
        else
        {
            if (speed> maxBackSpeed)
            {
                speed -= frontAccelaration;
            }
            else
            {
                speed =maxBackSpeed;
            }
        }
        
        float turnTo = x*45f;
        Quaternion turnT =Quaternion.Euler(frontLeftWheel.eulerAngles.x+ z*45f,turnTo,0f);

        frontLeftWheel.localRotation = Quaternion.Slerp(frontLeftWheel.localRotation, turnT,0.1f);
        frontRightWheel.localRotation = Quaternion.Slerp(frontRightWheel.localRotation, turnT, 0.1f);

        if(z>0)
        {
            transform.Rotate(new Vector3(0f, turnTo, 0f) * z * Time.deltaTime, Space.Self);
        }
        else if(z==0)
        {
            if(speed>0)
            {
                transform.Rotate(new Vector3(0f, turnTo, 0f) * Time.deltaTime, Space.Self);
            }

        }
        else
        {
            transform.Rotate(new Vector3(0f, turnTo, 0f) * z * Time.deltaTime, Space.Self);
        }
        //frontLeftWheel.Rotate(new Vector3(z*45f,0f,0f)*Time.deltaTime,Space.Self);
        //frontRightWheel.Rotate(new Vector3(z*45f,0f,0f)*Time.deltaTime,Space.Self);
        backLeftWheel.Rotate(new Vector3(z*45f,0f,0f)*Time.deltaTime,Space.Self);
        backRightWheel.Rotate(new Vector3(z*45f,0f,0f)*Time.deltaTime,Space.Self);

        Vector3 move = transform.forward * speed + transform.right* speed * Mathf.Sin((Mathf.PI / 180) * turnTo);
        characterController.Move(move *Time.deltaTime);
    }

    public override void live()
    {
        Transform player = null;
        player = GameObject.Find("Player").transform;
        gameInput.getInputActs().Car.Disable();
        player.position = new Vector3(player.position.x + 20f, player.position.y, player.position.z);
        player.GetComponent<L1Player>().enabled = true;
        player.GetComponent<L1Player>().enablePlayerInputActions();
        player.parent = null;
        enabled = false;
    }

    public override void enter()
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
        gameInput.getInputActs().Car.Enable();
    }

    public float Speed
    {
        get { return speed; }
    }

}
