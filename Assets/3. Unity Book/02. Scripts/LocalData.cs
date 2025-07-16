using UnityEngine;

public class LocalData : MonoBehaviour
{
    private int score;

    private void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            score++;

            // 로컬 데이터 저장 (내 컴퓨터에 저장)
            PlayerPrefs.SetInt("Score", score);

            int loadScore = PlayerPrefs.GetInt("Score");
            
            PlayerPrefs.SetInt("Score", score);
            PlayerPrefs.SetFloat("Volume", 0.5f);
            PlayerPrefs.SetString("UserName", "Noey");

            PlayerPrefs.DeleteKey("Score");
            PlayerPrefs.DeleteKey("Volume");
            PlayerPrefs.DeleteKey("Username");

            PlayerPrefs.DeleteAll();

            PlayerPrefs.Save(); // 종료 될때 자동실행
        }
    }
}
