using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageChange : MonoBehaviour

{
    //UI �� �̹����� ������ ��ũ��Ʈ

    public Sprite changeimg; //�ٲ� �̹��� 
    Image thisImg;//���� �̹���

    void Start()
    {
        //�̹��� ������Ʈ ��������
        thisImg = GetComponent<Image>();
    }


    void Update()
    {
        //�̹��� ��ȣ�� �ʿ��� ��Ȳ���� ���
        thisImg.sprite = changeimg;
    }
}