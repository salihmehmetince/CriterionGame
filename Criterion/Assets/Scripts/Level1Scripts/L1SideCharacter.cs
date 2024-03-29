using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L1SideCharacter : MonoBehaviour
{
    [SerializeField]
    private CharacterSO characterSO;

    private const string FINALPLAYER = "Player";

    [SerializeField]
    private GameInput gameInput;


    // Start is called before the first frame update
    void Start()
    {
        gameInput.onChoose += onChoosed;
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
    void Update()
    {
        
    }

    public CharacterSO getCharacterSO()
    {
        return characterSO;
    }
}
