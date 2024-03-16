using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class L1Player : MonoBehaviour
{
    private const string FINALCHARACTER = "Character";

    private bool canInteract = false;


    [SerializeField]
    private GameInput gameInput;

    private CharacterSO characterSO;

    private void OnTriggerEnter(Collider other)
    {
        GameObject gObject = other.gameObject;
        if (gObject.tag == FINALCHARACTER)
        {
            recognizeCharacter(gObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        forgetCharacter();
    }

    private void Start()
    {
        gameInput.onInteract += onInteracted;
    }

    private void onInteracted(object sender, EventArgs e)
    {
        handleInteraction();
    }

    private void handleInteraction()
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
        canInteract = true;
        this.characterSO = gObject.GetComponent<L1Character>().getCharacterSO();
    }
    private void forgetCharacter()
    {
        canInteract = false;
        Transform canvas = transform.GetChild(3);
        canvas.gameObject.SetActive(false);
    }
}
