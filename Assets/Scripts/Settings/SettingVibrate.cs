using System;
using UnityEngine;

public class SettingVibrate : MonoBehaviour, ISetting
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
        ApplicationSettings.instance.Vibration = value;
        onSetSetting?.Invoke();
    }
    public void SetSetting()
    {
        Toggle.ChangeToggle();
        ApplicationSettings.instance.Vibration = Toggle.IsOn;
        onSetSetting?.Invoke();
    }
    public void FirstLoadSettings()
    {
        SetSetting(true);
    }
}
