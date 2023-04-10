using System;
using UnityEngine;

public class SettingFPS : MonoBehaviour, ISetting
{
    public CustomToggle Toggle;
    [SerializeField] private int _countFPS;

    private Action onSetSetting;

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
            Application.targetFrameRate = _countFPS;
            Debug.Log($"SetUp setting: FPS_MAX: {_countFPS}");
        }
        onSetSetting?.Invoke();
    }
    public void SetSetting()
    {
        if (Toggle.IsOn) { return; }
        Toggle.SetToggle(!Toggle.IsOn);
        if (Toggle.IsOn)
        {
            Application.targetFrameRate = _countFPS;
        }
        Debug.Log(_countFPS);
        onSetSetting?.Invoke();
    }
    public void FirstLoadSettings()
    {
        if (_countFPS>200)
            SetSetting(true);
        else 
            SetSetting(false);
    }
}
