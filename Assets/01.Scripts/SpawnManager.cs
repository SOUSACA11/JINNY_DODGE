using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject [] prefabs; //���� �� ���� ������Ʈ

    private BoxCollider area; //�޽� �ݶ��̴� ������ ����
 
    private List<GameObject> ItemList = new List<GameObject>();

    private void Start()
    {
        area = GetComponent<BoxCollider>();

        InvokeRepeating("Spawn", 5, 3); // 5���Ŀ� 3�ʸ��� Spawn ȣ��

        area.enabled = false;
    }

    private Vector3 GetRandomPosition() //��ġ ����
    {
        Vector3 basePositon = transform.position;
        Vector3 size = area.size;

        float posX = basePositon.x + Random.Range(-size.x * 1/2f, size.x * 1/2f);
       
        float posZ = basePositon.z + Random.Range(-size.z * 1/2f, size.z * 1/2f);

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
