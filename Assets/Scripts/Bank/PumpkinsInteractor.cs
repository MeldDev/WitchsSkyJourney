using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpkinsInteractor : MonoBehaviour
{
    public delegate void OnChangeCoins(float coins);
    public OnChangeCoins onChange;

    PumpkinsRepository coinsRepository;
    private void Start()
    {
        coinsRepository = new PumpkinsRepository();
        coinsRepository.Initialize();
    }

    public float GetCoinsValue()
    {
        return coinsRepository.Coins;
    }
    public void AddCoins(object sender,float value)
    {
        coinsRepository.Coins += value;
        coinsRepository.Save();
        onChange?.Invoke(coinsRepository.Coins);
    }
    public void SpendCoins(object sender, float value)
    {
        if (coinsRepository.Coins >= value)
        {
            coinsRepository.Coins -= value;
            coinsRepository.Save();
            onChange?.Invoke(coinsRepository.Coins);
        }
        else
        {
            Debug.Log("enough coins");
        }
    }
}
