using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.Networking;

public class Login : MonoBehaviour
{
    //계속 데이터 받아와야됨 아이디 패스워드 그래서 아이디 패스워드 비교 서버하고
    public static string id;    
    public static string pwd;
    public static bool logincheck = false;

    [SerializeField] private InputField input_id;
    [SerializeField] private InputField input_pwd;
    Signup sign;
    SceneManger scene;
    DateTime today = DateTime.Now;

    public void TrytoLogin() //로그인 시도하는 부분
    {
        scene.SceneChangeToMain(); //로그인하면 씬전환
        /*id = input_id.text;  //id, pwd값 json으로 보냄
        pwd = input_pwd.text;
        
        JsonTest json = new JsonTest(); //id, pwd, date 값 json으로 변환 후 전송
        json.id = input_id.text;
        json.pwd = input_pwd.text;
        json.date = string.Format("{0:u}", today);
        Signup.jsondata = json.SaveToString(json); //json형식으로 변환
        StartCoroutine(sign.SendData(Signup.jsondata)); //웹서버로 데이터 전송
        //전송 했으니 이제 받아서 
        if (id == "123" && pwd == "123") //id하고 pwd가 서버에서 보내주는놈과 같으면 
        {
            
        }
        else
        {
            //로그인 실패 팝업창 띄우기
        }*/
    }
}
