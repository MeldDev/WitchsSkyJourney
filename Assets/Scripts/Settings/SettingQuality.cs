using System;
using System.Reflection;
using UnityEngine;

public class SettingQuality : MonoBehaviour, ISetting
{
    public CustomToggle Toggle;
    [SerializeField] private int _indexQualityLevel;

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
            QualitySettings.SetQualityLevel(_indexQualityLevel, true);
            Debug.Log($"SetUp setting: QUALITY: {QualitySettings.names[QualitySettings.GetQualityLevel()]}");
        }
        onSetSetting?.Invoke();
    }
    public void SetSetting()
    {
        if (Toggle.IsOn) { return; }
        Toggle.SetToggle(!Toggle.IsOn);
        if (Toggle.IsOn)
        {
            QualitySettings.SetQualityLevel(_indexQualityLevel, true);
            Debug.Log($"SetUp setting: QUALITY: {QualitySettings.names[QualitySettings.GetQualityLevel()]}");
        }
        onSetSetting?.Invoke();
    }
    public void FirstLoadSettings()
    {
        if (_indexQualityLevel == 2)
        {
            SetSetting();
        }
    }
}
