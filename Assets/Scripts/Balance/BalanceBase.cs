using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalanceBase : MonoBehaviour
{
    [SerializeField] private int _value;
    public int Value { get { return _value; } }

    public delegate void CurrencyDelegate_();
    public CurrencyDelegate_ CurrencyDelegate;

    public void PlusCurrencyOnValue(int value)
    {
        _value += value;
        CurrencyDelegate?.Invoke();
    }
    public void MinusCurrencyOnValue(int value)
    {
        if (_value - value >= 0) _value -= value;
        else Debug.Log("Not enough gems");
        CurrencyDelegate?.Invoke();
    }
}
