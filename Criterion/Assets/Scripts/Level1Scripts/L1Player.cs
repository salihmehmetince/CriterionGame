using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using TMPro;
using UnityEngine;
using static GameInput;

public class L1Player : MonoBehaviour
{
    private const string FINALCHARACTER = "Character";

    private bool canInteract = false;


    [SerializeField]
    private GameInput gameInput;

    private CharacterSO characterSO;

    private const string FINALCAR = "Car";

    private GameObject interactionObject;

    private CharacterController characterController;

    [SerializeField]
    private float speed;

    Vector3 velocity;

    [SerializeField]
    private Transform groundCheck;

    [SerializeField]
    private float groundDistance = 0.4f;

    [SerializeField]
    private LayerMask groundMask;

    [SerializeField]
    private LayerMask buildingMask;

    [SerializeField]
    private LayerMask vehicleMask;

    [SerializeField]
    private LayerMask natureMask;

    private bool isGrounded;

    private float jumpHeight = 5f;

    private float gravity = -49.5f;

    private void OnTriggerEnter(Collider other)
    {
        GameObject gObject = other.gameObject;
        if (gObject.tag == FINALCHARACTER)
        {

            recognizeCharacter(gObject);
        }
        else if(gObject.tag == FINALCAR)
        {
            recognizeCar(gObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        forgetCharacter();
    }

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        gameInput.onInteract += onInteracted;
        gameInput.onJump += onJumped;
    }

    private void Update()
    {
        
        move();
        jump();
    }

    private void onJumped(object sender, EventArgs e)
    {
        //jump();
    }

    private void onInteracted(object sender, EventArgs e)
    {
        if(interactionObject.tag==FINALCHARACTER)
        {
            handleTalk();
        }
        else if(interactionObject.tag==FINALCAR)
        {
            driveCar();
        }
    }

    private void handleTalk()
    {
        if(canInteract)
        {
            Transform canvas = transform.GetChild(3);
            canvas.gameObject.SetActive(true);
            Transform speech = canvas.GetChild(1);
            TextMeshProUGUI speechText = speech.GetComponent<TextMeshProUGUI>();
            string name = characterSO.getName();
            List<string> conversations=characterSO.getConversations();
            List<string> helps = characterSO.getHelps();

            speechText.text = "Hello! My name is ";
            speechText.text +=name+"\n";

            speechText.text += "Conversations\n";
            int i = 0;
            for (i=0;i<conversations.Count;i++)
            {
                speechText.text +=(i+1)+":"+conversations[i]+"\n";
            }

            speechText.text += "Helps\n";
            for (; i < conversations.Count+helps.Count; i++)
            {
                speechText.text += (i + 1) + ":" + helps[(i-conversations.Count)]+"\n";
            }
        }
    }

    private void recognizeCharacter(GameObject gObject)
    {
        interactionObject = gObject;
        canInteract = true;
        this.characterSO = gObject.GetComponent<L1Character>().getCharacterSO();
    }
    private void forgetCharacter()
    {
        canInteract = false;
        Transform canvas = transform.GetChild(3);
        canvas.gameObject.SetActive(false);
    }

    private void recognizeCar(GameObject gObject)
    {
        interactionObject = gObject;
        canInteract = true;
    }

    private void driveCar()
    {
        transform.SetParent(interactionObject.transform);
        transform.localPosition=new Vector3(0f, 0.5f, 0.3f);
        transform.localRotation = Quaternion.identity;
        enabled = false;
        gameInput.getInputActs().Player.Disable();
        interactionObject.GetComponent<L1Car>().enabled = true;
    }

    private void move()
    {
        float x = gameInput.getPlayerMovementVectorNormalized().x;
        float z = gameInput.getPlayerMovementVectorNormalized().y;

        Vector3 move = transform.right * x + transform.forward * z;


        characterController.Move(move * speed * Time.deltaTime);
    }

    private void jump()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask | buildingMask | vehicleMask | natureMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        characterController.Move(velocity * Time.deltaTime); ;


    }

}
