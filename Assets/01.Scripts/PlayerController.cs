using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody; //�̵��� ����� ������ٵ� ������Ʈ
    public float speed = 30f; //�̵��ӷ�


    //[SerializeField] �� ������ private�� �����ϰ� ������ ����Ƽ ������ �󿡼� �����ϰ��� �� ��
    [SerializeField] private float godTime = 1.0f; //���� ���� ���� �ð�
    [SerializeField] private float blinkTime = 0.1f;    //���� �����̴� �ֱ�
    [SerializeField] private MeshRenderer meshRenderer; //MeshRenderer ������Ʈ

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        //���� ������Ʈ���� Rigidbody ������Ʈ�� ã�� playerRigidbody�� �Ҵ�
    }


    void Update()
    {
        //������� �������� �Է°��� �����Ͽ� ����
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        //���� �̵� �ӵ��� �Է°��� �̵� �ӷ��� ����� ����
        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        //Vector3 �ӵ��� (xSpeed, 0, zSpeed)�� ����
        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);

        //������ٵ��� �ӵ��� newVelcovity �Ҵ�
        playerRigidbody.velocity = newVelocity;


    }


    //Ʈ���� �浹 �� �ڵ����� ����Ǵ� �޼��� /OnTriggerEnter-�浹 �̺�Ʈ �޼���
    private void OnTriggerEnter(Collider other)
    {
        if ((other.tag == "Bullet") && (this.tag == "Player")) //�浹�� ���� ���� ������Ʈ�� Bullet�̰�, �ڽ��� �±װ� Player�� ���
        {
            if(meshRenderer.enabled) // �޽� �������� Ȱ��ȭ�Ǿ� ���� ����
             Debug.Log("����"); //�浹�� ü�� -1
             HPManager.HP -= 1;
        }

        if (HPManager.HP == 0) // ü�� 0 �̸� ���� �޼��� �ߵ�
        {
            Die();
        }

        else if (other.tag == "Item") //�浹�� ���� ���� ������Ʈ�� Item�� ���
        {
            Debug.Log("����");
            this.gameObject.tag = "Untagged";

            //�ڷ�ƾ �Լ� - �Ͻ� ���� �� �ٸ� ���� �� �ٽ� ���� ���� �Լ�
            //�Ǵ� Update�� �ƴ� ������ �ݺ����� ������ �� �� ��� �Լ�
            //IEnumerator ��ȯ �������� ����
            //yield retrun �ݵ�� ����
            StartCoroutine(God(godTime)); //God �޼��忡 �ʿ��� �ð� ����godTime�� ����
        }
    }


    private IEnumerator God(float time)
    {
        float elapsedTime = 0f; //elapsedTime - ����� �ð�

        while (elapsedTime < time)
        {
            this.GetComponent<Renderer>().enabled = !this.GetComponent<Renderer>().enabled; //������Ʈ Ȱ��ȭ ����
            yield return new WaitForSeconds(0.1f);
            elapsedTime += 0.1f;
        }

        this.gameObject.tag = "Player";
        this.GetComponent<Renderer>().enabled = true;
    }



    public void Die()
        {
            gameObject.SetActive(false);
            // �ڽ��� ���� ������Ʈ ��Ȱ��ȭ

            GameManager gameManager = FindAnyObjectByType<GameManager>(); // ���� �����ϴ� GameManager Ÿ���� ������Ʈ�� ã�Ƽ� ��������
            gameManager.EndGame(); // ������ GameManager ������Ʈ�� EndGame() �޼��� ����

        }
    }
