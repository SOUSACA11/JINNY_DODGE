using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject [] prefabs; //생성 할 게임 오브젝트

    private BoxCollider area; //메쉬 콜라이더 사이즈 측정
 
    private List<GameObject> ItemList = new List<GameObject>();

    private void Start()
    {
        area = GetComponent<BoxCollider>();

        InvokeRepeating("Spawn", 5, 3); // 5초후에 3초마다 Spawn 호출

        area.enabled = false;
    }

    private Vector3 GetRandomPosition() //위치 설정
    {
        Vector3 basePositon = transform.position;
        Vector3 size = area.size;

        float posX = basePositon.x + Random.Range(-size.x * 1/2f, size.x * 1/2f);
       
        float posZ = basePositon.z + Random.Range(-size.z * 1/2f, size.z * 1/2f);

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
