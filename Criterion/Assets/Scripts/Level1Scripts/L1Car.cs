using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class L1Car : MonoBehaviour
{
    [SerializeField]
    private GameInput gameInput;

    private const string FINALPLAYER = "Player";

    private CharacterController characterController;

    private AudioSource carSoundEffect;

    private Transform wheels;

    private Transform frontLeftWheel;
    private Transform frontRightWheel;
    private Transform backLeftWheel;
    private Transform backRightWheel;

    private float speed=0;

    private float frontAccelaration = 1f;

    private float maxFrontSpeed = 200;

    private float maxBackSpeed = -50f;


    private void Start()
    {
        gameInput.onCarInteract += onCarInteracted;
        Transform steeringWheel=transform.GetChild(0);
        steeringWheel.gameObject.SetActive(false);
        characterController = GetComponent<CharacterController>();
        carSoundEffect = GetComponent<AudioSource>();
        gameInput.onHorn += gameInputOnHorn;
        wheels=transform.GetChild(1);
        frontLeftWheel = wheels.GetChild(0);
        frontRightWheel = wheels.GetChild(1);
        backLeftWheel = wheels.GetChild(2);
        backRightWheel = wheels.GetChild(3);
    }

    private void onCarInteracted(object sender, EventArgs e)
    {
        liveCar();
    }

    private void Update()
    {
        drive();
    }

    private void gameInputOnHorn(object sender, EventArgs e)
    {
        carSoundEffect.Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject gObject = other.gameObject;

        if (gObject.tag == FINALPLAYER)
        {
            recognizePlayer();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        GameObject gObject = other.gameObject;

        if (gObject.tag == FINALPLAYER)
        {
            forgetPlayer();
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

    public void liveCar()
    {
        Transform player = transform.GetChild(transform.childCount - 1);
        player.parent = null;
        player.position = new Vector3(player.position.x + 20f, player.position.y, player.position.z);
        player.GetComponent<L1Player>().enabled = true;
        player.GetComponent<L1Player>().enablePlayerInputActions();
        gameInput.getInputActs().Car.Disable();
        enabled = false;
    }
}
