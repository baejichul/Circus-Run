using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventListener : MonoBehaviour
{
    public GameObject _introUI;
    public GameObject _playUI;
    public GameObject _endUI;
    public ConfigManager _cfgMgr;
    public GameManager _gMgr;
    public SoundManager _sndMgr;

    void Start()
    {
        _cfgMgr = FindObjectOfType<ConfigManager>();
        _gMgr   = FindObjectOfType<GameManager>();
        _sndMgr = FindObjectOfType<SoundManager>();

        // 버튼 이벤트 리스너 등록
        if (_introUI.transform.Find("BtnPlay") is not null)
        {
            Button btnPlay = _introUI.transform.Find("BtnPlay").GetComponent<Button>();
            btnPlay.onClick.AddListener(PlayGame);            
            // 인자가 있는 경우 람다 식이나 델리게이트를 사용
            // btnPlay.onClick.AddListener(() => PlayGame(0));
            // btnPlay.onClick.AddListener(delegate { PlayGame(1); });
        }

        if (_playUI.transform.Find("BtnSoundMute") is not null)
        {
            Button btnSoundMute = _playUI.transform.Find("BtnSoundMute").GetComponent<Button>();
            btnSoundMute.onClick.AddListener(ChangeBtnMute);
        }

        if (_endUI.transform.Find("BtnRePlay") is not null)
        {
            Button btnRePlay = _endUI.transform.Find("BtnRePlay").GetComponent<Button>();
            btnRePlay.onClick.AddListener(RePlayGame);
        }

    }

    void Update()
    {
        
    }

    // 게임 시작
    void PlayGame()
    {
        _gMgr.PlayGame();
    }

    void PlayGame(int i)
    {
        // Debug.Log("PlayGame : " + i);
        _gMgr.PlayGame();
    }

    // 게임 음악소거
    void SoundMute()
    {
        if (Input.GetKey(KeyCode.Space)) return;
        _gMgr.loadImageSprite(_playUI.transform.Find("BtnSoundMute").GetComponent<Image>(), _cfgMgr.defaultResourceGUIPath + "/soundmute");
        _sndMgr.Mute(_cfgMgr.audSrcPlay);
    }

    // 게임 음악재생
    void SoundUnMute()
    {
        if (Input.GetKey(KeyCode.Space)) return;
        _gMgr.loadImageSprite(_playUI.transform.Find("BtnSoundMute").GetComponent<Image>(), _cfgMgr.defaultResourceGUIPath + "/soundunmute");
        _sndMgr.UnMute(_cfgMgr.audSrcPlay);
    }

    // 게임 Mute변경
    void ChangeBtnMute()
    {
        // 스페이스바를 누를경우 예외 처리
        // Focus(), Blur() 처리를 확인해 봐야 할 거 같음
        if (Input.GetKey(KeyCode.Space)) return;

        if (_sndMgr.getMute(_cfgMgr.audSrcPlay))
        {
            _gMgr.loadImageSprite(_playUI.transform.Find("BtnSoundMute").GetComponent<Image>(), _cfgMgr.defaultResourceGUIPath + "/soundmute");
        }
        else
        {
            _gMgr.loadImageSprite(_playUI.transform.Find("BtnSoundMute").GetComponent<Image>(), _cfgMgr.defaultResourceGUIPath + "/soundunmute");
        }
        _sndMgr.ChangeMute(_cfgMgr.audSrcPlay);
    }

    // 게임 재시작
    void RePlayGame()
    {
        _gMgr.RePlayGame();
    }

}
