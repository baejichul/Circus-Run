using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCoin : CollisionManager
{
    public ScoreManager _scoreMgr;
    public SpriteRenderer _sr;

    protected override void Start()
    {
        _cfgMgr = FindObjectOfType<ConfigManager>();
        _sndMgr = FindObjectOfType<SoundManager>();
        _scoreMgr = FindObjectOfType<ScoreManager>();
        _sr = GetComponent<SpriteRenderer>();
        _defaultHudlePosX = transform.position;

        // Debug.Log(transform.gameObject.name + " start pos : " + transform.position.x);
    }

    protected override void Update()
    {
        moveHudlePosX();
    }

    protected override void moveHudlePosX()
    {
        if (_playUI.activeSelf)
        {
            Vector3 pos = transform.position;
            transform.position = new Vector3(pos.x - _cfgMgr.coinMovePosX, pos.y, pos.z);

            if (pos.x <= _cfgMgr.coinMinPosX)
                initHudlePosX();
        }
    }

    protected override void initHudlePosX()
    {
        // if (transform.gameObject.activeSelf == false)
        //    transform.gameObject.SetActive(true);

        // if ( !_sr.enabled )
        //     _sr.enabled = true;

        transform.position = _defaultHudlePosX;
        // Debug.Log(transform.gameObject.name + " init pos : " + transform.position.x);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        string collisionObj = collision.gameObject.name;
        if (collisionObj.Equals("Joker"))
        {
            _sndMgr.Play(_cfgMgr.audSrcCoin);
            _scoreMgr.ObtainScore();
            //gameObject.SetActive(false);
            //_sr.enabled = false;        // renderer¸¦ ÅëÇÑ È­¸é¼û±èÃ³¸®
            initHudlePosX();

        }
    }

}
