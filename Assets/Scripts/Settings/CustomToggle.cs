using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomToggle : MonoBehaviour
{
    [SerializeField] private bool isOn;
    public bool IsOn { get { return isOn; } }

    [SerializeField] private GameObject isActivePanel;
    public delegate void ChangeToggleDelegate_();
    public ChangeToggleDelegate_ ChangeToggleDelegate;

    private void OnValidate()
    {
        ChangeToggleDelegate?.Invoke();
        isActivePanel.SetActive(isOn);
    }

    public void ChangeToggle()
    {
        ChangeToggleDelegate?.Invoke();
        isOn = !isOn;
        isActivePanel.SetActive(isOn);
    }

    public void OffToggle()
    {
        isOn = false;
        isActivePanel.SetActive(false);
    }
}
