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

    // ��ư ���ӿ�����Ʈ Ȱ��ȭ ����
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

    // ��ư�� �̹���������Ʈ �̹��� �����ϱ�
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
