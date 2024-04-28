using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L1SolutionPlace5 : MonoBehaviour
{
    private const string FINALPLAYER = "Player";

    [SerializeField]
    private Transform character;

    private Transform lostPiece;

    private bool hasLostPiece = false;

    private const string FINALLOSTPIECE = "LostPiece";


    private void OnTriggerEnter(Collider other)
    {
        GameObject gObject = other.gameObject;
        if (gObject.tag == FINALPLAYER)
        {
            for (int i = 0; i < gObject.transform.childCount; i++)
            {
                if (gObject.transform.GetChild(i).tag == FINALLOSTPIECE)
                {
                    lostPiece = gObject.transform.GetChild(i);
                    hasLostPiece = true;
                    break;
                }
            }
            lostPiece.SetParent(transform);
            Transform problemBox = character.transform.GetChild(3);
            problemBox.gameObject.SetActive(false);
            character.GetComponent<L1Character>().IsMissionOver = true;
            enabled = false;
        }
    }
}
