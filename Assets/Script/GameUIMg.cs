using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;
using System;

public class GameUIMg : MonoBehaviour
{
    public static string identify; //사용자가 누군지 확인
    public float countdown = 6.001f; //카운트 다운
    public float checktime = 3.501f; //측정시간
    public static int count = 0;
    public static int count2 = 0;
    string guide = "";
    [SerializeField] public Text countdown_txt; //카운트 다운 UI
    [SerializeField] public Text guide_txt; //가이드 UI
    [SerializeField] public Text Result_txt; //결과 UI
    [SerializeField] public Text Score_txt; //실시간 값 UI
    [SerializeField] public Button Nextcheckbt; //실시간 값 UI
    public bool pause = true; //게임일시 정지 여부
    public static string whichone = ""; //어느 검사인지 체크
    public bool IsInhale = false; //들숨인지 확인 false면 날숨 true면 들숨
    public static float[] mathScore = Enumerable.Repeat<float>(0, 1024).ToArray<float>();
    public static float exhaleSco;
    public static float inhaleSco;
    public static bool guideload = false; //가이드 씬 로드 됬는지 확인

    DateTime today = DateTime.Now;

    //다른 스크립트 접근
    AirController airController;
    LungCheckMg lungCheckMg;
    void Start()
    {
        if(count <= 2 || count2 <= 2)
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
        else if(pause == true && whichone == "Inhale")
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
                        //json파일 생성
                        ResultLungToJson lungToJson = new ResultLungToJson();
                        lungToJson.candle_count = LungCheckMg.candles.ToString();
                        lungToJson.Lung_Date = string.Format("{0:u}", today);
                        lungToJson.SaveToString(lungToJson);
                        string a = lungToJson.SaveToString(lungToJson);
                        lungToJson.CreateJsonFile(Application.dataPath, "resultLungcheck", a);
                        Debug.Log(lungToJson.SaveToString(lungToJson));

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
                    pause = false;
                    ScoreTextUI("현재 수치 :" + airController.count.ToString()); //실시간 값 보여주는 곳
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
                            Nextcheckbt.gameObject.SetActive(true);
                            Result_txt.gameObject.SetActive(true);
                            ResultTextUI("측정된 최대 값 : " + exhaleSco);
                            Debug.Log("최대값 확인 : " + exhaleSco);
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
            case "Inhale": //날숨과 동작은 모두 같음
                if(guideload == false)
                {
                    SceneManager.LoadScene("InhaleCheckGuideScene");
                }
                else
                {
                    Time.timeScale = 1.0f; //시간 돌게해주고
                    countdown -= Time.deltaTime;
                    CountDown(countdown);
                    Debug.Log(countdown);
                    Debug.LogWarning(count2);
                    if (countdown <= 0.0f)
                    {
                        Debug.LogWarning("체크1");
                        checktime -= Time.deltaTime;
                        pause = false;
                        ScoreTextUI("현재 수치 :" + airController.count.ToString()); //실시간 값 보여주는 곳
                        mathScore[count2] = airController.count;   //횟수 배열에 값넣어줌
                        MinScore(mathScore);                    //최소값 계산(결과는 *-1 해서 양수로 보임)
                        Debug.Log(airController.count); //확인
                        GuideTextUI("숨을 최대한 마쉬세요.");
                        countdown_txt.gameObject.SetActive(false);
                        Debug.LogWarning("체크2");
                        if (checktime <= 0.0f) // 3.5초가 지나면
                        {
                            Debug.LogWarning("체크3");
                            pause = true;   //게임 멈추자
                            Time.timeScale = 0.0f; //시간 멈춰주고
                            guideload = true;
                            if (count2 == 2)
                            {
                                Debug.LogWarning("체크4");
                                Result_txt.gameObject.SetActive(true);
                                ResultTextUI("날숨 수치 : " + exhaleSco + "\n" +
                                             "들숨 수치 : " + inhaleSco);
                                Debug.Log("최대값 : " + inhaleSco);
                                ResultBreathingToJson json = new ResultBreathingToJson();
                                json.exhaleScore = exhaleSco.ToString();
                                json.exhale_Date = string.Format("{0:u}", today);
                                json.inhaleScore = inhaleSco.ToString();
                                json.inhale_Date = string.Format("{0:u}", today);
                                json.SaveToString(json);
                                string a = json.SaveToString(json);
                                json.CreateJsonFile(Application.dataPath, "resultbreathingcheck", a);
                                Debug.Log(json.SaveToString(json));
                            }
                            else
                            {
                                Debug.Log("여기오니");
                                SceneManager.LoadScene("InhaleCheckScene");
                                whichone = "Inhale";
                                count2++;
                            }


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

    void ScoreTextUI(string str)
    {
        Score_txt.text = str;
    }
    
    void MaxScore(float[] flo) //최대값 체크 날숨시 (양수)
    {
        float max = float.MinValue;
        for(int i = 0; i < mathScore.Length; i++)
        {
            if(max < mathScore[i])
            {
                max = mathScore[i];
            }
        }
            exhaleSco = (float)Math.Truncate(max * 100.0f) / 100.0f;
    }

    void MinScore(float[] flo) //최소값 체크 들숨시(음수)
    {
        float max = float.MaxValue;
        for (int i = 0; i < mathScore.Length; i++)
        {
            if (max > mathScore[i])
            {
                max = mathScore[i];
            }
        }
        inhaleSco = (float)Math.Truncate(max*100.0f)/100.0f;
    }

}
