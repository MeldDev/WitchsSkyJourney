using System;
using UnityEngine;

public class BalanceBase : MonoBehaviour
{
    [SerializeField] private int _value;
    public int Value { get { return _value; } }

    public Action OnCurrencyChange;

    public void PlusCurrencyOnValue(int value)
    {
        _value += value;
        OnCurrencyChange?.Invoke();
    }
    public void MinusCurrencyOnValue(int value)
    {
        if (_value - value >= 0) _value -= value;
        else Debug.Log("Not enough gems");
        OnCurrencyChange?.Invoke();
    }
}
