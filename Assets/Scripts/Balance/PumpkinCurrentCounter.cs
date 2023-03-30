using UnityEngine;
using TMPro;

public class PumpkinCurrentCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _PumpkinCounterTMP;
    [SerializeField] private int _PumpkinCounterValue;
    [SerializeField] private GameObject _PumpkinCounter;
    private void Start()
    {
        LevelSettings.instance.OnStartLevel += StartCounter;
        GemBalance.instance.OnCurrencyChange += UpdateCounter;
        StartCounter();
    }
    void StartCounter()
    {
        _PumpkinCounter.SetActive(false);
        _PumpkinCounterValue = 0;
        _PumpkinCounterTMP.text = _PumpkinCounterValue.ToString();
    }
    void UpdateCounter()
    {
        _PumpkinCounter.SetActive(true);
        _PumpkinCounterValue += 1;
        _PumpkinCounterTMP.text = _PumpkinCounterValue.ToString();
    }
}
