using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameObject _introUI;
    public GameObject _playUI;
    public GameObject _endUI;

    public ConfigManager _cfgMgr;
    public Animator _ani;

    // Start is called before the first frame update
    void Start()
    {
        _cfgMgr = FindObjectOfType<ConfigManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
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

}
