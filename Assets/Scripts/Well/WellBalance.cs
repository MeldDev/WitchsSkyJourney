using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WellBalance : BalanceBase
{
    public static WellBalance instance = null;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance == this)
        {
            Destroy(gameObject);
        }
    }
}
