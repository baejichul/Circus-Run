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

    int basicGameScore = 1;
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
        UpdatePlayUIGameScore();
    }

    // 점수 초기화
    void initScore()
    {
        if ( _playUI.activeSelf && _playUI.transform.Find(_cfgMgr.txtScoreNumber) is not null )
            _txtScoreNumber = _endUI.transform.Find(_cfgMgr.txtScoreNumber).GetComponent<Text>();

        if (_endUI.activeSelf && _endUI.transform.Find(_cfgMgr.txtLastScoreNumber) is not null )
            _txtLastScoreNumber = _endUI.transform.Find(_cfgMgr.txtLastScoreNumber).GetComponent<Text>();
    }

    // 현재 점수
    public int getGameScore()
    {
        return _gameScore;
    }

    // 게임진행 스코어 표시
    public void UpdatePlayUIGameScore()
    {
        if ( _txtScoreNumber is not null )
            _txtScoreNumber.text = _gameScore.ToString();
    }

    public void UpdatePlayUIGameScore(string scoreObjNm)
    {   
        _txtScoreNumber = _endUI.transform.Find(scoreObjNm).GetComponent<Text>();
        _txtScoreNumber.text = _gameScore.ToString();
    }
    public void UpdatePlayUIGameScore(string scoreObjNm, int digit=0)
    {
        _txtScoreNumber = _endUI.transform.Find(scoreObjNm).GetComponent<Text>();
        _txtScoreNumber.text = (digit > 0 ? _gameScore.ToString( "D" + digit.ToString() ) : _gameScore.ToString() );
    }

    // 게임 최종 스코어 표시
    public void viewEndUIGameScore()
    {
        if ( _txtLastScoreNumber is not null )
            _txtLastScoreNumber.text = _gameScore.ToString();
    }
    public void viewEndUIGameScore(string scoreObjNm)
    {
        _txtLastScoreNumber = _endUI.transform.Find(scoreObjNm).GetComponent<Text>();
        _txtLastScoreNumber.text = _gameScore.ToString();
    }

    public void viewEndUIGameScore(string scoreObjNm, int digit=0)
    {
        _txtLastScoreNumber = _endUI.transform.Find(scoreObjNm).GetComponent<Text>();
        _txtLastScoreNumber.text = (digit > 0 ? _gameScore.ToString( "D" + digit.ToString() ) : _gameScore.ToString() );
    }

    // 게임 스코어 획득
    public void ObtainScore()
    {
        _gameScore += basicGameScore;
    }
    
    public void ObtainScore(int val)
    {
        _gameScore += val;
    }
}
