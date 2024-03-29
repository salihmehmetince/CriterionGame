using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class L1Character : MonoBehaviour
{
    [SerializeField]
    private CharacterSO characterSO;
    private const string FINALPLAYER = "Player";

    private Animator animator;

    private const string finalIsWalking = "IsWalking";

    private bool isMissionStart = false;

    [SerializeField]
    private GameInput gameInput;

    private Transform exclamationbox;

    [SerializeField]
    private GameObject solutionPlace;

    private bool isMissionOver=false;
    private void Start()
    {
        exclamationbox = transform.GetChild(3);
        animator = GetComponent<Animator>();
        gameInput.onChoose += onChoosed;
    }

    private void onChoosed(object sender, GameInput.onChooseEventArgs e)
    {
        if (e.Choose.x == 0 && e.Choose.y == 1 && e.Choose.z == 0)
        {
            Debug.Log("1");
            
        }
        else if (e.Choose.x == 0 && e.Choose.y == -1 && e.Choose.z == 0)
        {
            Debug.Log("2");
        }
        else if (e.Choose.x == -1 && e.Choose.y == 0 && e.Choose.z == 0)
        {
            Debug.Log("3");
        }
        else if (e.Choose.x == 1 && e.Choose.y == 0 && e.Choose.z == 0)
        {
            Debug.Log("4");
            startMission();
        }
        else if (e.Choose.x == 0 && e.Choose.y == 0 && e.Choose.z == 1)
        {
            Debug.Log("5");
        }
        else if (e.Choose.x == 0 && e.Choose.y == 0 && e.Choose.z == -1)
        {
            Debug.Log("6");
        }
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
        Transform speechBox = transform.GetChild(2);
        speechBox.gameObject.SetActive(true);
    }

    private void forgetPlayer()
    {
        Transform speechBox = transform.GetChild(2);
        speechBox.gameObject.SetActive(false);
    }

    public CharacterSO getCharacterSO()
    {
        return characterSO;
    }

    private void startMission()
    {
        exclamationbox.gameObject.SetActive(true);
        solutionPlace.SetActive(true);
    }

    public bool IsMissionOver
    {
        get { return isMissionOver; }
        set { isMissionOver = value; }
    }

    public bool IsMissionStart
    {
        get { return isMissionStart; }
        set { isMissionStart = value; }
    }

}
