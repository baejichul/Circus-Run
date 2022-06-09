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

        // ��ư �̺�Ʈ ������ ���
        if (_introUI.transform.Find("BtnPlay") is not null)
        {
            Button btnPlay = _introUI.transform.Find("BtnPlay").GetComponent<Button>();
            btnPlay.onClick.AddListener(PlayGame);            
            // ���ڰ� �ִ� ��� ���� ���̳� ��������Ʈ�� ���
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

    // ���� ����
    void PlayGame()
    {
        _gMgr.PlayGame();
    }

    void PlayGame(int i)
    {
        // Debug.Log("PlayGame : " + i);
        _gMgr.PlayGame();
    }

    // ���� ���ǼҰ�
    void SoundMute()
    {
        if (Input.GetKey(KeyCode.Space)) return;
        _gMgr.loadImageSprite(_playUI.transform.Find("BtnSoundMute").GetComponent<Image>(), _cfgMgr.defaultResourceGUIPath + "/soundmute");
        _sndMgr.Mute(_cfgMgr.audSrcPlay);
    }

    // ���� �������
    void SoundUnMute()
    {
        if (Input.GetKey(KeyCode.Space)) return;
        _gMgr.loadImageSprite(_playUI.transform.Find("BtnSoundMute").GetComponent<Image>(), _cfgMgr.defaultResourceGUIPath + "/soundunmute");
        _sndMgr.UnMute(_cfgMgr.audSrcPlay);
    }

    // ���� Mute����
    void ChangeBtnMute()
    {
        // �����̽��ٸ� ������� ���� ó��
        // Focus(), Blur() ó���� Ȯ���� ���� �� �� ����
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

    // ���� �����
    void RePlayGame()
    {
        _gMgr.RePlayGame();
    }

}
