using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    AudioSource _introAudioSrc;
    AudioSource _playAudioSrc;
    AudioSource _jumpAudioSrc;
    AudioSource _landAudioSrc;
    AudioSource _dieAudioSrc;
    AudioSource _coinAudioSrc;
    AudioSource _endAudioSrc;

    public ConfigManager _cfgMgr;

    // Start is called before the first frame update
    void Start()
    {
        _cfgMgr = FindObjectOfType<ConfigManager>();
        InitAudioSrc();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 오디오 초기화
    void InitAudioSrc()
    {
        if (transform.Find(_cfgMgr.audSrcIntro) is not null )
            _introAudioSrc = transform.Find(_cfgMgr.audSrcIntro).gameObject.GetComponent<AudioSource>();
        if (transform.Find(_cfgMgr.audSrcPlay) is not null)
            _playAudioSrc = transform.Find(_cfgMgr.audSrcPlay).gameObject.GetComponent<AudioSource>();
        if (transform.Find(_cfgMgr.audSrcJump) is not null)
            _jumpAudioSrc = transform.Find(_cfgMgr.audSrcJump).gameObject.GetComponent<AudioSource>();
        if (transform.Find(_cfgMgr.audSrcLand) is not null)
            _landAudioSrc = transform.Find(_cfgMgr.audSrcLand).gameObject.GetComponent<AudioSource>();
        if (transform.Find(_cfgMgr.audSrcDie) is not null)
            _dieAudioSrc = transform.Find(_cfgMgr.audSrcDie).gameObject.GetComponent<AudioSource>();
        if (transform.Find(_cfgMgr.audSrcCoin) is not null)
            _coinAudioSrc = transform.Find(_cfgMgr.audSrcCoin).gameObject.GetComponent<AudioSource>();
        if (transform.Find(_cfgMgr.audSrcEnd) is not null)
            _endAudioSrc = transform.Find(_cfgMgr.audSrcEnd).gameObject.GetComponent<AudioSource>();
    }

    // 오디오 play
    public void Play(string gameObject)
    {
        if (transform.Find(gameObject) is not null )
            transform.Find(gameObject).GetComponent<AudioSource>().Play();
    }

    public void Play(AudioSource audSrc)
    {
        if (audSrc is not null)
            audSrc.Play();
    }

    // 오디오 stop
    public void Stop(string gameObject)
    {
        if (transform.Find(gameObject) is not null)
            transform.Find(gameObject).GetComponent<AudioSource>().Stop();
    }

    public void Stop(AudioSource audSrc)
    {
        if (audSrc is not null)
            audSrc.Stop();
    }

    // 오디오 pause
    public void Pause(string gameObject)
    {
        if (transform.Find(gameObject) is not null)
            transform.Find(gameObject).GetComponent<AudioSource>().Pause();
    }

    public void Pause(AudioSource audSrc)
    {
        if (audSrc is not null)
            audSrc.Pause();
    }

    // 오디오 unpause
    public void UnPause(string gameObject)
    {
        if (transform.Find(gameObject) is not null)
            transform.Find(gameObject).GetComponent<AudioSource>().UnPause();
    }

    public void UnPause(AudioSource audSrc)
    {
        if (audSrc is not null)
            audSrc.UnPause();
    }

    // 인트로시 오디오설정
    public void IntroGame()
    {
        if (_introAudioSrc is not null) _introAudioSrc.Play();
        if (_playAudioSrc is not null)  _playAudioSrc.Stop();
        if (_jumpAudioSrc is not null)  _jumpAudioSrc.Stop();
        if (_landAudioSrc is not null)  _landAudioSrc.Stop();
        if (_dieAudioSrc is not null)   _dieAudioSrc.Stop();
        if (_coinAudioSrc is not null)  _coinAudioSrc.Stop();
        if (_endAudioSrc is not null)   _endAudioSrc.Stop();
    }

    // 플레이시 오디오설정
    public void PlayGame()
    {
        if (_introAudioSrc is not null) _introAudioSrc.Stop();
        if (_playAudioSrc is not null) _playAudioSrc.Play();
        if (_jumpAudioSrc is not null) _jumpAudioSrc.Stop();
        if (_landAudioSrc is not null) _landAudioSrc.Stop();
        if (_dieAudioSrc is not null) _dieAudioSrc.Stop();
        if (_coinAudioSrc is not null) _coinAudioSrc.Stop();
        if (_endAudioSrc is not null) _endAudioSrc.Stop();
    }

    // Die시 오디오설정
    public void DieGame()
    {
        if (_introAudioSrc is not null) _introAudioSrc.Stop();
        if (_playAudioSrc is not null) _playAudioSrc.Stop();
        if (_jumpAudioSrc is not null) _jumpAudioSrc.Stop();
        if (_landAudioSrc is not null) _landAudioSrc.Stop();
        if (_dieAudioSrc is not null) _dieAudioSrc.Play();
        if (_coinAudioSrc is not null) _coinAudioSrc.Stop();
        if (_endAudioSrc is not null) _endAudioSrc.Stop();
    }

    // End시 오디오설정
    public void EndGame()
    {
        if (_introAudioSrc is not null) _introAudioSrc.Stop();
        if (_playAudioSrc is not null) _playAudioSrc.Stop();
        if (_jumpAudioSrc is not null) _jumpAudioSrc.Stop();
        if (_landAudioSrc is not null) _landAudioSrc.Stop();
        if (_dieAudioSrc is not null) _dieAudioSrc.Play();
        if (_coinAudioSrc is not null) _coinAudioSrc.Stop();
        if (_endAudioSrc is not null) _endAudioSrc.Play();
    }

    // 오디오 Mute
    public void Mute(string gameObject)
    {
        if (transform.Find(gameObject) is not null)
            transform.Find(gameObject).GetComponent<AudioSource>().mute = true;
    }

    // 오디오 UnMute
    public void UnMute(string gameObject)
    {
        if (transform.Find(gameObject) is not null)
            transform.Find(gameObject).GetComponent<AudioSource>().mute = false;
    }

    // 오디오 getMute
    public bool getMute(string gameObject)
    {
        return transform.Find(gameObject).GetComponent<AudioSource>().mute;
    }

    // 오디오 ChangeMute
    public void ChangeMute(string gameObject)
    {
        if (transform.Find(gameObject) is not null)
        {
            bool mute = transform.Find(gameObject).GetComponent<AudioSource>().mute;
            transform.Find(gameObject).GetComponent<AudioSource>().mute = !mute;
        }
    }
}
