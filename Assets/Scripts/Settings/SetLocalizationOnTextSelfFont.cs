using UnityEngine;
using TMPro;
using static Localization;

public class SetLocalizationOnTextSelfFont : MonoBehaviour
{
    [SerializeField] string _key;
    [SerializeField] TMP_FontAsset[] _font;
    void Start()
    {
        SetString();
        Localization.Instance.localizationDelegate += SetString;
    }

    void SetString()
    {
        if (_key == "") return;
        var tuple = Localization.Instance.GetLocalization(_key);
        var tmp = this.GetComponent<TextMeshProUGUI>();
        tmp.text = tuple.Item2;
        tmp.font = _font[Localization.Instance.GetLanguage()];
    }
}
