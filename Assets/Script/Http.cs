using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Text;

public class Http : MonoBehaviour
{
    Signup signup;
    string url = "http://thdrldud369.dothome.co.kr/7.php";
    public IEnumerator GetText() //값 받아오는 부분
    {
        url = "http://thdrldud369.dothome.co.kr/7.php";
        using (UnityWebRequest request = UnityWebRequest.Get(url))
        {
            yield return request.SendWebRequest(); //연결될때까지 기다리고 실행

            if(request.isNetworkError) //Error
            {
                Debug.Log(request.error);
            }
            else
            {
                Debug.Log(Encoding.Default.GetString(request.downloadHandler.data)); //값 확인
            }
        }
    }

    public IEnumerator SendData() //값 보내는 부분
    {
        Debug.Log("확인");
        List<IMultipartFormSection> form = new List<IMultipartFormSection>(); //웹폼 생성
        //form.Add(new MultipartFormDataSection()); //회원가입 정보 넣는 부분 
        UnityWebRequest www = UnityWebRequest.Post(url, Signup.jsondata); //POST 방식으로 통신
        yield return www.SendWebRequest(); //연결될때까지 기다리고 실행
        string re = Signup.jsondata;
        Debug.Log("확인2");
        string result = Encoding.Default.GetString(www.uploadHandler.data); //값 확인
        Debug.Log(re);
        www.Dispose();
    }

    public void Sending()
    {
        StartCoroutine(SendData());
    }
    public void geting()
    {
        StartCoroutine(GetText());
    }
        
}
