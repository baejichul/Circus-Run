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

    // 버튼 게임오브젝트 활성화 변경
    public void setBtnObjActive(GameObject gObjUI, string btnNm, bool flag)
    {
        if (gObjUI is not null) 
            gObjUI.transform.Find(btnNm).gameObject.SetActive(flag);
        
    }

    public void setBtnObjActive(Transform trans, bool flag)
    {
        if (trans is not null)
            trans.gameObject.SetActive(flag);
    }

    public void setBtnObjActive(GameObject gObj, bool flag)
    {
        if (gObj is not null)
            gObj.SetActive(flag);
    }

    // 버튼의 이미지콤포넌트 이미지 변경하기
    public void loadImageSprite(GameObject gObjUI, string btnNm, string resourcePath, int idx = 0)
    {
        if (gObjUI is not null)
        {
            Image img = gObjUI.transform.Find(btnNm).GetComponent<Image>();
            img.sprite = Resources.LoadAll<Sprite>(resourcePath)[idx];
        }
    }

    public void loadImageSprite(Transform trans, string resourcePath, int idx = 0)
    {
        if (trans is not null)
        {
            Image img = trans.GetComponent<Image>();
            img.sprite = Resources.LoadAll<Sprite>(resourcePath)[idx];
        }
    }

    public void loadImageSprite(Image img, string resourcePath, int idx = 0)
    {
        // Debug.Log("resourcePath = " + resourcePath + " idx = " + idx);
        if (img is not null)
            img.sprite = Resources.LoadAll<Sprite>(resourcePath)[idx];
    }
   
}
