using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateTransition : MonoBehaviour
{
    [SerializeField] GameObject[] _windowsForClose;
    [SerializeField] GameObject[] _windowsForOpen;
    [SerializeField] private GameObject _transitionPrefab;
    [SerializeField] private GameObject _transitionPanel;

    public void DoTransition()
    {
        var item = Instantiate(_transitionPrefab, _transitionPanel.transform).GetComponent<ActionsWithWindows>();
        item.SetWindows(_windowsForClose, _windowsForOpen);
        item.GetComponent<Animation>().Play();
    }
}
