using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLevelPanel : MonoBehaviour
{
    [SerializeField] private IClickable _witchController;

    public void SetWitchGM(GameObject witch)
    {
        _witchController = witch.GetComponent<IClickable>();
    }
    public void Click()
    {
        _witchController.Interact();
    }
}
