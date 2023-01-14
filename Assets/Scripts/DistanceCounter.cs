using System.Collections;
using UnityEngine;

public class DistanceCounter : MonoBehaviour
{
    [SerializeField] private float _maxDisnatnce;
    public float MaxDisnatnce { get { return _maxDisnatnce; } }

    [SerializeField] private float _currentDistance;
    public float CurrentDistance { get { return _currentDistance; } }

    public delegate void UpdateDistanceDelegate_();
    public UpdateDistanceDelegate_ UpdateDistanceDelegate;

    private void Start()
    {
        LevelSettings.instance.StartLevelDelegate += () => { _currentDistance = 0; StartCoroutine(UpdateDistance()); };
        LevelSettings.instance.ResumeLevelDelegate += () => StartCoroutine(UpdateDistance());
        LevelSettings.instance.FinishLevelDelegate += () => StopCoroutine(UpdateDistance());
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
}
