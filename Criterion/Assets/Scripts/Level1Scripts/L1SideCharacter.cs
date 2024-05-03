using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L1SideCharacter : MonoBehaviour
{
    [SerializeField]
    protected CharacterSO characterSO;

    protected const string FINALPLAYER = "Player";

    [SerializeField]
    protected GameInput gameInput;

    [SerializeField]
    protected GameObject mainMissionCharacter;


    // Start is called before the first frame update
    protected void Start()
    {
        gameInput.onChoose += onChoosed;
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
        Transform speechBox = transform.GetChild(2);
        speechBox.gameObject.SetActive(true);
    }

    protected void forgetPlayer()
    {
        Transform speechBox = transform.GetChild(2);
        speechBox.gameObject.SetActive(false);
    }
    protected void onChoosed(object sender, GameInput.onChooseEventArgs e)
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

    // Update is called once per frame
    protected void Update()
    {
        
    }

    public CharacterSO getCharacterSO()
    {
        return characterSO;
    }

    public GameObject getMainMissionCharacter()
    {
        return mainMissionCharacter;
    }
}
