using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPManager : MonoBehaviour
{
    public static int HP = 3; //HP�� 3��

    public GameObject life1;
    public GameObject life2;
    public GameObject life3;


    void Start()
    {
        // ��������Ʈ ������ ���¿��� �̹��� ���̱�/�����
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
