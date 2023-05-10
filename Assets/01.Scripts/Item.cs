using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public enum Type {Shield, Heart}; //������ �з�
    public Type type;
    public int value;
    
    private Rigidbody itemRigidbody;
    

    private void Start() 
    {
        
        itemRigidbody = GetComponent<Rigidbody>(); // ������ ������ٵ�
        itemRigidbody.velocity = transform.forward * 0.5f;

        Destroy(gameObject, 8f); //������ �ı�
    }

   
    private void OnTriggerEnter(Collider other) // Ʈ���� �浹 �� �ڵ����� ����Ǵ� �޼��� // OnTriggerEnter-�浹 �̺�Ʈ 
    {
        if (other.tag == "Player") //�浹�� ���� ���� ������Ʈ�� Player�� ���
        {

            Debug.Log("�Ҹ�");
            Destroy(gameObject); // �ڽ��� ���� ������Ʈ �ı�

        }
    }


}
