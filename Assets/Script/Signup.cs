using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Text;
using System;
using UnityEngine.Networking;

public class JsonTest
{
    public string id;
    public string pwd;
    public string username;
    public string birthday;
    public string height;
    public string weight;
    public string phonenum;
    public string address;
    public string email;
    public string gender;
    public string date;

    public string SaveToString(object obj)
    {
        return JsonUtility.ToJson(obj);
    }
}

public class Signup : MonoBehaviour
{
    [SerializeField] private InputField input_id;
    [SerializeField] private InputField input_pwd;
    [SerializeField] private InputField input_pwdcheck;
    [SerializeField] private Text idcheck_message;
    [SerializeField] private Text pwdcheck_message;
    [SerializeField] private InputField input_username;
    [SerializeField] private InputField input_birthday;
    [SerializeField] private Button input_man;
    [SerializeField] private Button input_manblack;
    [SerializeField] private Button input_woman;
    [SerializeField] private Button input_womanblack;
    [SerializeField] private InputField input_height;
    [SerializeField] private InputField input_weight;
    [SerializeField] private InputField input_phonenum;
    [SerializeField] private InputField input_address;
    [SerializeField] private InputField input_email;
    [SerializeField] private Button checkempty;
    [SerializeField] private Button checkagree;
    [SerializeField] private Button conditionW;
    [SerializeField] private Button informationW;
    [SerializeField] private Button conditionB;
    [SerializeField] private Button informationB;
    [SerializeField] private Button overlapcheck_bt;
    [SerializeField] private Button overlapcheck_bt2;

    SceneManger sceneMg;
    DateTime today = DateTime.Now;
    public string id = "0";
    public string pwd = "0";
    public string pwdcheck = "0";
    public string username = "0";
    public string birthday = "0";
    public string height = "0";
    public string weight = "0";
    public string phonenum = "0";
    public string address = "0";
    public string email = "0";
    public static string condition = "거절";
    public static string information = "거절";
    public static string gender = "남";
    public static string jsondata; //제이슨 파일 담아 보내는곳
    public static string IsSign = "회원가입";
    public static string url = "http://thdrldud369.dothome.co.kr/7.php"; //웹서버 도메인 여기만 바꾸면 다바뀔거임

    bool doublecheckresult; //중복여부 확인하는 bool값
    //중복확인 버튼 눌르면 동작
    public void doulbecheck()
    {
        IsSign = "중복확인";
        id = input_id.text;
        StartCoroutine(SendData(id));
        GetText();
    }
    
    //주소검색 누르면 나오는 이벤트
    public void searchAddress()
    {
       //여기에 API넣으셈
    }

