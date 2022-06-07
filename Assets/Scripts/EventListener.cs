using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventListener : MonoBehaviour
{
    public GameObject _introUI;
    public GameObject _playUI;
    public GameObject _endUI;

    void Start()
    {
        if (_introUI.transform.Find("BtnPlay") is not null)
        {
            Button btnPlay = _introUI.transform.Find("BtnPlay").GetComponent<Button>();
            // btnPlay.onClick.AddListener(PlayButton);
        }
    }

    void Update()
    {
    }

    void PlayButton()
    {
        // 이미지 직접 변경방법 1
        // _introUI.transform.Find("BtnPlay").gameObject.SetActive(false);
        // _introUI.transform.Find("BtnPlayOn").gameObject.SetActive(true);

        // 이미지 직접 변경방법 2
        // Image img = _introUI.transform.Find("BtnPlay").GetComponent<Image>();
        // img.sprite = Resources.LoadAll<Sprite>("GUI/playT")[0];

        Debug.Log("PlayButton");
    }
}
