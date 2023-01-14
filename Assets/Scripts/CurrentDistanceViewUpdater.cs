using UnityEngine;
using TMPro;
public class CurrentDistanceViewUpdater : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _currentDistanceText;
    [SerializeField] private TextMeshProUGUI _maxDistanceText;
    private DistanceCounter distanseCounter;
    private void Start()
    {
        distanseCounter = GameObject.FindObjectOfType<DistanceCounter>();
        distanseCounter.UpdateDistanceDelegate += UpdateText;
        UpdateText();
    }
    private void UpdateText()
    {
        _currentDistanceText.text = (distanseCounter.CurrentDistance * 10).ToString("0" + "m");
        _maxDistanceText.text = (distanseCounter.MaxDisnatnce * 10).ToString("0" + "m");
    }
}
