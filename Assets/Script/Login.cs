using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    //계속 데이터 받아와야됨 아이디 패스워드 그래서 아이디 패스워드 비교 서버하고
    public static string id;
    public static string pwd;

    [SerializeField] private InputField input_id;
    [SerializeField] private InputField input_pwd;

    public void TrytoLogin() //로그인 시도하는 부분
    {
        id = input_id.text;  //id, pwd값 json으로 보냄
        pwd = input_pwd.text;
        Debug.Log("실행");
        Debug.Log(id);
        Debug.Log(pwd);
    }
}
