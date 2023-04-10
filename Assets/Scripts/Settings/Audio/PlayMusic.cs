using UnityEngine;

public class PlayMusic : MonoBehaviour
{
    [SerializeField] private AudioClip[] _musics;
    [SerializeField] private int _curMusic;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
    }
    public void StopMusic()
    {
        audioSource.Stop();
    }
    public void PlaySong()
    {
        if (ApplicationSettings.instance.Musics)
        {
            int NumberSong = -999;
            do
            {
                NumberSong = Random.Range(0, _musics.Length);
                audioSource.clip = _musics[NumberSong];
            }
            while (_curMusic == NumberSong);
            _curMusic = NumberSong;
            audioSource.Play();
        }
    }
    private void Update()
    {
        if (audioSource.isPlaying == false && ApplicationSettings.instance.Musics)
        {
            PlaySong();
        }
    }
}
