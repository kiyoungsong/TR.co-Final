using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LungCheckMg : MonoBehaviour
{
    public static int candles = 0; //촛불 갯수 확인
    public SpriteRenderer fire; //촛불 값 가져오는거
    public GameObject Air; //촛불 끌때 필요한 바람
    public static float Liters; //블루투스로 측정된 값 가져오는 부분 리터형식으로 소숫점 둘째짜리까지 보여야함.
    AirController airController;

    void Awake()
    {
        candles = 0;
    }

    //촛불 통과하면 촛불꺼짐
    void OnTriggerExit(Collider other)
    {
        if(fire.gameObject.tag == "fire")
        {
            fire.enabled = false;
            candles++;
        }
    }
    //바람 삭제
    private void OnCollisionEnter(Collision other)
    {
        Destroy(Air);
    }
}
