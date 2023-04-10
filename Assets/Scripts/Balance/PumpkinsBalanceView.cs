using UnityEngine;
using TMPro;

public class PumpkinsBalanceView : MonoBehaviour
{
    [SerializeField] private PumpkinsBalance _pumpkinsBalance;
    [SerializeField] private TextMeshProUGUI _pumpkinsBalanceTextMesh;
    void Start()
    {
        _pumpkinsBalance.onChange += UpdateView;
        UpdateView(_pumpkinsBalance.Pumpkins);
    }
    private void UpdateView(int value)
    {
        _pumpkinsBalanceTextMesh.text = value.ToString();
    }
}
