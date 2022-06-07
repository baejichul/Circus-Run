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
        _sndMgr.EndGame();  // 소리 변경

        // UI 변경
        _introUI.SetActive(false);
        _playUI.SetActive(false);
        _endUI.SetActive(true);

        _scMgr.viewEndUIGameScore();
        _playMgr.setRigidbodySimulate(false);   // 플레이어 물리중력 제어
        // _playMgr.setTriggerDie();
    }

    // 게임 다시 시작
    public void RePlayGame()
    {
        // _sndMgr.Play("Play");
        _sndMgr.PlayGame();
        SceneManager.LoadScene(_cfgMgr.mainSceneName);
    }
    
    // 게임 시작버튼
    public void OnClick_BtnStart()
    {
        //  EventListener 에서도 처리 가능하다.

        // 이미지 직접 변경방법 1
        // _introUI.transform.Find("BtnPlay").gameObject.SetActive(false);
        // _introUI.transform.Find("BtnPlayOn").gameObject.SetActive(true);

        // 이미지 직접 변경방법 2
        //Image img = _introUI.transform.Find("BtnPlay").GetComponent<Image>();
        //img.sprite = Resources.LoadAll<Sprite>(_cfgMgr.defaultResourceGUIPath + "/playT")[0];

        PlayGame();
    }

    // 게임 다시시작 버튼
    public void OnClick_BtnRetry()
    {
        RePlayGame();
    }

    private void OnMouseOver()
    {
        
    }
}
