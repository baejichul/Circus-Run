using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject _introUI;
    public GameObject _playUI;
    public GameObject _endUI;

    public ConfigManager _cfgMgr;
    public PlayerManager _playMgr;
    public SoundManager _sndMgr;
    public ScoreManager _scMgr;

    // Start is called before the first frame update
    void Start()
    {
        _cfgMgr = FindObjectOfType<ConfigManager>();
        _playMgr = FindObjectOfType<PlayerManager>();
        _sndMgr  = FindObjectOfType<SoundManager>();
        _scMgr   = FindObjectOfType<ScoreManager>();

        InitGame();
    }

    // Update is called once per frame
    void Update()
    {   
        // Debug.Log("GameManager Update");
    }
    

    // 인트로 모드
    public void InitGame()
    {
        // UI 초기세팅
        _introUI.SetActive(true);
        _playUI.SetActive(false);
        _endUI.SetActive(false);

        setGravity(_cfgMgr.defaultGravity);

        _playMgr.setRigidbodySimulate(false);       // 플레이어 물리중력 제어
        // _sndMgr.Play(_cfgMgr.audSrcIntro);
        _sndMgr.IntroGame();
    }

    // 게임 모드
    public void PlayGame()
    {
        _introUI.SetActive(false);
        _playUI.SetActive(true);
        _endUI.SetActive(false);

        _playMgr.initPlayerPos();
        _playMgr.setRigidbodySimulate(true);
        // _sndMgr.Play("Play");
        _sndMgr.PlayGame();
    }

    // 게임오버 모드
    public void EndGame()
    {
        // UI 변경
        _introUI.SetActive(false);
        _playUI.SetActive(false);
        _endUI.SetActive(true);

        _scMgr.viewEndUIGameScore(5);
        _playMgr.setRigidbodySimulate(false);   // 플레이어 물리중력 제어
        // _playMgr.setTriggerDie();

        _sndMgr.EndGame();  // 소리 변경
    }

    // 게임 다시 시작
    public void RePlayGame()
    {   
        SceneManager.LoadScene(_cfgMgr.mainSceneName);
    }

    // 중력 지정
    public void setGravity(Vector2 vec)
    {
        Physics2D.gravity = vec;
    }

    // 버튼의 이미지콤포넌트 이미지 변경하기
    public void loadImageSprite(Image img, string resourcePath, int idx = 0)
    {
        // Debug.Log("resourcePath = " + resourcePath + " idx = " + idx);
        if (img is not null)
            img.sprite = Resources.LoadAll<Sprite>(resourcePath)[idx];
    }
   
}
