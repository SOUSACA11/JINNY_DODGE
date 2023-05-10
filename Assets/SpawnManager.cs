using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject [] prefabs; //생성 할 게임 오브젝트

    private BoxCollider area; //메쉬 콜라이더 사이즈 측정
    //public int count = 3; //생성 갯수

    
    private List<GameObject> ItemList = new List<GameObject>();

    private void Start()
    {
        area = GetComponent<BoxCollider>();

        StartCoroutine(itemspawn);

       // for(int i =0; i< count; ++i) // count 수 만큼 생성
        //{
          //  Spawn(); // 스폰에 생성
        //}

       // area.enabled = false;
    }

    IEnumerator 


    private Vector3 GetRandomPosition() //위치 설정
    {
        Vector3 basePositon = transform.position;
        Vector3 size = area.size;

        float posX = basePositon.x + Random.Range(-size.x * 1/2f, size.x * 0.5f);
       
        float posZ = basePositon.z + Random.Range(-size.z * 1/2f, size.z * 0.5f);

        Vector3 spawnPos = new Vector3(posX, 0, posZ);

        return spawnPos;
    }

    private void Spawn() //스폰 설정
    {
        int selection = Random.Range(0, prefabs.Length);
        
        GameObject selectedPrefab = prefabs[selection];

        Vector3 spawnPos = GetRandomPosition();

        GameObject instance = Instantiate(selectedPrefab, spawnPos, Quaternion.identity);

        ItemList.Add(instance); 
    }
}
