using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L1SpecialCar : L1Car
{
    private bool canDriveSpecialCar = false;

    public override void enterCar()
    {
        if(canDriveSpecialCar)
        {
            base.enterCar();
        }
    }

    public bool CanDriveSpecialCar
    {
        get { return canDriveSpecialCar; }
        set { canDriveSpecialCar = value; }
    }

}
