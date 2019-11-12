using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] Text username;

    string user_name ="송기영"; //여기에 로그인된 사용자 이름 저장해야됨 
    // Start is called before the first frame update
    void Start()
    {
        username.text = user_name; //로그인된 사용자 이름 보여주는 부분
    }
}
