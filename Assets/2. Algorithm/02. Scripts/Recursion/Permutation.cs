using NUnit.Framework;
using UnityEngine;

public class Permutation : MonoBehaviour
{
    public int[] array = new int[3] { 1, 2, 3 }; //자리바꾸기 하는 것

    private void Start()
    {
        PermutationFuntion(array, 0); // 스타트 값
    }

    private void PermutationFuntion(int[] arr, int start)
    {
        if (start == arr.Length) //3이되면 끝을 내겠다
        {
            Debug.Log(string.Join(",", arr)); // ,붙혀서 인덱스에 있는 값을 로그로 작성해줌
            return;
        }

        for (int i = start; i < arr.Length; i++)
        {
            // swap: 자리 바꾸기
            var temp = arr[start];
            arr[start] = arr[i];
            arr[i] = temp;

            PermutationFuntion(arr, start + 1);//모든 경우의 수 뽑아내기(재귀)

            //원상복구 backtracking
            temp = arr[start];
            arr[start] = arr[i];
            arr[i] = temp;
        }
    }
}
