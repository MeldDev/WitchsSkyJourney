using System;
using UnityEngine;

public class SettingSetLang : MonoBehaviour, ISetting
{
    [SerializeField] private int _lang;

    Action onSetSetting;

    public CustomToggle Toggle;

    public void AddOnSetSetting(Action handler)
    {
        onSetSetting += handler;
    }

    public void RemoveOnSetSetting(Action handler)
    {
        onSetSetting -= handler;
    }

    public bool GetSetting()
    {
        return Toggle.IsOn;
    }

    public void SetSetting(bool value)
    {
        Toggle.SetToggle(value);
        if (value)
        {
            ApplicationSettings.instance.Localizations.SetLanguage(_lang);
        }
        onSetSetting?.Invoke();
    }
    public void SetSetting()
    {
        if (Toggle.IsOn) { return; }
        Toggle.SetToggle(!Toggle.IsOn);
        if (Toggle.IsOn)
        {
            ApplicationSettings.instance.Localizations.SetLanguage(_lang);
        }
        onSetSetting?.Invoke();
    }

    public void FirstLoadSettings()
    {
        if (_lang == 1)
        {
            SetSetting(true);
        }
    }
}
