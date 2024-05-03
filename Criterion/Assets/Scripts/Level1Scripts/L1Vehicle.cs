using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L1Vehicle : MonoBehaviour
{
    [SerializeField]
    protected GameInput gameInput;

    protected const string FINALPLAYER = "Player";

    protected CharacterController characterController;

    protected AudioSource vehicleSoundEffect;

    [SerializeField]
    protected bool canDrive = false;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        characterController = GetComponent<CharacterController>();
        vehicleSoundEffect = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        drive();
    }

    protected virtual void recognizePlayer()
    {
        Transform steeringWheelBox = transform.GetChild(0);
        steeringWheelBox.gameObject.SetActive(true);
    }

    protected virtual void forgetPlayer()
    {
        Transform steeringWheelBox = transform.GetChild(0);
        steeringWheelBox.gameObject.SetActive(false);
    }

    protected virtual void drive()
    {

    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        GameObject gObject = other.gameObject;

        if (gObject.tag == FINALPLAYER)
        {
            recognizePlayer();
        }
    }

    protected virtual void  OnTriggerExit(Collider other)
    {
        GameObject gObject = other.gameObject;

        if (gObject.tag == FINALPLAYER)
        {
            forgetPlayer();
        }
    }

    public virtual void enter()
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

    public virtual void live()
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

    public bool CanDrive
    {
        get
        {
            return canDrive;
        }

        set
        {
            canDrive = value;
        }
    }
}
