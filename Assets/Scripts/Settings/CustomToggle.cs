using System;
using UnityEngine;

public class CustomToggle : MonoBehaviour
{
    public bool IsOn;

    [SerializeField] private GameObject isActivePanel;
    public Action OnChangeToggle;

    private void OnValidate()
    {
        OnChangeToggle?.Invoke();
        isActivePanel.SetActive(IsOn);
    }
    public void SetToggle(bool value)
    {
        if (!value)
            return;

        OnChangeToggle?.Invoke();
        IsOn = value;
        isActivePanel.SetActive(IsOn);
    }
    public void ChangeToggle()
    {
        OnChangeToggle?.Invoke();
        IsOn = !IsOn;
        isActivePanel.SetActive(IsOn);
    }

    public void OffToggle()
    {
        IsOn = false;
        isActivePanel.SetActive(false);
    }
}
