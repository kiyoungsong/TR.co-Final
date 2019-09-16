using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MemberModify : MonoBehaviour
{
    [SerializeField] private Text text_id;           //수정 X
    [SerializeField] private InputField input_pwd;
    [SerializeField] private Text pwdinput_message;
    [SerializeField] private InputField input_pwdcheck;
    [SerializeField] private Text pwdcheck_message;
    [SerializeField] private Text text_username;     //수정X
    [SerializeField] private Text text_birthday;     //수정X 
    [SerializeField] private Button input_man;              //성별 수정 X
    [SerializeField] private Button input_manblack;         //성별 수정 X
    [SerializeField] private Button input_woman;            //성별 수정 X
    [SerializeField] private Button input_womanblack;       //성별 수정 X
    [SerializeField] private InputField input_height;       
    [SerializeField] private InputField input_weight;
    [SerializeField] private InputField input_phonenum;
    [SerializeField] private InputField input_address;
    [SerializeField] private InputField input_email;
    
    SceneMg sceneMg;

    public string id;                 //수정 x 디비에서 받자
    public string pwd;    
    public string pwdcheck = "0";
    public string username = "0";           //수정 x 디비에서 받자
    public string birthday = "0";           //수정 x 디비에서 받자
    public string height = "0";
    public string weight = "0";
    public string phonenum = "0";
    public string address = "0";
    public string email = "0";
    public static string gender;      //수정 x 디비에서 받자

    //수정 후 입력된 값 들 변수에 넣음
    public void ModiftyClick()
    {
        Debug.Log("확인");
        if(string.IsNullOrEmpty(input_pwd.text) || string.IsNullOrEmpty(input_pwdcheck.text))
        {
            pwdinput_message.gameObject.SetActive(true);
        }
        else
        {
            id = text_id.text;
            pwd = input_pwd.text;
            pwdcheck = input_pwdcheck.text;
            username = text_username.text;
            birthday = text_birthday.text;
            height = input_height.text;
            weight = input_weight.text;
            phonenum = input_phonenum.text;
            address = input_address.text;
            email = input_email.text;

            if (pwd != pwdcheck)
            {
                pwdcheck_message.gameObject.SetActive(true);
            }
            else
            {
                pwdcheck_message.gameObject.SetActive(false);
                sceneMg.SceneChangeToMain();
            }
        }
            
    }



    void Start()
    {
        sceneMg = GameObject.Find("Main Camera").GetComponent<SceneMg>();
    }


    void Update()
    {
        
    }
}
