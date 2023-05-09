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

}
