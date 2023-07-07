using System;
using System.Collections;
using System.Diagnostics;
using System.Runtime.InteropServices;
using UnityEngine;

public class DistanceCounter : MonoBehaviour
{
    public const string KEY = "DistanceCounter";
    [SerializeField] private float _maxDisnatnce;
    public float MaxDisnatnce { get { return _maxDisnatnce; } }

    [SerializeField] private float _currentDistance;
    public float CurrentDistance { get { return _currentDistance; } }

    public delegate void UpdateDistanceDelegate_();
    public UpdateDistanceDelegate_ UpdateDistanceDelegate;

    [DllImport("__Internal")]
    public static extern void LoadDistanceExtern();

    [DllImport("__Internal")]
    public static extern void SaveDistanceExtern(string data);

    private void Start()
    {
        Initialize();
        LevelSettings.instance.OnStartLevel += () => { _currentDistance = 0; StartCoroutine(UpdateDistance());};
        LevelSettings.instance.OnResumeLevel += () => StartCoroutine(UpdateDistance());
        LevelSettings.instance.OnFinishLevel += () => {StopCoroutine(UpdateDistance()); Save();};
    }
    public void Initialize()
    {

        #if UNITY_WEBGL
                LoadDistanceExtern();
        #else
                _maxDisnatnce = PlayerPrefs.GetFloat(KEY, 0);
                UpdateDistanceDelegate?.Invoke();
        #endif

    }
    public void LoadDistance(string data)
    {
        var _data = JsonUtility.FromJson<DistanceSave>(data);

        _maxDisnatnce = _data.maxDistance;
        UpdateDistanceDelegate?.Invoke();
    }
    private IEnumerator UpdateDistance()
    {
        while (true && LevelSettings.instance.GameState)
        {
            yield return new WaitForFixedUpdate();
            UpdateDistance(Time.deltaTime);
        }

    }

    private void UpdateDistance(float count)
    {
        _currentDistance += count * 10;
        if (_currentDistance > _maxDisnatnce)
        {
            _maxDisnatnce = _currentDistance;
        }
        UpdateDistanceDelegate?.Invoke();
    }
    public void Save()
    {

#if UNITY_WEBGL
        DistanceSave distanceSave = new DistanceSave();
        distanceSave.maxDistance = _maxDisnatnce;
        var jsonDistance = JsonUtility.ToJson(distanceSave);
        SaveDistanceExtern(jsonDistance);
        UnityEngine.Debug.Log("ataSaved");
#else
            PlayerPrefs.SetFloat(KEY, _maxDisnatnce);
            PlayerPrefs.Save();
#endif
    }
}
[Serializable]
class DistanceSave
{
    public float maxDistance;
}
