using System.Collections;
using TMPro;
using UnityEngine;

public class HanoiTowerManager : MonoBehaviour
{
    public enum HanoiLevel { Lv1 = 3, Lv2, Lv3 }
    public HanoiLevel hanoiLevel;

    public TextMeshProUGUI countTextUI;

    public GameObject[] donutPrefabs;
    public BoardBar[] bars; // L, C, R

    public static GameObject selectedDonut;
    public static bool isSelected;
    public static BoardBar currBar;
    public static int moveCount;
    

    IEnumerator Start()
    {
        for (int i = (int)hanoiLevel - 1; i >= 0; i--) // 반복문으로 Level만큼 도넛 생성
        {
            GameObject donut = Instantiate(donutPrefabs[i]); // 도넛 생성
            donut.transform.position = new Vector3(-5f, 5f, 0); // 도넛 생성 위치 : 왼쪽 막대기 + 위쪽

            bars[0].PushDonut(donut); // 방금 생성한 도넛을 해당 Bar의 Stack Push
            moveCount = 0;

            yield return new WaitForSeconds(1f); // 순차적으로 생성
        }

        //이런 식으로 와도 괜찮음! 
        //moveCount = 0;
        //countTextUI.text = moveCount.ToString();
    }

    private void Update() //esc로 초기화
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            currBar.barStack.Push(selectedDonut);
            
            isSelected = false;
            selectedDonut = null;
        }

        //원래라면 안넣는것이 맞지만, 갱신을 쉽게 하기 위해서 여기에다가 넣음
        countTextUI.text = moveCount.ToString();
    }

}

