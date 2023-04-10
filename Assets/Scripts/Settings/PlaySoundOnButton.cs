using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnButton : MonoBehaviour
{
    [SerializeField] private AudioClip m_AudioClip;
    private AudioSource m_AudioSource;
    void Start()
    {
        m_AudioSource = this.GetComponent<AudioSource>();    
    }
    public void PlaySound()
    {
        if (ApplicationSettings.instance.Sounds)
        {
            m_AudioSource.clip = m_AudioClip;
            m_AudioSource.Play();
        }
    }
    public void PlaySound(AudioClip clip)
    {
        if (ApplicationSettings.instance.Sounds)
        {
            m_AudioSource.clip = clip;
            m_AudioSource.Play();
        }
    }
}
