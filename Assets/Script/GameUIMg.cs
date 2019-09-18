using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIMg : MonoBehaviour
{
    float countdown = 6.001f; //카운트 다운
    float checktime = 7.001f; //측정시간
    string guide = "";
    [SerializeField] public Text countdown_txt; //카운트 다운 UI
    [SerializeField] public Text guide_txt; //가이드 UI
    [SerializeField] public Text Result_txt; //결과 UI
    public bool pause = true; //게임일시 정지 여부


    //다른 스크립트 접근
    AirController airController;
    LungCheckMg lungCheckMg;

    void Start()
    {

        airController = GameObject.Find("Air").GetComponent<AirController>();
        lungCheckMg = GameObject.Find("Main Camera").GetComponent<LungCheckMg>();
        pause = true;
        

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("값:" + pause);
        countdown -= Time.deltaTime;
        CountDown(countdown);
        if(countdown <= 0.0f)   //준비 -> 촛불 불기
        {
            checktime -= Time.deltaTime;
            pause = false;
            GuideTextUI("촛불을 최대한 꺼주세요.");
            countdown_txt.gameObject.SetActive(false);
            if (checktime <= 0.0f) //6초가 지나면 
            {
                pause = true;       //게임 멈추자 (더이상 안불리게 즉 값 안들어오게)
                Time.timeScale = 0.0f; //시간 멈춰주고
                Result_txt.gameObject.SetActive(true);
                ResultTextUI("수치 : \n" + "꺼진 촛불 : " + LungCheckMg.candles + "개");
            }
        }
    }

    //카운트 다운 UI에 표시 준비 -> 0 
    void CountDown(float countdown)
    {
        int count = (int)countdown;
        countdown_txt.text = count.ToString();
    }
    
    void GuideTextUI(string str)
    {
        guide_txt.text = str;
    }

    void ResultTextUI(string str)
    {
        Result_txt.text = str;
    }
}
