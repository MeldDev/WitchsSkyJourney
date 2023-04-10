using System;
using UnityEngine;

public class SettingSound : MonoBehaviour,ISetting
{
    private Action onSetSetting;

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
        ApplicationSettings.instance.Sounds = value;
        onSetSetting?.Invoke();
    }
    public void SetSetting()
    {
        Toggle.ChangeToggle();
        ApplicationSettings.instance.Sounds = Toggle.IsOn;
        onSetSetting?.Invoke();
    }
    public void FirstLoadSettings()
    {
        SetSetting(true);
    }
}
