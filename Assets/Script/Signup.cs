using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Text;


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
    public string SaveToString(object obj)
    {
        return JsonUtility.ToJson(obj);
    }
    
    public void CreateJsonFile(string createPath, string fileName, string jsonData)
    {
        FileStream fileStream = new FileStream(string.Format($"{createPath}/{fileName}.json"), FileMode.Create);
        byte[] data = Encoding.UTF8.GetBytes(jsonData);
        fileStream.Write(data, 0, data.Length);
        fileStream.Close();
    }
}

public class Signup : MonoBehaviour
{
    [SerializeField] private InputField input_id;
    [SerializeField] private InputField input_pwd;
    [SerializeField] private InputField input_pwdcheck;
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

    SceneManger sceneMg;


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


    //회원가입 버튼 눌르면 동작
    public void SignupBtClick()
    {
        if (string.IsNullOrEmpty(input_id.text) || string.IsNullOrEmpty(input_pwd.text) || string.IsNullOrEmpty(input_pwdcheck.text) || string.IsNullOrEmpty(input_username.text) || string.IsNullOrEmpty(input_birthday.text) ||
       string.IsNullOrEmpty(input_height.text) || string.IsNullOrEmpty(input_weight.text) || string.IsNullOrEmpty(input_phonenum.text) || string.IsNullOrEmpty(input_address.text) || gender == "")
        {
            checkempty.gameObject.SetActive(true);
            ResetValue();
            
        }

        else if (condition == "거절" || information == "거절")
        {
            checkagree.gameObject.SetActive(true);
        }

        else
        {
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
                json.SaveToString(json);
                string a = json.SaveToString(json);
                Debug.Log(json.SaveToString(json));
                json.CreateJsonFile(Application.dataPath, "SignupData", a);
                pwdcheck_message.gameObject.SetActive(false);
                sceneMg.SceneChangeToLogin();
            }
            Debug.Log("끝");
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
    }

    void Update()
    {

    }
    
}


