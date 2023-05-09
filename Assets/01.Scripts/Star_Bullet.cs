using UnityEngine;

public class Star_Bullet : MonoBehaviour
{
    public float speed = 8f; // 탄알 이동 속력
    private Rigidbody bulletRigidbody; // 이동에 사용할 리지드바디 컴포넌트

    void Start()
    {
        bulletRigidbody = GetComponent<Rigidbody>();
        // 게임 오브젝트에서 리지드바디 컴포넌트를 찾아 bulletRigidbody에 할당

        bulletRigidbody.velocity = transform.forward * speed;
        // 리지드바디 속도 = 앞쪽 방향 * 이동 속력

        Destroy(gameObject, 3f);
        // 3초 뒤에 자신의 게임 오브젝트 파괴
    }

}
