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

    private void OnTriggerEnter(Collider other) // 트리거 충돌 시 자동으로 실행되는 메서드 // OnTriggerEnter-충돌 이벤트 메서드
    {
        if (other.tag == "Player") // 충돌한 상대방 게임 오브젝트가 playerController 컴포넌트 가져오기

        {
            PlayerController playerController = other.GetComponent<PlayerController>();

            if (playerController != null) // 상대방으로부터 playerController 컴포넌트를 가져오는 데 성공했다면

            {
                playerController.Die(); // 상대방 playerController 컴포넌트의 다이 메서드 실행
            }
        }

    }

}
