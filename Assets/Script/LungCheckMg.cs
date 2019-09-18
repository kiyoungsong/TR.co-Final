using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LungCheckMg : MonoBehaviour
{
    public static int candles = 0; //촛불 갯수 확인
    public SpriteRenderer fire; //촛불 값 가져오는거
    public GameObject Air; //촛불 끌때 필요한 바람
    AirController airController;

    void Awake()
    {
        candles = 0;
    }

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
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
