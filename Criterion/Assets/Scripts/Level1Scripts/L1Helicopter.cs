using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L1Helicopter : MonoBehaviour
{
    [SerializeField]
    private GameInput gameInput;

    private const string FINALPLAYER = "Player";

    private CharacterController characterController;

    private AudioSource helicopterSoundEffect;

    private float speed = 0;

    private float frontAccelaration = 1f;

    private float maxFrontSpeed = 200;

    private Transform wings;

    private Transform frontWing;
    private Transform backWing;

    private float altitudeSpeed=0;

    private float wingTurnSpeed = 2f;

    private float altitude = 0f;

    private float minFlytAltitude = 100f;
    // Start is called before the first frame update
    void Start()
    {
        gameInput.onHelicopterInteract += onHelicopterInteracted;
        Transform steeringWheel = transform.GetChild(0);
        steeringWheel.gameObject.SetActive(false);
        characterController = GetComponent<CharacterController>();
        helicopterSoundEffect = GetComponent<AudioSource>();
        wings = transform.GetChild(1);
        frontWing = wings.GetChild(0);
        backWing = wings.GetChild(1);
    }

    private void onHelicopterInteracted(object sender, EventArgs e)
    {
        liveHelicopter();
    }

    // Update is called once per frame
    void Update()
    {
        drive();
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
        float frontDirection = gameInput.getHelicopterMovementVectorNormalized().y;

        float sideDirection = gameInput.getHelicopterMovementVectorNormalized().x;

        float altitudeDirection = gameInput.getHelicopterAltitude();

        if(altitudeDirection>0)
        {
            altitudeSpeed = 5f;
            altitude++;
        }
        else if(altitudeDirection==0)
        {
            altitudeSpeed = 0f;
        }
        else
        {
            altitudeSpeed = -5f;
            altitude--;

        }

        if(altitude>minFlytAltitude)
        {
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
        }

        float turnTo = sideDirection * 45f;

        if(altitude>minFlytAltitude)
        {
            if (frontDirection > 0)
            {
                transform.Rotate(new Vector3(0f, turnTo, 0f) * frontDirection * Time.deltaTime, Space.Self);
            }
            else if (frontDirection == 0)
            {
                if (speed > 0)
                {
                    transform.Rotate(new Vector3(0f, turnTo, 0f) * Time.deltaTime, Space.Self);
                }

            }
        }
        
        frontWing.Rotate(new Vector3(0f,360f* wingTurnSpeed, 0f) * Time.deltaTime, Space.Self);
        backWing.Rotate(new Vector3(0f, 0f, 360f * wingTurnSpeed) * Time.deltaTime, Space.Self);


        Vector3 move = transform.right * speed + transform.forward * speed * Mathf.Sin((Mathf.PI / 180) * turnTo)+transform.up*altitudeSpeed;
        characterController.Move(move * Time.deltaTime);
    }

    public void liveHelicopter()
    {
        Transform player = null;
        player = GameObject.Find("Player").transform;
        gameInput.getInputActs().Helicopter.Disable();
        player.position = new Vector3(player.position.x + 20f, player.position.y, player.position.z);
        player.GetComponent<L1Player>().enabled = true;
        player.GetComponent<L1Player>().enablePlayerInputActions();
        player.parent = null;
        enabled = false;
    }

    public void enterHelicopter()
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
        gameInput.getInputActs().Helicopter.Enable();
    }
}
