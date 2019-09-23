using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class Video : MonoBehaviour
{
    VideoPlayer vp;

    // Start is called before the first frame update
    void Start()
    {
        vp = GameObject.Find("VPlayer").GetComponent<VideoPlayer>();
        if (vp)
        {
            Debug.Log("vp : 참조");
        }
        else
        {
            Debug.LogWarning("vp를 찾을 수 업습니다.");
        } 
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Play()
    {
        if (vp)
        {
            vp.Play();
        }
        else
        {
            Debug.LogWarning("vp에 참조 할 수 없습니다.");
        }
    }    
}
