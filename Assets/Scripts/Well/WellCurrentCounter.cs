using UnityEngine;
using TMPro;

public class WellCurrentCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _wellCounterTMP;
    [SerializeField] private int _wellCounterValue;
    [SerializeField] private GameObject _wellCounter;
    private void Start()
    {
        LevelSettings.instance.OnStartLevel += StartCounter;
        WellBalance.instance.OnCurrencyChange += UpdateCounter;
        StartCounter();
    }
    void StartCounter()
    {
        _wellCounter.SetActive(false);
        _wellCounterValue = 0;
        _wellCounterTMP.text = _wellCounterValue.ToString();
    }
    void UpdateCounter()
    {
        _wellCounter.SetActive(true);
        _wellCounterValue += 1;
        _wellCounterTMP.text = _wellCounterValue.ToString();
    }
}