    //회원가입 버튼 눌르면 동작
    public void SignupBtClick()
    {
        IsSign = "회원가입";
        //회원가입 정보가 하나라도 비어 있을경우
        if (string.IsNullOrEmpty(input_id.text) || string.IsNullOrEmpty(input_pwd.text) || string.IsNullOrEmpty(input_pwdcheck.text) || string.IsNullOrEmpty(input_username.text) || string.IsNullOrEmpty(input_birthday.text) ||
       string.IsNullOrEmpty(input_height.text) || string.IsNullOrEmpty(input_weight.text) || string.IsNullOrEmpty(input_phonenum.text) || string.IsNullOrEmpty(input_address.text) || gender == "")
        {
            checkempty.gameObject.SetActive(true);
            ResetValue(); //입력된 모든 값 초기화
        }
        
        //이용약관 및 개인정보 수집 이용 동의 체크
        else if (condition == "거절" || information == "거절")
        {
            checkagree.gameObject.SetActive(true);
        }

        //모든값이 다 들어가있으면
        else
        {
            //입력된 값을 각 변수에 저장
            id = input_id.text; 
            pwd = input_pwd.text;
            pwdcheck = input_pwdcheck.text;
            username = input_username.text;
            birthday = input_birthday.text;
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
                //회원가입시 입력된 값을 json으로 변환하고 웹서버로 데이터 전송하는 부분
                JsonTest json = new JsonTest();
                json.id = input_id.text;
                json.pwd = input_pwd.text;
                json.username = input_username.text;
                json.birthday = input_birthday.text;
                json.height = input_height.text;
                json.weight = input_weight.text;
                json.phonenum = input_phonenum.text;
                json.address = input_address.text;
                json.email = input_email.text;
                json.gender = gender;
                json.date = string.Format("{0:u}", today);
                json.SaveToString(json); //json형식으로 변환
                jsondata = json.SaveToString(json);
                StartCoroutine(SendData(jsondata)); //웹서버로 데이터 전송
                pwdcheck_message.gameObject.SetActive(false);
                StartCoroutine(Waitfortime());
            }
        }
    }

    //모든값 초기화 함수
    public void ResetValue()
    {
        id = "0";
        pwd = "0";
        pwdcheck = "0";
        username = "0";
        birthday = "0";
        height = "0";
        weight = "0";
        phonenum = "0";
        address = "0";
        email = "0";
        input_id.text = "";
        input_pwd.text = "";
        input_pwdcheck.text = "";
        input_username.text = "";
        input_birthday.text = "";
        input_height.text = "";
        input_weight.text = "";
        input_phonenum.text = "";
        input_address.text = "";
        input_email.text = "";
        condition = "거절";
        information = "거절";
        gender = "남";
        input_manblack.gameObject.SetActive(true);
        input_man.gameObject.SetActive(false);
        input_womanblack.gameObject.SetActive(false);
        input_woman.gameObject.SetActive(true);
        conditionW.gameObject.SetActive(true);
        conditionB.gameObject.SetActive(false);
        informationB.gameObject.SetActive(false);
        informationW.gameObject.SetActive(true);
        IsSign = "회원가입";
    }

    public void CheckEmpty()
    {
        checkempty.gameObject.SetActive(false);
    }
    public void CheckAgree()
    {
        checkagree.gameObject.SetActive(false);
    }

    //남자 버튼을 눌렀을때
    public void ChangeButtonForManB()
    {
        gender = "남";
        input_manblack.gameObject.SetActive(true);
        input_man.gameObject.SetActive(false);
        input_womanblack.gameObject.SetActive(false);
        input_woman.gameObject.SetActive(true);

    }

    //여자 버튼을 눌렀을때
    public void ChangeButtonForWomanB()
    {
        gender = "여";
        input_womanblack.gameObject.SetActive(true);
        input_woman.gameObject.SetActive(false);
        input_manblack.gameObject.SetActive(false);
        input_man.gameObject.SetActive(true);
    }

    //이용약관 동의
    public void ChangeButtonForConditionB()
    {
        condition = "동의";
        conditionW.gameObject.SetActive(false);
        conditionB.gameObject.SetActive(true);
    }

    //이용약관 거절
    public void ChangeButtonForConditionW()
    {
        condition = "거절";
        conditionW.gameObject.SetActive(true);
        conditionB.gameObject.SetActive(false);
    }

    //개인정보 수집 동의
    public void ChangeButtonForInformationB()
    {
        information = "동의";
        informationW.gameObject.SetActive(false);
        informationB.gameObject.SetActive(true);
    }

    //개인정보 수집 거절
    public void ChangeButtonForInformationW()
    {
        information = "거절";
        informationB.gameObject.SetActive(false);
        informationW.gameObject.SetActive(true);
    }

    void Start()
    {
        sceneMg = GameObject.Find("Main Camera").GetComponent<SceneManger>();
        ResetValue();
        GetText();
    }

    public IEnumerator GetText() //값 받아오는 부분
    {
        using (UnityWebRequest www = UnityWebRequest.Get(url))
        {
            yield return www.SendWebRequest(); //연결될때까지 기다리고 실행

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                string response = Encoding.UTF8.GetString(www.downloadHandler.data);
                string s = JsonUtility.FromJson<string>(response);
                Debug.Log(www.downloadHandler.text);
            }
        }
    }

    public IEnumerator SendData(string a) //값 보내는 부분
    {
        UnityWebRequest www;
        if (IsSign == "회원가입")
        {
            www = UnityWebRequest.Get(url + "?sign=" + a); //GET 방식으로 통신
            yield return www.SendWebRequest(); //연결될때까지 기다리고 실행
            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Form upload complete!");
            }
            string result = www.downloadHandler.text;   //받은 값 확인하는 부분
            Debug.Log(result);
        }
        else if(IsSign == "중복확인")
        {
            www = UnityWebRequest.Get(url + "?idcheck=" + a); //GET 방식으로 통신
            yield return www.SendWebRequest(); //연결될때까지 기다리고 실행
            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Form upload complete!");
            }
            //중복 이벤트 부분
            switch (doublecheckresult)
            {
                case true: //중복이면
                    idcheck_message.gameObject.SetActive(true);
                    break;
                case false: //중복이 아니면
                    idcheck_message.gameObject.SetActive(false);
                    overlapcheck_bt.gameObject.SetActive(false);
                    overlapcheck_bt2.gameObject.SetActive(true);
                    break;
            }
        }

        else if (IsSign == "결과값")
        {
            www = UnityWebRequest.Get(url + "?result=" + a); //GET 방식으로 통신
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

    }

    IEnumerator Waitfortime()
    {
        yield return new WaitForSeconds(0.5f);
        sceneMg.SceneChangeToLogin();
    }
}