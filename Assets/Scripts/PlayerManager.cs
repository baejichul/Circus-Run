using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameObject _introUI;
    public GameObject _playUI;
    public GameObject _endUI;

    public ConfigManager _cfgMgr;
    public SoundManager _sndMgr;
    public Animator _ani;
    public Rigidbody2D _rigid;


    // Start is called before the first frame update
    void Start()
    {
        _cfgMgr = FindObjectOfType<ConfigManager>();
        _sndMgr = FindObjectOfType<SoundManager>();
        _rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movePlayerPos();
    }

    // 플레이어 위치 초기화
    public void initPlayerPos()
    {
        if (_playUI.activeSelf == true)
        {
            Vector3 vec3 = transform.position;
            transform.position = new Vector3(_cfgMgr.playerInitPos.x, _cfgMgr.playerInitPos.y, _cfgMgr.playerInitPos.z);
        }
    }

    // 물리중력 제어
    public void setRigidbodySimulate(bool val)
    {
        gameObject.GetComponent<Rigidbody2D>().simulated = val;
    }

    // 플레이어 위치 이동
    public void movePlayerPos()
    {
        Vector3 pos = transform.position;

        // Move Left
        if ( Input.GetKey(KeyCode.LeftArrow))
        {
            float posX = Mathf.Max(pos.x - _cfgMgr.playerMovePosX, _cfgMgr.playerMinPosX);
            transform.position = new Vector3(posX, pos.y, pos.z);
        }
        // Move Right
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            float posX = Mathf.Min(pos.x + _cfgMgr.playerMovePosX, _cfgMgr.playerMaxPosX);
            transform.position = new Vector3(posX, pos.y, pos.z);
        }

        // Jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // 바닥에 닿았을 경우
            if (pos.y <= _cfgMgr.playerInitPos.y)
            {
                Vector2 vec = _rigid.velocity;
                _rigid.AddForce(_cfgMgr.playerAddForce);
                _rigid.velocity = new Vector2(vec.x, _cfgMgr.playerAddVelocity);

                _sndMgr.Play(_cfgMgr.audSrcJump);
            }
        }
    }

}
