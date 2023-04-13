using UnityEngine;

public class LosePanel : MonoBehaviour
{
    public void ResumeLevel()
    {
        LevelSettings.instance.ShowRewardedAds();
        this.gameObject.SetActive(false);
    }
    public void SkipLevel()
    {
        LevelSettings.instance.LoadMainMenu();
        this.gameObject.SetActive(false);
    }
}
    