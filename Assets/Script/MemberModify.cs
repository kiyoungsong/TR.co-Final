using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.Networking;

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
    DateTime today = DateTime.Now;
    SceneManger sceneMg;
    Signup signup;

    string id;                //수정 x 네이티브에서 아이디 저장
    string pwd;                
    string pwdcheck;
    string username;     //수정 x 네이티브에서 이름 저장
    string birthday;     //수정 x 네이티브에서 생년월일 저장
    string height;
    string weight;
    string phonenum;
    string address;
    string email;
    string gender = "남";      //수정 x 네이티브에서 성별 저장
    public static string jsonData; //수정된 json으로 변환된 값 저장

    //로그인 후 네이트에서 회원정보 여기에 넣어주면 됨
    //id, username, birthday는 수정 불가함
    string tmpid = "10";           
    string tmpusername = "0";     
    string tmpbirthday = "0";     
    string tmpheight = "0";
    string tmpweight = "0";
    string tmpphonenum = "0";
    string tmpaddress = "0";
    string tmpemail = "0";


    //주소검색 누르면 나오는 이벤트
    public void searchAddress()
    {
        //여기에 API넣으셈
    }

    //수정 후 입력된 값 들 변수에 넣음
    //수정하기 버튼 누르면 동작하는 함수
    public void ModiftyClick()
    {
        Signup.IsSign = "회원정보수정";
        //바꾸든 안바꾸든 비밀번호 입력하는 부분 
        if(string.IsNullOrEmpty(input_pwd.text) || string.IsNullOrEmpty(input_pwdcheck.text))
        {
            pwdinput_message.gameObject.SetActive(true);
        }
        else
        {
            //tmp에 넣어도 될거같은데 수정하기 귀찮;
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
                JsonTest json = new JsonTest();
                json.id = id;
                json.pwd = pwd;
                json.username = username;
                json.birthday = birthday;
                json.height = height;
                json.weight = weight;
                json.phonenum = phonenum;
                json.address = address;
                json.email = email;
                json.gender = gender;
                json.date = string.Format("{0:u}", today);
                json.SaveToString(json); //json형식으로 변환
                jsonData = json.SaveToString(json);
                Debug.Log(jsonData);
                StartCoroutine(SendData(jsonData)); //웹서버로 데이터 전송
                pwdcheck_message.gameObject.SetActive(false);
                StartCoroutine(Waitfortime());
                sceneMg.SceneChangeToMain();
            }
        }
            
    }



    void Start()
    {
        sceneMg = GameObject.Find("Main Camera").GetComponent<SceneManger>();
        //회원정보를 가져와서 보여주는 부분
        //id, username, birthday는 수정 불가함
        text_id.text = tmpid;                 
        text_username.text = tmpusername;
        text_birthday.text = tmpbirthday;
        input_address.text = tmpaddress;
        input_height.text = tmpheight;
        input_weight.text = tmpweight;
        input_phonenum.text = tmpphonenum;
        input_email.text = tmpemail;

        switch (gender)
        {
            case "남":
                input_manblack.gameObject.SetActive(true);
                input_man.gameObject.SetActive(false);
                input_womanblack.gameObject.SetActive(false);
                input_woman.gameObject.SetActive(true);
                break;
            case "여":
                input_manblack.gameObject.SetActive(false);
                input_man.gameObject.SetActive(true);
                input_womanblack.gameObject.SetActive(true);
                input_woman.gameObject.SetActive(false);
                break;
        }

        
    }


    void Update()
    {
        
    }

    public IEnumerator SendData(string a) //값 보내는 부분
    {
        UnityWebRequest www;
        string url = "";
        if (Signup.IsSign == "회원정보수정")
        {
            www = UnityWebRequest.Get(Signup.url + "?modify=" + a); //GET 방식으로 통신
            yield return www.SendWebRequest(); //연결될때까지 기다리고 실행
            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Form upload complete!");
            }
            string result = www.downloadHandler.text;
            Debug.Log(result);
        }
        /*List<IMultipartFormSection> form = new List<IMultipartFormSection>(); //웹폼 생성
        form.Add(new MultipartFormDataSection("sign", jsondata)); //회원가입 정보 넣는 부분 */
    }
    IEnumerator Waitfortime()
    {
        yield return new WaitForSeconds(0.5f);
        sceneMg.SceneChangeToLogin();
    }
}

