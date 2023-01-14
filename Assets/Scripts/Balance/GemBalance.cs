using UnityEngine;
using TMPro;

public class GemBalance : BalanceBase
{

    public static GemBalance instance = null;
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
