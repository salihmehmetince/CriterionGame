using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L1LostSubmarinePieces : MonoBehaviour
{
    private const string FINALPLAYER = "Player";

    private const string FINALPIECES = "Pieces";

    private bool hasPieces = false;

    private Transform pieces;

    private void OnTriggerEnter(Collider other)
    {
        GameObject gObject = other.gameObject;
        if(gObject.tag==FINALPLAYER)
        {
            for(int i=0;i<gObject.transform.childCount;i++)
            {
                if(gObject.transform.GetChild(i).tag == FINALPIECES)
                {
                    pieces = gObject.transform.GetChild(i);
                    hasPieces = true;
                    break;
                }
            }
            if(hasPieces)
            {
                transform.SetParent(pieces.transform);
            }else
            {
                GameObject pieces = new GameObject();
                pieces.name = "Pieces";
                pieces.tag = "Pieces";
                pieces.transform.SetParent(gObject.transform);
            }
        }
    }
}
