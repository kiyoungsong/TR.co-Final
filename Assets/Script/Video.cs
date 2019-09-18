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
        vp = GameObject.Find("Video Player").GetComponent<VideoPlayer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Play()
    {
        vp.Play();
    }    
}
