using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AirController : MonoBehaviour
{
    GameUIMg gameuimg;
    private float speed = 10.0f;
    public int count = 0; //측정 값
    // Start is called before the first frame update
    void Start()
    {
        gameuimg = GameObject.Find("UI").GetComponent<GameUIMg>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow) == true && gameuimg.pause == false)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.World);
            count++;
        }
    }
}
