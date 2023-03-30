using UnityEngine;
using TMPro;

public class GemBalanceViewUpdate : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _gemBalanceText;
    private void Start()
    {
        GemBalance.instance.OnCurrencyChange += UpdateBalanceInformation;
        UpdateBalanceInformation();
    }

    private void UpdateBalanceInformation()
    {
        _gemBalanceText.text = GemBalance.instance.Value.ToString();
    }

}
