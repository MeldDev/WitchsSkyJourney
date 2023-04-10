using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuChanger : MonoBehaviour
{
    [SerializeField] GameObject[] _mainMenu;
    [SerializeField] GameObject[] _playMenu;
    void Start()
    {
        LevelSettings.instance.OnLoadMeinMenu += ChangeMenu;
        LevelSettings.instance.OnStartLevel += ChangeMenu;
    }

    void ChangeMenu()
    {

        if (LevelSettings.instance.GameState)
        {
            foreach (var item in _mainMenu)
            {
                item.SetActive(false);
            }
            foreach (var item in _playMenu)
            {
                item.SetActive(true);
            }
        }
        else
        {
            foreach (var item in _mainMenu)
            {
                item.SetActive(true);
            }
            foreach (var item in _playMenu)
            {
                item.SetActive(false);
            }
        }
    }
}
