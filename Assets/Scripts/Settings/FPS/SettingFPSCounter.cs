using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingFPSCounter : MonoBehaviour, ISetting
{
    private Action onSetSetting;
    [SerializeField] private GameObject _fpsCounter;

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
            _fpsCounter.SetActive(value);
        }
        onSetSetting?.Invoke();
    }
    public void SetSetting()
    {
        Toggle.ChangeToggle();
        _fpsCounter.SetActive(Toggle.IsOn);
        onSetSetting?.Invoke();
    }
    public void FirstLoadSettings()
    {
        SetSetting(false);
    }
}
