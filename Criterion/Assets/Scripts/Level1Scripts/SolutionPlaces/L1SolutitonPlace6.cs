using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L1SolutitonPlace6 : MonoBehaviour
{
    private const string FINALPLAYER = "Player";

    private const string FINALTOOLBOX = "Toolbox";

    private void OnTriggerEnter(Collider other)
    {
        GameObject gObject = other.gameObject;
        if (gObject.tag == FINALPLAYER)
        {
            for(int i=0;i<gObject.transform.childCount;i++)
            {
                if(gObject.transform.GetChild(i).tag == FINALTOOLBOX)
                {
                    Transform toolbox = gObject.transform.GetChild(i);
                    toolbox.SetParent(transform);
                    toolbox.localPosition = new Vector3(0f, 1f, 0f);
                    //gObject.transform.GetChild(4).SetParent(transform);
                    GameObject character = gObject.GetComponent<L1Player>().getmissions()[0].MissionCharacter;
                    Transform problemBox = character.transform.GetChild(3);
                    problemBox.gameObject.SetActive(false);
                    character.GetComponent<L1Character>().IsMissionOver = true;
                    enabled = false;
                    break;
                }
            }
        }
    }
}
