using UnityEngine;
using UnityEngine.UI; // UI 관련 라이브러리
using UnityEngine.SceneManagement; // 신 관리 관련 라이브러리

public class GameManager : MonoBehaviour
{
    public GameObject gameoverText; // 게임오버 시 활성화할 텍스트 게임 오브젝트
    public Text timeText; // 생존 시간을 표시할 텍스트 컴포넌트
    public Text recordText; // 최고 기록을 표시할 테스트 컴포넌트

    private float surviveTime; // 생존시간
    private bool isGameover; //게임오버 상태
    void Start()
    {
        surviveTime = 0;
        isGameover = false;
        // 생존 시간과 게임오버 상태 초기화
    }


    void Update()
    {
        if (!isGameover) // 게임오버가 아닌 동안
        {
            surviveTime += Time.deltaTime; // 생존 시간 갱신
            timeText.text = "Time : " + (int)surviveTime; // 갱신한 생존 시간을 timeText 텍스트 컴포넌트를 이용해 표시
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.P)) // 게임오버 상태에서 P키를 누른 경우
            {
                SceneManager.LoadScene("GameStage"); // GameStage 씬을 로드
            }
        }
    }

    public void EndGame() // 현재 게임을 게임오버 상태롤 변경하는 메서드
    {
        isGameover = true; // 현재 상태를 게임오버 상태로 전환
        gameoverText.SetActive(true); // 게임오버 텍스트 게임 오브젝트를 활성화

        float bestTime = PlayerPrefs.GetFloat("최고 기록"); // 최고기록 키로 저장된 이전까지의 최고 기록 가져오기

        if (surviveTime > bestTime)
        {
            bestTime = surviveTime; // 최고 기록 값을 현재 생존 시간 값으로 변경
            PlayerPrefs.SetFloat("최고 기록", bestTime); // 변경된 최고 기록을 BestTime 키로 저장
        }

        recordText.text = "최고 기록 : " + (int)bestTime; // 최고 기록을 rexordText 텍스트 컴포넌트를 이용해 표시
    }
}
