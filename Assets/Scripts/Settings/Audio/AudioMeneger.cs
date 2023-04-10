using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMeneger : MonoBehaviour
{

    public PlaySound PlaySounds = new PlaySound();
    public PlayMusic PlayMusics;


    public static AudioMeneger instance = null;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
