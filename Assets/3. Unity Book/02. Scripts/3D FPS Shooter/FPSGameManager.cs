using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FPSGameManager : Singleton<FPSGameManager>
{
    public enum GameState { Ready, Run, Pause, GameOver}
    public GameState gState;

    public GameObject gameLabel;
    public GameObject gameOption;

    private TextMeshProUGUI gameText;

    private PlayerMoveing player;

    private void Start()
    {
        gState = GameState.Ready;
        gameText = gameLabel.GetComponent<TextMeshProUGUI>();

        gameText.text = "Ready....";
        gameText.color = new Color32(235, 185, 0, 255);

        player = GameObject.Find("Player").GetComponent<PlayerMoveing>();

        StartCoroutine(ReadyToStart()); // Ready -> Run으로 전환되는 코루틴
    }

    private void Update()
    {
        if (player.hp <= 0)
        {
            player.GetComponentInChildren<Animator>().SetFloat("MoveMotion", 0f);
            gameLabel.SetActive(true);
            gameText.text = "Game Over";
            gameText.color = new Color32(225, 0, 0, 255);

            //GetCild 기능이 할당에 문제가 될 수 있지만 공부를 위해 사용됨
            Transform buttons = gameText.transform.GetChild(0);
            buttons.gameObject.SetActive(true);

            gState = GameState.GameOver;
        }
    }

    IEnumerator ReadyToStart()
    {
        yield return new WaitForSeconds(2f); //2초 대기
        gameText.text = "Go!"; // 텍스트 변경

        yield return new WaitForSeconds(0.5f);
        gameLabel.SetActive(false);
        gState = GameState.Run; //상태 전환
    }

    public void OpenOptionWindow()
    {
        gameOption.SetActive(true); 
        Time.timeScale = 0f;  //실행 흐름이 멈추기는 하는데, UI동작 가능, 씬로드와 연관 없음
        gState = GameState.Pause;
    }

    public void CloseOptionWindow()
    {
        gameOption.SetActive(false);
        Time.timeScale = 1f;
        gState = GameState.Run;
    }

    public void ReStartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }    
}
