using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L1FruitTruck :L1Car
{
    private bool isFull = false;

    public bool IsFull
    {
        get
        {
            return isFull;
        }

        set
        {
            isFull = value;
        }
    }

    protected override void drive()
    {
        if(isFull)
        {
            base.drive();
        }
    }

}
