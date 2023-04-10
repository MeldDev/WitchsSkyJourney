using UnityEngine;
using TMPro;

public class SetLocalizationOnText : MonoBehaviour
{
    [SerializeField] string _key;
    void Start()
    {
        SetString();
        ApplicationSettings.instance.Localizations.localizationDelegate += SetString;
    }

    void SetString()
    {
        if (_key == "") return;
        var tuple = ApplicationSettings.instance.Localizations.GetLocalization(_key);
        var tmp = this.GetComponent<TextMeshProUGUI>();
        tmp.font = tuple.Item1;
        tmp.text = tuple.Item2;
    }
}
