using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class L1Character : MonoBehaviour
{
    [SerializeField]
    protected CharacterSO characterSO;

    protected const string FINALPLAYER = "Player";

    protected Animator animator;

    protected const string finalIsWalking = "IsWalking";

    protected bool isMissionStart = false;

    [SerializeField]
    protected GameInput gameInput;

    protected Transform exclamationbox;

    [SerializeField]
    protected GameObject solutionPlace;

    protected bool isMissionOver=false;

    [SerializeField]
    protected List<GameObject> vehicles = new List<GameObject>();
    protected void Start()
    {
        exclamationbox = transform.GetChild(3);
        animator = GetComponent<Animator>();
        for(int i=0;i<vehicles.Count;i++)
        {
            vehicles[i].GetComponent<L1Vehicle>().CanDrive = true;
        }
    }

    protected virtual void onChoosed(object sender, GameInput.onChooseEventArgs e)
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

    protected void OnTriggerEnter(Collider other)
    {

        GameObject gObject = other.gameObject;

        if (gObject.tag == FINALPLAYER)
        {
            recognizePlayer();
        }
    }

    protected void OnTriggerExit(Collider other)
    {
        GameObject gObject = other.gameObject;

        if (gObject.tag == FINALPLAYER)
        {
            forgetPlayer();
        }
    }
    protected void recognizePlayer()
    {
        gameInput.onChoose += onChoosed;
        Transform speechBox = transform.GetChild(2);
        speechBox.gameObject.SetActive(true);
    }

    protected void forgetPlayer()
    {
        gameInput.onChoose -= onChoosed;
        Transform speechBox = transform.GetChild(2);
        speechBox.gameObject.SetActive(false);
    }

    public CharacterSO getCharacterSO()
    {
        return characterSO;
    }

    protected virtual void startMission()
    {
        exclamationbox.gameObject.SetActive(true);
        Debug.Log(exclamationbox.parent);
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

    public Animator getAnimator()
    {
        return animator;
    }

}
