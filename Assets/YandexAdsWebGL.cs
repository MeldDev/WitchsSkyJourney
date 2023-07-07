using UnityEngine;
using System.Runtime.InteropServices;
using Unity.VisualScripting;

public class YandexAdsWebGL : MonoBehaviour
{
    bool musicPlay = true;
    [DllImport("__Internal")]
    private static extern void ShowRewardsAds();

    [DllImport("__Internal")]
    public static extern void ShowFullScreenAds();

    [SerializeField] GameObject _resumeGameClickPanel;

    public void ReviveRewardYandexAds()
    {
        Time.timeScale = 0;
        AudioListener.volume = 0;
        ShowRewardsAds();
    }

    public void FinishShowFullScreenAds()
    {
        Time.timeScale = 0;
        AudioListener.volume = 0;
        musicPlay = false;
        ShowFullScreenAds();
    }

    public void Rewarded()
    {
        _resumeGameClickPanel.SetActive(true);
    }
    private void OnApplicationFocus(bool focus)
    {
        if (focus && musicPlay)
        {
            Time.timeScale = 1;
            AudioListener.volume = 1;
        }
        else
        {
            Time.timeScale = 0;
            AudioListener.volume = 0;
        }
    }
    
    public void NoRewarded()
    {
        Time.timeScale = 1;
        AudioListener.volume = 1;
        musicPlay = true;
    }
}
