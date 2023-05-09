using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public enum Type { Shield, Heart}; //아이템 분류
    public Type type;
    public int value;
    
    private Rigidbody itemRigidbody;
    

    private void Start() // 아이템 리지드바디
    {
        itemRigidbody = GetComponent<Rigidbody>();
        itemRigidbody.velocity = transform.forward * 0.5f;
        Destroy(gameObject, 5f);
    }


}
