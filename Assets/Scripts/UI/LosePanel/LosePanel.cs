using UnityEngine;

public class LosePanel : MonoBehaviour
{
    public void ResumeLevel()
    {
        LevelSettings.instance.ResumetLevel();
        this.gameObject.SetActive(false);
    }
    public void SkipLevel()
    {
        LevelSettings.instance.LoadMainMenu();
        this.gameObject.SetActive(false);
        Vibration.Vibrate(new long[] {100L, 200L},2);
    }
}
    