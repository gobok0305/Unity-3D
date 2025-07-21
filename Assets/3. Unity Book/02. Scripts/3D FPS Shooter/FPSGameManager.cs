using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FPSGameManager : Singleton<FPSGameManager>
{
    public enum GameState { Ready, Run, GameOver}
    public GameState gState;

    public GameObject gameLabel;
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
            gameLabel.SetActive(true);
            gameText.text = "Game Over";
            gameText.color = new Color32(225, 0, 0, 255);

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
}
