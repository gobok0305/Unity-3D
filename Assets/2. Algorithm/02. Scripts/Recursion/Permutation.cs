using NUnit.Framework;
using UnityEngine;

public class Permutation : MonoBehaviour
{
    public int[] array = new int[3] { 1, 2, 3 }; //�ڸ��ٲٱ� �ϴ� ��

    private void Start()
    {
        PermutationFuntion(array, 0); // ��ŸƮ ��
    }

    private void PermutationFuntion(int[] arr, int start)
    {
        if (start == arr.Length) //3�̵Ǹ� ���� ���ڴ�
        {
            Debug.Log(string.Join(",", arr)); // ,������ �ε����� �ִ� ���� �α׷� �ۼ�����
            return;
        }

        for (int i = start; i < arr.Length; i++)
        {
            // swap: �ڸ� �ٲٱ�
            var temp = arr[start];
            arr[start] = arr[i];
            arr[i] = temp;

            PermutationFuntion(arr, start + 1);//��� ����� �� �̾Ƴ���(���)

            //���󺹱� backtracking
            temp = arr[start];
            arr[start] = arr[i];
            arr[i] = temp;
        }
    }
}
