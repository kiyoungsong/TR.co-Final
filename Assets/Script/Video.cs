using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Video : MonoBehaviour
{
    GameUIMg gameUIMg;

    public void Play()
    {
        switch (GameUIMg.whichone)
        {
            case "Lung":    //폐기능 가이드 영상 재생
                Debug.Log(GameUIMg.whichone);
                Handheld.PlayFullScreenMovie("test.mp4", Color.black, FullScreenMovieControlMode.CancelOnInput);
                break;
            case "Exhale":  //들숨 가이드 영상 재생
                Debug.Log(GameUIMg.whichone);
                Handheld.PlayFullScreenMovie("test.mp4", Color.black, FullScreenMovieControlMode.CancelOnInput);
                break;
            case "Inhale":  //날숨 가이드 영상 재생
                Debug.Log(GameUIMg.whichone);
                Handheld.PlayFullScreenMovie("test.mp4", Color.black, FullScreenMovieControlMode.CancelOnInput);
                break;
        }
    }
}
