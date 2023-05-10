using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject [] prefabs; //���� �� ���� ������Ʈ

    private BoxCollider area; //�޽� �ݶ��̴� ������ ����
    //public int count = 3; //���� ����

    
    private List<GameObject> ItemList = new List<GameObject>();

    private void Start()
    {
        area = GetComponent<BoxCollider>();

        StartCoroutine(itemspawn);

       // for(int i =0; i< count; ++i) // count �� ��ŭ ����
        //{
          //  Spawn(); // ������ ����
        //}

       // area.enabled = false;
    }

    IEnumerator 


    private Vector3 GetRandomPosition() //��ġ ����
    {
        Vector3 basePositon = transform.position;
        Vector3 size = area.size;

        float posX = basePositon.x + Random.Range(-size.x * 1/2f, size.x * 0.5f);
       
        float posZ = basePositon.z + Random.Range(-size.z * 1/2f, size.z * 0.5f);

        Vector3 spawnPos = new Vector3(posX, 0, posZ);

        return spawnPos;
    }

    private void Spawn() //���� ����
    {
        int selection = Random.Range(0, prefabs.Length);
        
        GameObject selectedPrefab = prefabs[selection];

        Vector3 spawnPos = GetRandomPosition();

        GameObject instance = Instantiate(selectedPrefab, spawnPos, Quaternion.identity);

        ItemList.Add(instance); 
    }
}
