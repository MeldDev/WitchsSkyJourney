using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class OpenURL : MonoBehaviour
{
    [SerializeField] private string _url;

    [SerializeField] private Button button;

    private void OnEnable()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OpenUrl);
    }
    private void OnDisable()
    {
        button.onClick.RemoveListener(OpenUrl);
    }
    public void OpenUrl()
    {
            Application.OpenURL(_url);
            UnityEngine.Debug.Log($"Open link: {_url}");
    }
}
