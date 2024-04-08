using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L1SolutionPlace5 : MonoBehaviour
{
    private const string FINALPLAYER = "Player";


    private void OnTriggerEnter(Collider other)
    {
        GameObject gObject = other.gameObject;
        if (gObject.tag == FINALPLAYER)
        {
            gObject.transform.GetChild(4).SetParent(transform);
            GameObject character = gObject.GetComponent<L1Player>().getmissions()[0].MissionCharacter;
            Transform problemBox = character.transform.GetChild(3);
            problemBox.gameObject.SetActive(false);
            character.GetComponent<L1Character>().IsMissionOver = true;
            gObject.GetComponent<L1Player>().getmissions().RemoveAt(0);
            enabled = false;
        }
    }
}
