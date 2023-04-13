using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestYandexAds : MonoBehaviour
{
    [SerializeField] private YandexMobileAdsInterstitialDemoScript yandexMobileAdsInterstitialDemoScript;
    [SerializeField] private YandexMobileAdsRewardedAdDemoScript yandexMobileAdsRewardedAdDemoScript;

    void Update()
    {
        if (Input.GetKey(KeyCode.O))
        {
            yandexMobileAdsInterstitialDemoScript.RequestInterstitial();
        }
        if (Input.GetKey(KeyCode.I))
        {
            yandexMobileAdsInterstitialDemoScript.ShowInterstitial();
        }
        if (Input.GetKey(KeyCode.E))
        {
            yandexMobileAdsRewardedAdDemoScript.RequestRewardedAd();
        }
        if (Input.GetKey(KeyCode.R))
        {
            yandexMobileAdsRewardedAdDemoScript.ShowRewardedAd();
        }
    }
}
