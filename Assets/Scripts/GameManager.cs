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
    

    // ��Ʈ�� ���
    public void InitGame()
    {
        // UI �ʱ⼼��
        _introUI.SetActive(true);
        _playUI.SetActive(false);
        _endUI.SetActive(false);

        _playMgr.setRigidbodySimulate(false);       // �÷��̾� �����߷� ����
        // _sndMgr.Play(_cfgMgr.audSrcIntro);
        _sndMgr.IntroGame();
    }

    // ���� ���
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

    // ���ӿ��� ���
    public void EndGame()
    {
        _sndMgr.EndGame();  // �Ҹ� ����

        // UI ����
        _introUI.SetActive(false);
        _playUI.SetActive(false);
        _endUI.SetActive(true);

        _scMgr.viewEndUIGameScore();
        _playMgr.setRigidbodySimulate(false);   // �÷��̾� �����߷� ����
        // _playMgr.setTriggerDie();
    }

    // ���� �ٽ� ����
    public void RePlayGame()
    {
        // _sndMgr.Play("Play");
        _sndMgr.PlayGame();
        SceneManager.LoadScene(_cfgMgr.mainSceneName);
    }
    
    // ���� ���۹�ư
    public void OnClick_BtnStart()
    {
        //  EventListener ������ ó�� �����ϴ�.

        // �̹��� ���� ������ 1
        // _introUI.transform.Find("BtnPlay").gameObject.SetActive(false);
        // _introUI.transform.Find("BtnPlayOn").gameObject.SetActive(true);

        // �̹��� ���� ������ 2
        //Image img = _introUI.transform.Find("BtnPlay").GetComponent<Image>();
        //img.sprite = Resources.LoadAll<Sprite>(_cfgMgr.defaultResourceGUIPath + "/playT")[0];

        PlayGame();
    }

    // ���� �ٽý��� ��ư
    public void OnClick_BtnRetry()
    {
        RePlayGame();
    }

    private void OnMouseOver()
    {
        
    }
}
