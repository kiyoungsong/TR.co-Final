﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneMg : MonoBehaviour
{
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
}