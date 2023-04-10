using UnityEngine;

public class PlaySound
{
    public void PlaySounds(AudioSource audioSource ,AudioClip sound)
    {
        if (ApplicationSettings.instance.Sounds)
        {
            audioSource.clip = sound;
            audioSource.Play();
        }
    }
}
