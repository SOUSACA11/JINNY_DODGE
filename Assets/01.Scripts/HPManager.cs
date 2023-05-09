using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPManager : MonoBehaviour
{
    public static int HP = 3; //HP는 3개

    public GameObject life1;
    public GameObject life2;
    public GameObject life3;


    void Start()
    {
        // 스프라이트 생성한 상태에서 이미지 보이기/숨기기
        life1.GetComponent<Image>().enabled = true;
        life2.GetComponent<Image>().enabled = true;
        life3.GetComponent<Image>().enabled = true;
    }

    void Update()
    {
        switch (HP)
        {
            case 2:
                life3.GetComponent<Image>().enabled = false;
                break;
            case 1:
                life2.GetComponent<Image>().enabled = false;
                break;
            case 0:
                life1.GetComponent<Image>().enabled = false;
                break;
         
        }
    }
}
