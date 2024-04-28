using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L1GasTruck : L1Car
{
    private bool hasGas = false;

    private const string FINALGASSTATIONPOINT = "GasStationPoint";
    
    protected override void OnTriggerEnter(Collider other)
    {
        GameObject gObject = other.gameObject;

        if (gObject.tag == FINALPLAYER)
        {
            recognizePlayer();
        }
        else if(gObject.tag==FINALGASSTATIONPOINT)
        {
            if(!hasGas)
            {
                hasGas = true;
                enabled = false;
                transform.position = gObject.transform.position;
                transform.localRotation = Quaternion.Euler(0f, -180f, 0f);
                Invoke(nameof(waitForGas), 5f);
            }
        }
    }

    public bool HasGas
    {
        get { return hasGas; }
    }

    private void waitForGas()
    {
        enabled = true;
    }
}
