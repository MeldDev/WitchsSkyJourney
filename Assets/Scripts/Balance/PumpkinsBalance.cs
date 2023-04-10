using System;
using UnityEngine;

public class PumpkinsBalance : MonoBehaviour
{
    public const string KEY = "PumpkinsRep";
    public int Pumpkins;
    public Action<int> onChange;
    private void Start()
    {
        Initialize();
    }
    public void Initialize()
    {
        Pumpkins = PlayerPrefs.GetInt(KEY, 0);
        onChange?.Invoke(Pumpkins);
    }
    public void Save()
    {
        PlayerPrefs.SetInt(KEY, Pumpkins);
        PlayerPrefs.Save();
    }
    public void AddCoins(object sender, int value)
    {
        Pumpkins += value;
        Save();
        onChange?.Invoke(Pumpkins);
    }
    public void SpendCoins(object sender, int value)
    {
        if (Pumpkins >= value)
        {
            Pumpkins -= value;
            Save();
            onChange?.Invoke(Pumpkins);
        }
        else
        {
            Debug.Log("enough coins");
        }
    }
}
