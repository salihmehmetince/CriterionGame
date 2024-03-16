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
    private void OnTriggerEnter(Collider other)
    {
        GameObject gObject=other.gameObject;

        if(gObject.tag== FINALPLAYER)
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
}
