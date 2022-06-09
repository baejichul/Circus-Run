using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public GameObject _introUI;
    public GameObject _playUI;
    public GameObject _endUI;

    public ConfigManager _cfgMgr;
    public Text _txtScoreNumber;
    public Text _txtLastScoreNumber;

    
    int _gameScore;

    // Start is called before the first frame update
    void Start()
    {
        _cfgMgr = FindObjectOfType<ConfigManager>();
        initScore();
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePlayUIGameScore(5);
    }

    // ���� �ʱ�ȭ
    void initScore()
    {   
        if ( _playUI.transform.Find(_cfgMgr.txtScoreNumber) is not null )
            _txtScoreNumber = _playUI.transform.Find(_cfgMgr.txtScoreNumber).GetComponent<Text>();

        if ( _endUI.transform.Find(_cfgMgr.txtLastScoreNumber) is not null )
            _txtLastScoreNumber = _endUI.transform.Find(_cfgMgr.txtLastScoreNumber).GetComponent<Text>();
            
    }

    // ���� ����
    public int getGameScore()
    {
        return _gameScore;
    }

    // �������� ���ھ� ǥ��
    public void UpdatePlayUIGameScore(int digit = 0)
    {
        if (_txtScoreNumber is not null)
            _txtScoreNumber.text = (digit > 0 ? _gameScore.ToString("D" + digit.ToString()) : _gameScore.ToString());
    }
    
    public void UpdatePlayUIGameScore(string scoreObjNm, int digit=0)
    {
        if (_playUI.transform.Find(scoreObjNm) is not null)
        {
            _txtScoreNumber = _playUI.transform.Find(scoreObjNm).GetComponent<Text>();
            _txtScoreNumber.text = (digit > 0 ? _gameScore.ToString("D" + digit.ToString()) : _gameScore.ToString());
        }
    }

    // ���� ���� ���ھ� ǥ��
    public void viewEndUIGameScore(int digit = 0)
    {
        if ( _txtLastScoreNumber is not null )
            _txtLastScoreNumber.text = (digit > 0 ? _gameScore.ToString("D" + digit.ToString()) : _gameScore.ToString());
    }

    public void viewEndUIGameScore(string scoreObjNm, int digit=0)
    {
        if (_endUI.transform.Find(scoreObjNm) is not null)
        {
            _txtLastScoreNumber = _endUI.transform.Find(scoreObjNm).GetComponent<Text>();
            _txtLastScoreNumber.text = (digit > 0 ? _gameScore.ToString("D" + digit.ToString()) : _gameScore.ToString());
        }
    }

    // ���� ���ھ� ȹ��
    public void ObtainScore()
    {
        _gameScore += _cfgMgr.defaultObtainScore;
    }
    
    public void ObtainScore(int val)
    {
        _gameScore += val;
    }
}
