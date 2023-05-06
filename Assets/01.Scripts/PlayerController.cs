using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody; // �̵��� ����� ������ٵ� ������Ʈ
    public float speed = 30f; // �̵��ӷ�

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        // ���� ������Ʈ���� Rigidbody ������Ʈ�� ã�� playerRigidbody�� �Ҵ�
    }


    void Update()
    {
        // ������� �������� �Է°��� �����Ͽ� ����
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        // ���� �̵� �ӵ��� �Է°��� �̵� �ӷ��� ����� ����
        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        // Vector3 �ӵ��� (xSpeed, 0, zSpeed)�� ����
        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);

        //������ٵ��� �ӵ��� newVelcovity �Ҵ�
        playerRigidbody.velocity = newVelocity;
    }

    public void Die() // �Ѿ��� ����
    {
        gameObject.SetActive(false);
        // �ڽ��� ���� ������Ʈ ��Ȱ��ȭ

        GameManager gameManager = FindAnyObjectByType<GameManager>(); // ���� �����ϴ� GameManager Ÿ���� ������Ʈ�� ã�Ƽ� ��������
        gameManager.EndGame(); // ������ GameManager ������Ʈ�� EndGame() �޼��� ����

    }
}

