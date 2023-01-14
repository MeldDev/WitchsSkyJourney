using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMeneger : MonoBehaviour
{

    [SerializeField] private AudioSource _sounds;
    [SerializeField] private AudioSource _music;


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
