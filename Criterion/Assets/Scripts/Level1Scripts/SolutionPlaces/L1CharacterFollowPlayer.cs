using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L1CharacterFollowPlayer : L1Character
{
    
    protected override void onChoosed(object sender, GameInput.onChooseEventArgs e)
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
            base.startMission();
            transform.GetComponent<L1CharacterPlayerFollow>().IsFollow = true;    
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
    
}
