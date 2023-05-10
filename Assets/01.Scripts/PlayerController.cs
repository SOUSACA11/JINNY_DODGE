using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody; //이동에 사용할 리지드바디 컴포넌트
    public float speed = 30f; //이동속력


    //[SerializeField] 는 변수를 private로 선언하고 싶지만 유니티 에디터 상에서 수정하고자 할 떄
    [SerializeField] private float godTime = 1.0f; //무적 상태 지속 시간
    [SerializeField] private float blinkTime = 0.1f;    //무적 깜박이는 주기
    [SerializeField] private MeshRenderer meshRenderer; //MeshRenderer 컴포넌트

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        //게임 오브젝트에서 Rigidbody 컴포넌트를 찾아 playerRigidbody에 할당
    }


    void Update()
    {
        //수평축과 수직축의 입력값을 감지하여 저장
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        //실제 이동 속도를 입력값과 이동 속력을 사용해 결정
        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        //Vector3 속도를 (xSpeed, 0, zSpeed)로 생성
        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);

        //리지드바디의 속도에 newVelcovity 할당
        playerRigidbody.velocity = newVelocity;


    }


    //트리거 충돌 시 자동으로 실행되는 메서드 /OnTriggerEnter-충돌 이벤트 메서드
    private void OnTriggerEnter(Collider other)
    {
        if ((other.tag == "Bullet") && (this.tag == "Player")) //충돌한 상대방 게임 오브젝트가 Bullet이고, 자신의 태그가 Player일 경우
        {
            if(meshRenderer.enabled) // 메쉬 렌더러가 활성화되어 있을 떄만
             Debug.Log("맞음"); //충돌시 체력 -1
             HPManager.HP -= 1;
        }

        if (HPManager.HP == 0) // 체력 0 이면 다이 메서드 발동
        {
            Die();
        }

        else if (other.tag == "Item") //충돌한 상대방 게임 오브젝트가 Item일 경우
        {
            Debug.Log("무적");
            this.gameObject.tag = "Untagged";

            //코루틴 함수 - 일시 중지 후 다른 동작 후 다시 시작 가능 함수
            //또는 Update가 아닌 곳에서 반복문을 쓰고자 할 떄 사용 함수
            //IEnumerator 반환 형식으로 시작
            //yield retrun 반드시 존재
            StartCoroutine(God(godTime)); //God 메서드에 필요한 시간 변수godTime로 선언
        }
    }


    private IEnumerator God(float time)
    {
        float elapsedTime = 0f; //elapsedTime - 경과된 시간

        while (elapsedTime < time)
        {
            this.GetComponent<Renderer>().enabled = !this.GetComponent<Renderer>().enabled; //컴포넌트 활성화 반전
            yield return new WaitForSeconds(0.1f);
            elapsedTime += 0.1f;
        }

        this.gameObject.tag = "Player";
        this.GetComponent<Renderer>().enabled = true;
    }



    public void Die()
        {
            gameObject.SetActive(false);
            // 자신의 게임 오브젝트 비활성화

            GameManager gameManager = FindAnyObjectByType<GameManager>(); // 씬에 존재하는 GameManager 타입의 오브젝트를 찾아서 가져오기
            gameManager.EndGame(); // 기져온 GameManager 오브젝트의 EndGame() 메서드 실행

        }
    }
