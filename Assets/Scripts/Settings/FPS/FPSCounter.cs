using UnityEngine;
using TMPro;
using System.Collections;
using Unity.VisualScripting;

public class FPSCounter : MonoBehaviour
{
    private TextMeshProUGUI fpsCounter;
    private void OnEnable()
    {

        fpsCounter = GetComponent<TextMeshProUGUI>();
        StartCoroutine(ShowFps());
    }
    private void OnDisable()
    {
        StopCoroutine(ShowFps());
    }
    IEnumerator ShowFps()
    {
        while (true)
        {
            fpsCounter.text = $"FPS: {(1.0f / Time.deltaTime).ToString("#")}";
            yield return new WaitForSeconds(0.5f);
        }
    }
}
