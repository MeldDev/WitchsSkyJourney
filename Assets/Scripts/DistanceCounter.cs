using System.Collections;
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

    private void Start()
    {
        Initialize();
        LevelSettings.instance.OnStartLevel += () => { _currentDistance = 0; StartCoroutine(UpdateDistance()); };
        LevelSettings.instance.OnResumeLevel += () => StartCoroutine(UpdateDistance());
        LevelSettings.instance.OnFinishLevel += () => {StopCoroutine(UpdateDistance()); Save(); };
    }
    public void Initialize()
    {
        _maxDisnatnce = PlayerPrefs.GetFloat(KEY, 0);
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
        PlayerPrefs.SetFloat(KEY, _maxDisnatnce);
        PlayerPrefs.Save();
    }
}
