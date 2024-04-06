using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using TMPro;
using UnityEngine;
using static GameInput;
using static L1Player;

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

    private const string FINALHELICOPTER = "Helicopter";

    private const string FINALAIRCRAFT = "Aircraft";

    private bool canChoose = false;

    private Transform canvas;

    private Transform speech;

    private TextMeshProUGUI speechText;

    private List<Mission> missions = new List<Mission>();

    private const string FINALSIDECHARACTER = "SideCharacter";
    public struct Mission
    {
        private int missionregion;
        private GameObject missionCharacter;

        public int MissionRegion
        {
            get { return missionregion; }
            set { missionregion = value; }
        }

        public GameObject MissionCharacter
        {
            get { return missionCharacter; }
            set { missionCharacter = value; }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        GameObject gObject = other.gameObject;
        if (gObject.tag == FINALCHARACTER)
        {
            recognizeCharacter(gObject);
        }
        else if(gObject.tag==FINALSIDECHARACTER)
        {
            recognizeSideCharacter(gObject);
        }
        else if(gObject.tag == FINALCAR)
        {
            recognizeCar(gObject);
        }
        else if(gObject.tag==FINALHELICOPTER)
        {
            recognizeHelicopter(gObject);
        }
        else if(gObject.tag==FINALAIRCRAFT)
        {
            recognizePlane(gObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        GameObject gObject = other.gameObject;
        if (gObject.tag == FINALCHARACTER)
        {
            forgetCharacter();
        }
        else if(gObject.tag==FINALSIDECHARACTER)
        {
            forgetSideCharacter();
        }
        else if (gObject.tag == FINALCAR)
        {
            forgetCar();
        }
        else if (gObject.tag == FINALHELICOPTER)
        {
            forgetHelicopter();
        }
        else if (gObject.tag == FINALAIRCRAFT)
        {
            forgetPlane();
        }
    }

    private void Start()
    {
        canvas = transform.GetChild(3);
        speech = canvas.GetChild(1);
        speechText = speech.GetComponent<TextMeshProUGUI>();
        characterController = GetComponent<CharacterController>();
        gameInput.onInteract += onInteracted;
        gameInput.onJump += onJumped;
        gameInput.onChoose += onChoosed;
    }

    private void onChoosed(object sender, onChooseEventArgs e)
    {
        if(canChoose)
        {
            if(interactionObject.tag==FINALCHARACTER)
            {
                if (!interactionObject.GetComponent<L1Character>().IsMissionOver)
                {
                    if (e.Choose.x == 0 && e.Choose.y == 1 && e.Choose.z == 0)
                    {
                        Debug.Log("1");
                        string question = characterSO.getConversations()[0];
                        string answer = characterSO.getConversationAnswers()[0];
                        string text = "You: " + question + "\nHim: " + answer;
                        speechText.text = text;
                    }
                    else if (e.Choose.x == 0 && e.Choose.y == -1 && e.Choose.z == 0)
                    {
                        string question = characterSO.getConversations()[1];
                        string answer = characterSO.getConversationAnswers()[1];
                        string text = "You: " + question + "\nHim: " + answer;
                        speechText.text = text;
                        Debug.Log("2");
                    }
                    else if (e.Choose.x == -1 && e.Choose.y == 0 && e.Choose.z == 0)
                    {
                        string question = characterSO.getConversations()[2];
                        string answer = characterSO.getConversationAnswers()[2];
                        string text = "You: " + question + "\nHim: " + answer;
                        speechText.text = text;
                        Debug.Log("3");
                    }
                    else if (e.Choose.x == 1 && e.Choose.y == 0 && e.Choose.z == 0)
                    {
                        Debug.Log("4");
                        string question = characterSO.getHelps()[0];
                        string answer = characterSO.getHelpAnswers()[0];
                        string text = "You: " + question + "\nHim: " + answer;
                        speechText.text = text;
                        if(!interactionObject.GetComponent<L1Character>().IsMissionStart)
                        {
                            interactionObject.GetComponent<L1Character>().IsMissionStart = true;
                            Mission mission = new Mission();
                            mission.MissionCharacter = interactionObject;
                            mission.MissionRegion = characterSO.getMissionNumber();
                            missions.Add(mission);
                            Debug.Log(mission.MissionCharacter + " " + mission.MissionRegion + " " + missions.Count);
                        }
                        else
                        {
                            Debug.Log("a");
                        }

                    }
                    else if (e.Choose.x == 0 && e.Choose.y == 0 && e.Choose.z == 1)
                    {
                        string question = characterSO.getHelps()[1];
                        string answer = characterSO.getHelpAnswers()[1];
                        string text = "You: " + question + "\nHim: " + answer;
                        speechText.text = text;
                        Debug.Log("5");
                    }
                    else if (e.Choose.x == 0 && e.Choose.y == 0 && e.Choose.z == -1)
                    {
                        string question = characterSO.getHelps()[2];
                        string answer = characterSO.getHelpAnswers()[2];
                        string text = "You: " + question + "\nHim: " + answer;
                        speechText.text = text;
                        Debug.Log("6");
                    }
                }
                else
                {
                    if (e.Choose.x == 0 && e.Choose.y == 1 && e.Choose.z == 0)
                    {
                        Debug.Log("1");
                        string solutionAnswer = characterSO.getSolutionAnswers()[0];
                        string apriciate = characterSO.getApriciates()[0];
                        string text = "You: " + solutionAnswer + "\nHim: " + apriciate;
                        speechText.text = text;
                    }
                }
            }
            else if(interactionObject.tag==FINALSIDECHARACTER)
            {
                if (!interactionObject.transform.parent.GetComponent<L1Character>().IsMissionOver)
                {
                    if (e.Choose.x == 0 && e.Choose.y == 1 && e.Choose.z == 0)
                    {
                        Debug.Log("1");
                        string question = characterSO.getConversations()[0];
                        string answer = characterSO.getConversationAnswers()[0];
                        string text = "You: " + question + "\nHim: " + answer;
                        speechText.text = text;
                    }
                    else if (e.Choose.x == 0 && e.Choose.y == -1 && e.Choose.z == 0)
                    {
                        string question = characterSO.getConversations()[1];
                        string answer = characterSO.getConversationAnswers()[1];
                        string text = "You: " + question + "\nHim: " + answer;
                        speechText.text = text;
                        Debug.Log("2");
                    }
                    else if (e.Choose.x == -1 && e.Choose.y == 0 && e.Choose.z == 0)
                    {
                        string question = characterSO.getConversations()[2];
                        string answer = characterSO.getConversationAnswers()[2];
                        string text = "You: " + question + "\nHim: " + answer;
                        speechText.text = text;
                        Debug.Log("3");
                    }
                    else if (e.Choose.x == 1 && e.Choose.y == 0 && e.Choose.z == 0)
                    {
                        Debug.Log("4");
                        string question = characterSO.getHelps()[0];
                        string answer = characterSO.getHelpAnswers()[0];
                        string text = "You: " + question + "\nHim: " + answer;
                        speechText.text = text;
                    }
                    else if (e.Choose.x == 0 && e.Choose.y == 0 && e.Choose.z == 1)
                    {
                        string question = characterSO.getHelps()[1];
                        string answer = characterSO.getHelpAnswers()[1];
                        string text = "You: " + question + "\nHim: " + answer;
                        speechText.text = text;
                        Debug.Log("5");
                    }
                    else if (e.Choose.x == 0 && e.Choose.y == 0 && e.Choose.z == -1)
                    {
                        string question = characterSO.getHelps()[2];
                        string answer = characterSO.getHelpAnswers()[2];
                        string text = "You: " + question + "\nHim: " + answer;
                        speechText.text = text;
                        Debug.Log("6");
                    }
                }
                else
                {
                    if (e.Choose.x == 0 && e.Choose.y == 1 && e.Choose.z == 0)
                    {
                        Debug.Log("1");
                        string solutionAnswer = characterSO.getSolutionAnswers()[0];
                        string apriciate = characterSO.getApriciates()[0];
                        string text = "You: " + solutionAnswer + "\nHim: " + apriciate;
                        speechText.text = text;
                    }
                }
            }

            
        }
        canChoose = false;
        Invoke(nameof(handleTalk),1f);
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
        else if(interactionObject.tag==FINALSIDECHARACTER)
        {
            handleTalk();
        }
        else if(interactionObject.tag==FINALCAR)
        {
            driveCar();
        }
        else if(interactionObject.tag == FINALHELICOPTER)
        {
            driveHelicopter();
        }
        else if(interactionObject.tag == FINALAIRCRAFT)
        {
            drivePlane();
        }
    }

    private void handleTalk()
    {

        if (canInteract)
        {
            if(interactionObject.tag==FINALCHARACTER)
            {
                if (!interactionObject.GetComponent<L1Character>().IsMissionOver)
                {
                    canvas.gameObject.SetActive(true);
                    string name = characterSO.getName();
                    List<string> conversations = characterSO.getConversations();
                    List<string> helps = characterSO.getHelps();

                    speechText.text = "Hello! My name is ";
                    speechText.text += name + "\n";

                    speechText.text += "Conversations\n";
                    int i = 0;
                    for (i = 0; i < conversations.Count; i++)
                    {
                        speechText.text += (i + 1) + ":" + conversations[i] + "\n";
                    }

                    speechText.text += "Helps\n";
                    for (; i < conversations.Count + helps.Count; i++)
                    {
                        speechText.text += (i + 1) + ":" + helps[(i - conversations.Count)] + "\n";
                    }
                    canChoose = true;
                }
                else
                {
                    canvas.gameObject.SetActive(true);
                    List<String> solutionAnswers = characterSO.getSolutionAnswers();
                    speechText.text = "";
                    for (int i = 0; i < solutionAnswers.Count; i++)
                    {
                        speechText.text += (i + 1) + ":" + solutionAnswers[i] + "\n";
                    }
                    canChoose = true;
                }
            }
            else
            {
                if (!interactionObject.transform.parent.GetComponent<L1Character>().IsMissionOver)
                {
                    canvas.gameObject.SetActive(true);
                    string name = characterSO.getName();
                    List<string> conversations = characterSO.getConversations();
                    List<string> helps = characterSO.getHelps();

                    speechText.text = "Hello! My name is ";
                    speechText.text += name + "\n";

                    speechText.text += "Conversations\n";
                    int i = 0;
                    for (i = 0; i < conversations.Count; i++)
                    {
                        speechText.text += (i + 1) + ":" + conversations[i] + "\n";
                    }

                    speechText.text += "Helps\n";
                    for (; i < conversations.Count + helps.Count; i++)
                    {
                        speechText.text += (i + 1) + ":" + helps[(i - conversations.Count)] + "\n";
                    }
                    canChoose = true;
                }
                else
                {
                    canvas.gameObject.SetActive(true);
                    List<String> solutionAnswers = characterSO.getSolutionAnswers();
                    speechText.text = "";
                    for (int i = 0; i < solutionAnswers.Count; i++)
                    {
                        speechText.text += (i + 1) + ":" + solutionAnswers[i] + "\n";
                    }
                    canChoose = true;
                }
            }
                
        }
        
    }

    private void recognizeCharacter(GameObject gObject)
    {
        interactionObject = gObject;
        interactionObject.GetComponent<L1Character>().enabled = true;
        canInteract = true;
        this.characterSO = gObject.GetComponent<L1Character>().getCharacterSO();
    }

    private void recognizeSideCharacter(GameObject gObject)
    {
        interactionObject = gObject;
        canInteract = true;
        this.characterSO = gObject.GetComponent<L1SideCharacter>().getCharacterSO();
    }
    private void forgetCharacter()
    {
        canChoose = false;
        canInteract = false;
        interactionObject.GetComponent<L1Character>().enabled = false;
        interactionObject = null;
        Transform canvas = transform.GetChild(3);
        canvas.gameObject.SetActive(false);
    }

    private void forgetSideCharacter()
    {
        canChoose = false;
        canInteract = false;
        interactionObject = null;
        Transform canvas = transform.GetChild(3);
        canvas.gameObject.SetActive(false);
    }

    private void recognizeCar(GameObject gObject)
    {
        interactionObject = gObject;
        canInteract = true;
    }

    private void recognizeHelicopter(GameObject gObject)
    {
        interactionObject = gObject;
        canInteract = true;
    }

    private void driveCar()
    {
        transform.SetParent(interactionObject.transform);
        Transform playerPosition=interactionObject.transform.GetChild(2);
        transform.localPosition = playerPosition.localPosition;
        transform.localRotation = Quaternion.identity;
        enabled = false;
        gameInput.getInputActs().Player.Disable();
        gameInput.getInputActs().Car.Enable();
        interactionObject.GetComponent<L1Car>().enabled = true;
    }

    private void driveHelicopter()
    {
        transform.SetParent(interactionObject.transform);
        Transform playerPosition = interactionObject.transform.GetChild(2);
        transform.localPosition = playerPosition.localPosition;
        transform.localRotation = Quaternion.identity;
        enabled = false;
        gameInput.getInputActs().Player.Disable();
        gameInput.getInputActs().Helicopter.Enable();
        interactionObject.GetComponent<L1Helicopter>().enabled = true;
    }

    private void drivePlane()
    {
        transform.SetParent(interactionObject.transform);
        Transform playerPosition = interactionObject.transform.GetChild(2);
        transform.localPosition = playerPosition.localPosition;
        transform.localRotation = Quaternion.identity;
        enabled = false;
        gameInput.getInputActs().Player.Disable();
        gameInput.getInputActs().Plane.Enable();
        interactionObject.GetComponent<L1Plane>().enabled = true;
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

    private void recognizePlane(GameObject gObject)
    {
        interactionObject = gObject;
        canInteract = true;
    }

    private void forgetCar()
    {
        canInteract = false;
        interactionObject = null;
        Transform canvas = transform.GetChild(3);
        canvas.gameObject.SetActive(false);
    }
    private void forgetHelicopter()
    {
        canInteract = false;
        interactionObject = null;
        Transform canvas = transform.GetChild(3);
        canvas.gameObject.SetActive(false);
    }
    private void forgetPlane()
    {
        canInteract = false;
        interactionObject = null;
        Transform canvas = transform.GetChild(3);
        canvas.gameObject.SetActive(false);
    }

    public void enablePlayerInputActions()
    {
        gameInput.getInputActs().Player.Enable();
    }

    public List<Mission> getmissions()
    {
        return missions;
    }
}
