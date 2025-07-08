using UnityEngine;

public class StaticArray : MonoBehaviour
{
    // 자료형 [ ] : 정적 배열
    public int[] array1; //배열 선언
    public int[] array2 = { 10, 20, 30, 40, 50 }; //배열 선언과 초기화
    public int[] array3 = new int[5]; //배열 선언 및 공간 할당
    public int[] array4 = new int[5] { 10, 20, 30, 40, 50 };//배열 선언 및 공간 할당과 초기화 

    private void Start()
    {
        //array1 = new int[5]; // 이렇게 안해도 유니티 에디터에 인스펙터에서 수정 가능
        int number = array2[3]; // new 없이 여기 안에 있는 []는 인덱서임 (순서를 말함), 인덱서는 0부터 시작
    }

    //NewData[] data = new NewData[5]; //new가 있으면 []는 배열의 크기를 말함 

} 

//public class NewData
//{

//}