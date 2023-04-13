using System;
using UnityEngine;

public class LevelSettings: MonoBehaviour
{
    [SerializeField] private int showAds = 0;
    [SerializeField] private YandexAdsWebGL _yandexAds; 


    [SerializeField] private GameObject _witchPrefab;
    [SerializeField] private Transform _startPosition;


    [SerializeField] private GameObject _losePanel;

    public bool GameState = false;
    public bool IsPause = false;

    public static LevelSettings instance = null;

    public Action OnStartLevel;
    public Action OnFinishLevel;
    public Action OnResumeLevel;
    public Action OnLoadMeinMenu;
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
        LoadMainMenu();
    }

    public void LoadMainMenu()
    {
        ShowFullAdsAds();

        GameState = false;
        IsPause = false;
        Instantiate(_witchPrefab, _startPosition.transform.position, Quaternion.identity);


        OnLoadMeinMenu?.Invoke();
        Debug.Log("Load Main Menu");
    }
    public void StartLevel()
    {
        GameState = true;
        IsPause = false;
        OnStartLevel?.Invoke();
        Debug.Log("Start Level");
    }
    public void FinishLevel()
    {

        //LoseMenu
        GameState = false;
        IsPause = true;
        _losePanel.SetActive(true);


        OnFinishLevel?.Invoke();
        Debug.Log("Finish Level");

    }

    public void ResumetLevel()
    {
        GameState = true;
        IsPause = false;
        var gm = Instantiate(_witchPrefab, _startPosition.transform.position, Quaternion.identity).GetComponent<WitchController>();
        gm.Interact();
        OnResumeLevel?.Invoke();
        Debug.Log("Resume Level");
    }
    public void ShowRewardedAds()
    {
        _yandexAds.ReviveRewardYandexAds();
        //_yandexAds.Rewarded();
    }    
    public void ShowFullAdsAds()
    {
        showAds++;
        if (showAds >= 3)
        {
            showAds = 0;
            _yandexAds.FinishShowFullScreenAds();
        }
    }
}
