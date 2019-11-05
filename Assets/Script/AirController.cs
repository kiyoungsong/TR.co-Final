﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AirController : MonoBehaviour
{
    GameUIMg gameuimg;
    private float speed = 10.0f;
    public float count = 0.0f; //블루투스 기기에서 측정 값 여기에 저장해야됨
    // Start is called before the first frame update
    void Start()
    {
        gameuimg = GameObject.Find("UI").GetComponent<GameUIMg>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow) == true && gameuimg.pause == false && GameUIMg.whichone == "Exhale")
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.World);
            count++;
        }

        else if (Input.GetKeyDown(KeyCode.UpArrow) == true && gameuimg.pause == false && GameUIMg.whichone == "Inhale")
        {
            transform.Translate(-1 * Vector3.forward * speed * Time.deltaTime, Space.World);
            count--;
        }

        else if (Input.GetKeyDown(KeyCode.UpArrow) == true && gameuimg.pause == false && GameUIMg.whichone == "Lung")
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.World);
            count++;
        }
    }
}
