using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationSettings : MonoBehaviour
{
    public CustomToggle MusicsToggle;
    public bool Musics;
    public CustomToggle SoundsToggle;
    public bool Sounds;
    public CustomToggle VibrationToggle;
    public bool Vibration;
    public CustomToggle ShowFpsCounterToggle;
    public bool ShowFpsCounter;

    public string CurrentLanguage;
    public int CurrentQuality;

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

        Application.targetFrameRate = 240;
    }
    public void SetFPS(int value)
    {
        Application.targetFrameRate = value;
    }
    public void SetFpsCounter()
    {
        ShowFpsCounter = ShowFpsCounterToggle.IsOn;
    }
    public void SetMusics()
    {
        Musics = MusicsToggle.IsOn;
    }
    public void SetSounds()
    {
        Sounds = SoundsToggle.IsOn;
    }
    public void SetVibration()
    {
        Vibration = VibrationToggle.IsOn;
    }
    public void SetLanguage(string lang)
    {
        CurrentLanguage = lang;
    }
    public void SetQuality(int quality)
    {
        CurrentQuality = quality;
    }
}
