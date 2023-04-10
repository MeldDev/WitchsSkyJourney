using System;

interface ISetting
{
    void AddOnSetSetting(Action handler);
    void RemoveOnSetSetting(Action handler);
    public void SetSetting(bool value);
    public void SetSetting();
    public bool GetSetting();
    public void FirstLoadSettings();
}