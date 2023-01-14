using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalanceBase : MonoBehaviour
{
    [SerializeField] private int currency;
    public int Currency { get { return currency; } }

    public delegate void CurrencyDelegate_();
    public CurrencyDelegate_ CurrencyDelegate;

    public void PlusCurrencyOnValue(int value)
    {
        currency += value;
        CurrencyDelegate?.Invoke();
    }
    public void MinusCurrencyOnValue(int value)
    {
        if (currency - value >= 0) currency -= value;
        else Debug.Log("Not enough gems");
        CurrencyDelegate?.Invoke();
    }
}
