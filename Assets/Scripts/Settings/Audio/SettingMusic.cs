using System;
using UnityEngine;

public class SettingMusic : MonoBehaviour, ISetting
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
        ApplicationSettings.instance.Musics = value;
        onSetSetting?.Invoke();
    }
    public void SetSetting()
    {
        Toggle.ChangeToggle();
        ApplicationSettings.instance.Musics = Toggle.IsOn;

        if (!ApplicationSettings.instance.Musics)
            AudioMeneger.instance.PlayMusics.StopMusic();

        onSetSetting?.Invoke();
    }

    public void FirstLoadSettings()
    {
        SetSetting(true);
    }
}
