using UnityEngine;

public class SelectionSort : MonoBehaviour
{
    private int[] array = { 5, 2, 1, 8, 3, 7, 6, 4 };

    private void Start()
    {
        Debug.Log("정렬 전: " + string.Join(",", array));

        Selection(array);
        Debug.Log("정렬 후: " + string.Join(",", array));
    }

    void Selection(int[] arr)
    {
        int n = arr.Length;

        for (int i = 0; i < n - 1; i++) //특정 값 선택 // i : 선택한 인덱스 값
        {
            int minIdx = i;



            for (int j = i + 1; j < n; j++) // 뒤에 있는 값들과 비교 //j:  비교할 인덱스
            {
                if (arr[j] < arr[minIdx])
                {
                    minIdx = j;
                }
            }

            int temp = arr[i];
            arr[i] = arr[minIdx];
            arr[minIdx] = temp;
        }

    }
}
