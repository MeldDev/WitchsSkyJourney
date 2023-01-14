using UnityEngine;

public class LevelSettings: MonoBehaviour
{
    [SerializeField] private GameObject _witchPrefab;
    [SerializeField] private Transform _startPosition;


    [SerializeField] private GameObject _losePanel;

    public bool GameState = false;
    public bool IsPause = false;

    public static LevelSettings instance = null;

    public delegate void StartLevelDelegate_();
    public StartLevelDelegate_ StartLevelDelegate;
    public delegate void FinishLevelDelegate_();
    public FinishLevelDelegate_ FinishLevelDelegate;
    public delegate void ResumeLevelDelegate_();
    public ResumeLevelDelegate_ ResumeLevelDelegate;
    public delegate void LoadMeinMenuDelegate_();
    public LoadMeinMenuDelegate_ LoadMeinMenuDelegate;
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
        GameState = false;
        IsPause = false;
        Instantiate(_witchPrefab, _startPosition.transform.position, Quaternion.identity);


        LoadMeinMenuDelegate?.Invoke();
        Debug.Log("Load Main Menu");
    }
    public void StartLevel()
    {
        GameState = true;
        IsPause = false;
        StartLevelDelegate?.Invoke();
        Debug.Log("Start Level");
    }
    public void FinishLevel()
    {
        //LoseMenu
        GameState = false;
        IsPause = true;
        _losePanel.SetActive(true);


        FinishLevelDelegate?.Invoke();
        Debug.Log("Finish Level");

    }

    public void ResumetLevel()
    {
        GameState = true;
        IsPause = false;
        Instantiate(_witchPrefab, _startPosition.transform.position, Quaternion.identity);

        ResumeLevelDelegate?.Invoke();
        Debug.Log("Resume Level");
    }
}
