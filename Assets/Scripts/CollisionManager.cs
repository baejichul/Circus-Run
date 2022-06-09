using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    public GameObject _introUI;
    public GameObject _playUI;
    public GameObject _endUI;

    public ConfigManager _cfgMgr;
    public SoundManager _sndMgr;
    public Vector3 _defaultHudlePosX;


    // Start is called before the first frame update
    protected virtual void Start()
    {
        _cfgMgr = FindObjectOfType<ConfigManager>();
        _sndMgr = FindObjectOfType<SoundManager>();
        _defaultHudlePosX = transform.position;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        moveHudlePosX();
    }

    // 장애물 X축 이동
    protected virtual void moveHudlePosX()
    {
        if (_playUI.activeSelf)
        {
            Vector3 pos = transform.position;
            transform.position = new Vector3(pos.x - _cfgMgr.hudleMovePosX, pos.y, pos.z);

            if (pos.x <= _cfgMgr.hudleMinPosX)
                initHudlePosX();
        }
    }

    protected virtual void moveHudlePosX(Transform tf)
    {
        if (_playUI.activeSelf)
        {
            Vector3 pos = tf.position;
            tf.position = new Vector3(pos.x - _cfgMgr.hudleMovePosX, pos.y, pos.z);

            if (pos.x <= _cfgMgr.hudleMinPosX)
                initHudlePosX(tf);
        }
    }

    // 장애물 초기위치로 이동
    protected virtual void initHudlePosX()
    {
        transform.position = _defaultHudlePosX;
    }

    protected virtual void initHudlePosX(Transform tf)
    {
        tf.position = _defaultHudlePosX;
    }


}
