using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;
using UnityEngine.Video;
public class SceneManger : MonoBehaviour
{
    GameUIMg gameUI;
    VideoPlayer vp;
    private void Start()
    {
    }

    //로그인 화면으로 씬전환
    public void SceneChangeToLogin()
    {
        SceneManager.LoadScene("LoginScene");
    }

    //회원가입 화면으로 씬전환
    public void SceneChangeToSignup()
    {
        SceneManager.LoadScene("SignUPScene");
    }

    //메인 화면으로 씬전환
    public void SceneChangeToMain()
    {
        SceneManager.LoadScene("MainScene");
    }

    //회원정보 화면으로 씬전환
    public void SceneChangeToMemberInformation()
    {
        SceneManager.LoadScene("MemberModify");
    }
    //폐기능 검사 동영상 가이드 씬전환
    public void SceneChangeToLungCheckGuideScene()
    {
        SceneManager.LoadScene("LungCheckGuideScene");
    }

    //회원정보 씬전환
    public void SceneChangeToLungCheckScene()
    {
        SceneManager.LoadScene("LungCheckScene");
        GameUIMg.whichone = "Lung";
    }

    //호흡근력 검사 씬전환
    public void SceneChangeToExhaleGuideScene()
    {
        SceneManager.LoadScene("ExhaleCheckGuideScene");
        GameUIMg.whichone = "Exhale";
        GameUIMg.mathScore = Enumerable.Repeat<float>(0, 1024).ToArray<float>();
        GameUIMg.count = 0;
    }

    public void SceneChangeToExhaleCheckScene()
    {
        SceneManager.LoadScene("ExhaleCheckScene");
        GameUIMg.whichone = "Exhale";
    }

    public void SceneChangeToInhaleGuideScene()
    {
        SceneManager.LoadScene("InhaleCheckGuideScene");
        GameUIMg.whichone = "Inhale";
        GameUIMg.mathScore = Enumerable.Repeat<float>(0, 1024).ToArray<float>();
        GameUIMg.count2 = 0;
    }

    public void SceneChangeToInhaleCheckScene()
    {
        SceneManager.LoadScene("InhaleCheckScene");
        GameUIMg.whichone = "Inhale";
    }

    public void LoadGuide()
    {
        GameUIMg.guideload = true;
    }

}
