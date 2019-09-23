using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;
using System;

public class GameUIMg : MonoBehaviour
{
    float countdown = 6.001f; //카운트 다운
    float checktime = 3.501f; //측정시간
    public static int count = 0;
    string guide = "";
    [SerializeField] public Text countdown_txt; //카운트 다운 UI
    [SerializeField] public Text guide_txt; //가이드 UI
    [SerializeField] public Text Result_txt; //결과 UI
    public bool pause = true; //게임일시 정지 여부
    public static string whichone = ""; //어느 검사인지 체크
    public bool IsInhale = false; //들숨인지 확인 false면 날숨 true면 들숨
    public static float[] mathScore = Enumerable.Repeat<float>(0, 1024).ToArray<float>();
    static float sco;

    //다른 스크립트 접근
    AirController airController;
    LungCheckMg lungCheckMg;

    void Start()
    {
        if(count <= 2)
        {
            pause = true;
        }
        Debug.Log("시작");
        Debug.Log(pause);
        Time.timeScale = 1.0f; //시간 돌게해주고
        if (pause == true && whichone == "Lung")//일시정지일때 확인
        {
            countdown = 6.001f;
            checktime = 7.001f;
            Debug.Log(checktime);
        }
        else if(pause == true && whichone == "Exhale")
        {
            countdown = 6.001f;
            checktime = 3.501f;
            Debug.Log(checktime);
        }

        airController = GameObject.Find("Air").GetComponent<AirController>();
        lungCheckMg = GameObject.Find("Main Camera").GetComponent<LungCheckMg>();
        
        Debug.Log("어느게임 : "+ whichone);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("count :" + count);
        switch (whichone)
        {
            case "Lung":
                countdown -= Time.deltaTime;
                CountDown(countdown);
                if (countdown <= 0.0f)   //준비 -> 촛불 불기
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
                else { }
                break;
            case "Exhale":
                Time.timeScale = 1.0f; //시간 돌게해주고
                countdown -= Time.deltaTime;
                CountDown(countdown);
                if (countdown <= 0.0f)
                {
                    checktime -= Time.deltaTime;
                    Debug.Log(checktime);
                    pause = false;
                    mathScore[count]=airController.count;   //횟수 배열에 값넣어줌
                    MaxScore(mathScore);                    //최대값 계산
                    Debug.Log(airController.count); //확인
                    GuideTextUI("공을 최대한 멀리 굴려주세요");
                    countdown_txt.gameObject.SetActive(false);
                    if(checktime <= 0.0f) // 3.5초가 지나면
                    {
                        pause = true;   //게임 멈추자
                        Time.timeScale = 0.0f; //시간 멈춰주고
                        if(count == 2)
                        {
                            Result_txt.gameObject.SetActive(true);
                            ResultTextUI("측정된 최대 값 : " + sco);
                            Debug.Log("최대값 확인 : " + sco);
                        }
                        else
                        {
                            SceneManager.LoadScene("ExhaleCheckScene");
                            whichone = "Exhale";
                            count++;
                        }
                        
                    }
                }
                break;
            default:
                break;

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
    
    void MaxScore(float[] flo)
    {
        float max = float.MinValue;
        for(int i = 0; i < mathScore.Length; i++)
        {
            if(max < mathScore[i])
            {
                max = mathScore[i];
            }
        }
        if(IsInhale) //들숨
        {
            sco = ((float)Math.Truncate(max * 100.0f) / 100.0f)*-1;
        }
        else
        {
            sco = (float)Math.Truncate(max * 100.0f) / 100.0f;
        }
    }
}
