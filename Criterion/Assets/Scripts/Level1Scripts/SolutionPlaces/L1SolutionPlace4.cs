using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L1SolutionPlace4 : MonoBehaviour
{
    private const string FINALCAR = "Car";

    private const string FINALJERRYCAN = "JerryCan";

    private Transform jerryCan;

    private bool hasPieces;
    private void OnTriggerEnter(Collider other)
    {
        GameObject gObject = other.gameObject;
        if(gObject.tag==FINALCAR)
        {
            for (int i = 0; i < gObject.transform.childCount; i++)
            {
                if (gObject.transform.GetChild(i).tag == FINALJERRYCAN)
                {
                    jerryCan = gObject.transform.GetChild(i);
                    hasPieces = true;
                    break;
                }
            }

            if(jerryCan.childCount>=2)
            {
                jerryCan.SetParent(transform);
                jerryCan.transform.localPosition = new Vector3(0f,1f,0f);
                Transform player = gObject.transform.GetChild(5);
                gObject.GetComponent<L1Car>().liveCar();
                gObject.transform.localRotation = Quaternion.Euler(0f, 90f, 0f);
                gObject.transform.localPosition = new Vector3(720f,0f,20f);
                GameObject character = player.GetComponent<L1Player>().getmissions()[0].MissionCharacter;
                Transform problemBox = character.transform.GetChild(3);
                problemBox.gameObject.SetActive(false);
                character.GetComponent<L1Character>().IsMissionOver = true;
                player.GetComponent<L1Player>().getmissions().RemoveAt(0);
                enabled = false;
            }
        }
    }
}
