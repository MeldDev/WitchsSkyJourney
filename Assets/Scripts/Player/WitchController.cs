using System;
using UnityEngine;
using Spine.Unity;

public class WitchController : MonoBehaviour, IClickable
{
    [SerializeField] SkeletonAnimation _skeletonAnimation;
    [SerializeField] AnimationReferenceAsset _tapToFly;

    [SerializeField] private Transform _heroTransform;
    [SerializeField] private Rigidbody2D _heroRigidBody;
    [SerializeField] private float _speedFlyingHero;

    [SerializeField] private GameObject _tapToPlayPanel;
    [SerializeField] private GameObject _tapToResumePanel;

    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _flySoundAudioClip;

    private void Start()
    {
        GameObject.FindObjectOfType<StartLevelPanel>().SetWitchGM(this.gameObject);
        LevelSettings.instance.OnFinishLevel += DestroyObj;
    }

    void DestroyObj()
    {
        LevelSettings.instance.OnFinishLevel -= DestroyObj;
        Destroy(this.gameObject);
    }
    public void Interact()
    {
        if (!LevelSettings.instance.GameState) LevelSettings.instance.StartLevel();
        _heroRigidBody.gravityScale = 2;
        _heroRigidBody.AddForce(new Vector2(0, 700));
        _heroRigidBody.velocity = Vector2.zero;
        CallVibrate();

        AudioMeneger.instance.PlaySounds.PlaySounds(_audioSource, _flySoundAudioClip);

        _skeletonAnimation.AnimationState.SetAnimation(1,_tapToFly, false);
    }
    void CallVibrate() { 
        if (ApplicationSettings.instance.Vibration)
            Vibration.Vibrate(75); 
    }
} 
