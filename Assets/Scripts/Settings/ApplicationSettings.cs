using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ApplicationSettings : MonoBehaviour
{
    public Localization Localizations;
    [SerializeField] private ISetting[] _allSettings;
    [SerializeField] private GameObject[] _allSettingsObj;
    private const string KEY = "APLICATION_SETTINGS";
    private SaveSettings saveSettings = new SaveSettings();

    //public PlayMusic PlayMusics;
    public bool Musics;
    public PlaySound PlaySounds;
    public bool Sounds;
    public CustomToggle VibrationToggle;
    public bool Vibration;
    public CustomToggle ShowFpsCounterToggle;
    public bool ShowFpsCounter;


    public static ApplicationSettings instance = null;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        //_allSettings = Resources.FindObjectsOfTypeAll(typeof(ISetting)) as ISetting[];
        var d = new List<ISetting>();
        foreach (var item in _allSettingsObj)
        {
            d.Add(item.GetComponent<ISetting>());
        }
        _allSettings = d.ToArray();
        Debug.Log(_allSettings.Length);
        LoadSave();
        foreach (var setting in _allSettings)
        {
            setting.AddOnSetSetting(SaveAllSettings);
        }
    }

    void LoadSave()
    {
        if (PlayerPrefs.HasKey(KEY))
        {
            saveSettings = JsonUtility.FromJson<SaveSettings>(PlayerPrefs.GetString(KEY));

            for (int i = 0; i < _allSettings.Length; i++)
            {
                _allSettings[i].SetSetting(saveSettings._allBoolSettings[i]);
            }
        }
        else
        {
            for (int i = 0; i < _allSettings.Length; i++)
            {
                _allSettings[i].FirstLoadSettings();
            }
        }
    }
    public void SaveAllSettings()
    {
        var listBool = new List<bool>();
        foreach (var item in _allSettings)
        {
            listBool.Add(item.GetSetting());
        }
        saveSettings._allBoolSettings = listBool.ToArray();

        foreach (var item in saveSettings._allBoolSettings)
        {
            Debug.Log(item);
        }

        PlayerPrefs.SetString(KEY, JsonUtility.ToJson(saveSettings));
        PlayerPrefs.Save();
    }
}
[Serializable]
class SaveSettings
{
    public bool[] _allBoolSettings;
}
