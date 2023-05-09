using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public enum Type { Shield, Heart}; //������ �з�
    public Type type;
    public int value;
    
    private Rigidbody itemRigidbody;
    

    private void Start() // ������ ������ٵ�
    {
        itemRigidbody = GetComponent<Rigidbody>();
        itemRigidbody.velocity = transform.forward * 0.5f;
        Destroy(gameObject, 5f);
    }


}
