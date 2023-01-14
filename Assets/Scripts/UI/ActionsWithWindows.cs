using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionsWithWindows : MonoBehaviour
{
    [SerializeField] GameObject[] _windowsForClose;
    [SerializeField] GameObject[] _windowsForOpen;

    public void SetWindows(GameObject[] windowsForClose, GameObject[] windowsForOpen)
    {
        _windowsForClose = windowsForClose;
        _windowsForOpen = windowsForOpen;
    }
    public void DestroyThisObject()
    {
        Destroy(this.gameObject);
    }
    public void Action()
    {
        foreach (var item in _windowsForClose)
        {
            item.SetActive(false);
        }
        foreach (var item in _windowsForOpen)
        {
            item.SetActive(true);
        }
    }
}
