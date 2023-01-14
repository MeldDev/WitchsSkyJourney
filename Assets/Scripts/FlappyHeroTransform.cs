/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlappyHeroTransform : MonoBehaviour
{

    [SerializeField] Transform _heroTransform;
    [SerializeField] Rigidbody2D _heroRigidBody;
    [SerializeField] float _speedFlyingHero;
    [SerializeField] bool _gameIsPlaying = true;
    [SerializeField] GameObject _textView;




    public GameObject MainCamera;
    public GameObject PanelForClicks;

    private GameObject panelForClick;
    private LevelSettings startGameScript;
    private WellBuilder wellBuilderScript;

    [SerializeField] private Animator _animator;

    private void Start()
    {
        startGameScript = GameObject.FindObjectOfType<LevelSettings>();
        wellBuilderScript = GameObject.FindObjectOfType<WellBuilder>();
        _textView.GetComponent<Canvas>().worldCamera = MainCamera.GetComponent<Camera>();
        startGameScript.ZeroingCoinsAndDistance();
    }
    public void SetIsPlayingBool()
    {
        _gameIsPlaying = false;
    }
    public void ViewTextForPlay()
    {
        _textView.SetActive(!_textView.activeSelf);
    }
    public void FirstJump()
    {
        if (!_gameIsPlaying)
        {
            this.GetComponent<CreateClickPanelForHero>().CreateClickButton(PanelForClicks.transform);
            startGameScript.OffMainMenu();
            _gameIsPlaying = true;
            ViewTextForPlay();
            _animator.SetBool("WaitStartGame", false);
            _heroRigidBody.gravityScale = 2;
            wellBuilderScript.BuildWell();
            StartCoroutine(UpdateDistance());
            Jump();
        }
    }

    IEnumerator UpdateDistance()
    {
        while (true)
        {
            yield return new WaitForFixedUpdate();
            startGameScript.UpdateDistance(Time.deltaTime);
        }
        
    }
    public void FailGame()
    {
        StopCoroutine(UpdateDistance());
        startGameScript.LoadMainMenu();
        wellBuilderScript?.DestroyAllWells();
        Destroy(panelForClick);
        Destroy(this.gameObject);
    }

    void Update()
    {
        MoveHero();
    }

    private void MoveHero()
    {
        _heroTransform.Translate(new Vector3(1 * _speedFlyingHero * Time.deltaTime, 0, 0));
        MainCamera.transform.position = new Vector3(this.transform.position.x, 0, -10);
    }

    public void Jump()
    {
            _heroRigidBody.AddForce(new Vector2(0, 700));
            _heroRigidBody.velocity = Vector2.zero;
            _animator.SetTrigger("Jump");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "well":
                FailGame(); 
                break;
            case "bonus":
                SetHarderLevel();
                wellBuilderScript.BuildWell();
                break;
            case "Coin":
                //startGameScript.UpdateBalanceCoins(1);
                Destroy(collision.gameObject); 
                break;
            case "Gem":
                //startGameScript.UpdateBalanceGem(1);
                Destroy(collision.gameObject); 
                break;
            default: break;
        }
    }

    private void SetHarderLevel()
    {
        if (_speedFlyingHero<4)
        {
            _speedFlyingHero += 0.05f;
        }
        wellBuilderScript.SetSmallerHole(0.05f);


    }
}
*/