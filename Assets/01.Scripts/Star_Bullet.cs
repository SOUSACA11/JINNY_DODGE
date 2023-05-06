using UnityEngine;

public class Star_Bullet : MonoBehaviour
{
    public float speed = 8f; // ź�� �̵� �ӷ�
    private Rigidbody bulletRigidbody; // �̵��� ����� ������ٵ� ������Ʈ

    void Start()
    {
        bulletRigidbody = GetComponent<Rigidbody>();
        // ���� ������Ʈ���� ������ٵ� ������Ʈ�� ã�� bulletRigidbody�� �Ҵ�

        bulletRigidbody.velocity = transform.forward * speed;
        // ������ٵ� �ӵ� = ���� ���� * �̵� �ӷ�

        Destroy(gameObject, 3f);
        // 3�� �ڿ� �ڽ��� ���� ������Ʈ �ı�
    }

    private void OnTriggerEnter(Collider other) // Ʈ���� �浹 �� �ڵ����� ����Ǵ� �޼��� // OnTriggerEnter-�浹 �̺�Ʈ �޼���
    {
        if (other.tag == "Player") // �浹�� ���� ���� ������Ʈ�� playerController ������Ʈ ��������

        {
            PlayerController playerController = other.GetComponent<PlayerController>();

            if (playerController != null) // �������κ��� playerController ������Ʈ�� �������� �� �����ߴٸ�

            {
                playerController.Die(); // ���� playerController ������Ʈ�� ���� �޼��� ����
            }
        }

    }

}
