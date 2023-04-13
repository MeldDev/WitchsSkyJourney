using UnityEngine;
using System.Runtime.InteropServices;
public class YandexAdsWebGL : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void ShowRewardsAds();

    [DllImport("__Internal")]
    public static extern void ShowFullScreenAds();

    [SerializeField] GameObject _resumeGameClickPanel;

    public void ReviveRewardYandexAds()
    {
        Time.timeScale = 0;
        ShowRewardsAds();
    }

    public void FinishShowFullScreenAds()
    {
        Time.timeScale = 0;
        ShowFullScreenAds();
    }

    public void Rewarded()
    {
        _resumeGameClickPanel.SetActive(true);
    }
    public void NoRewarded()
    {
        Time.timeScale = 1;
    }
}
