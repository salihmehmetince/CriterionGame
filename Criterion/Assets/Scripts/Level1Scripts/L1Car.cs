using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class L1Car : MonoBehaviour
{
    [SerializeField]
    private GameInput gameInput;

    private const string FINALPLAYER = "Player";

    private CharacterController characterController;

    private AudioSource hornSoundEffect;

    private Transform wheels;

    private Transform frontLeftWheel;
    private Transform frontRightWheel;


    [SerializeField]
    private float speed;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        hornSoundEffect = GetComponent<AudioSource>();
        gameInput.onHorn += gameInputOnHorn;
        wheels=transform.GetChild(1);
        frontLeftWheel = wheels.GetChild(0);
        frontRightWheel = wheels.GetChild(1);

    }

    private void Update()
    {
        drive();
    }

    private void gameInputOnHorn(object sender, EventArgs e)
    {
        hornSoundEffect.Play();
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
        
        float turnTo = x*45f;
        Quaternion turnT =Quaternion.Euler(0f,turnTo,0f);

        this.frontLeftWheel.localRotation = Quaternion.Slerp(this.frontLeftWheel.rotation, turnT,1f);
        this.frontRightWheel.localRotation = Quaternion.Slerp(this.frontRightWheel.localRotation, turnT, 1f);
        
        Vector3 move = transform.forward * z + transform.right*z* Mathf.Sin((Mathf.PI / 180) * turnTo);
        characterController.Move(move *speed*Time.deltaTime);
    }
}
