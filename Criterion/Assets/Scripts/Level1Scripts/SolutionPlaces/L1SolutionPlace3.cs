using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class L1SolutionPlace3 : MonoBehaviour
{
    private const string FINALPLAYER = "Player";

    private const string FINALPIECES = "Pieces";

    private bool hasPieces = false;

    private Transform pieces;
    private void OnTriggerEnter(Collider other)
    {
        GameObject gObject = other.gameObject;

            if (gObject.tag == FINALPLAYER)
            {
                for (int i = 0; i < gObject.transform.childCount; i++)
                {
                    if (gObject.transform.GetChild(i).tag == FINALPIECES)
                    {
                        pieces = gObject.transform.GetChild(i);
                        hasPieces = true;
                        break;
                    }
                }

                if (hasPieces)
                {
                    if(pieces.transform.childCount>=3)
                    {
                    
                        pieces.SetParent(gObject.GetComponent<L1Player>().getmissions()[0].MissionCharacter.transform);
                        Transform character = gObject.GetComponent<L1Player>().getmissions()[0].MissionCharacter.transform;
                        Transform problemBox = character.transform.GetChild(3);
                        problemBox.gameObject.SetActive(false);
                        character.GetComponent<L1Character>().IsMissionOver = true;
                        gObject.GetComponent<L1Player>().getmissions().RemoveAt(0);
                        enabled = false;
                        Debug.Log("success");
                    }
                    else
                    {
                        Debug.Log("olmadý");
                    }
                }

        }
    }
}
