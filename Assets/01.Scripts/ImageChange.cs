using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageChange : MonoBehaviour

{
    //UI 내 이미지에 삽입할 스크립트

    public Sprite changeimg; //바꿀 이미지 
    Image thisImg;//현재 이미지

    void Start()
    {
        //이미지 컴포넌트 가져오기
        thisImg = GetComponent<Image>();
    }


    void Update()
    {
        //이미지 변호가 필요한 상황에서 사용
        thisImg.sprite = changeimg;
    }
}