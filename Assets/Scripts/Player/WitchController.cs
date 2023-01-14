using System;
using UnityEngine;

public class WitchController : MonoBehaviour, IClickable
{
    [SerializeField] private Transform _heroTransform;
    [SerializeField] private Rigidbody2D _heroRigidBody;
    [SerializeField] private float _speedFlyingHero;

    [SerializeField] private GameObject _tapToPlayPanel;
    [SerializeField] private GameObject _tapToResumePanel;

    private void Start()
    {
        GameObject.FindObjectOfType<StartLevelPanel>().SetWitchGM(this.gameObject);
        /*        LevelSettings.instance.LoadMeinMenuDelegate += () => _tapToPlayPanel.SetActive(true);
                LevelSettings.instance.ResumeLevelDelegate += () => _tapToResumePanel.SetActive(true);*/
        LevelSettings.instance.FinishLevelDelegate += DestroyObj;
    }

    void DestroyObj()
    {
        LevelSettings.instance.FinishLevelDelegate -= DestroyObj;
        Destroy(this.gameObject);
    }
    public void Interact()
    {
        if (!LevelSettings.instance.GameState) LevelSettings.instance.StartLevel();
        _heroRigidBody.gravityScale = 2;
        _heroRigidBody.AddForce(new Vector2(0, 700));
        _heroRigidBody.velocity = Vector2.zero;
        Vibration.Vibrate(100);
    }



}
