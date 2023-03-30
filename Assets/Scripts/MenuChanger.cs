using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuChanger : MonoBehaviour
{
    [SerializeField] GameObject _mainMenu;
    [SerializeField] GameObject _playMenu;
    void Start()
    {
        LevelSettings.instance.OnLoadMeinMenu += ChangeMenu;
        LevelSettings.instance.OnStartLevel += ChangeMenu;
    }

    void ChangeMenu()
    {

        if (LevelSettings.instance.GameState)
        {
            _mainMenu.SetActive(false);
            _playMenu.SetActive(true);
        }
        else
        {
            _mainMenu.SetActive(true);
            _playMenu.SetActive(false);
        }
    }
}
