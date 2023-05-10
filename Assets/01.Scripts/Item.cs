using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public enum Type {Shield, Heart}; //아이템 분류
    public Type type;
    public int value;
    
    private Rigidbody itemRigidbody;
    

    private void Start() 
    {
        
        itemRigidbody = GetComponent<Rigidbody>(); // 아이템 리지드바디
        itemRigidbody.velocity = transform.forward * 0.5f;

        Destroy(gameObject, 8f); //아이템 파괴
    }

   
    private void OnTriggerEnter(Collider other) // 트리거 충돌 시 자동으로 실행되는 메서드 // OnTriggerEnter-충돌 이벤트 
    {
        if (other.tag == "Player") //충돌한 상대방 게임 오브젝트가 Player일 경우
        {

            Debug.Log("소멸");
            Destroy(gameObject); // 자신의 게임 오브젝트 파괴

        }
    }


}
