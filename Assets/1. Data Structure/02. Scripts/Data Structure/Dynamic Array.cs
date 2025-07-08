using System.Collections.Generic;
using UnityEngine;

public class DynamicArray : MonoBehaviour
{
    public List<int> list1 = new List<int>();

    private void Start()
    {
        //list1.Add(10);// 데이터 추가 (마지막 값이 10 추가됨)

        for (int i = 1; i <= 10; i++) //1~10까지 값을 list1에 추가
        {
            list1.Add(i); //뒤에서 i를 추가
        }

        list1.Insert(5,100); //인덱스 5번에 값 100을 넣음

        if (list1.Contains(10))
        {
            Debug.Log("값 10이 존재 0");
        }
        else
        {
            Debug.Log("값 10이 존재 X");
        }
        
        
        
        ///3
        //string str = string.Empty;
        //foreach (var x in list1)
        //{
        //    str += x.ToString() + "/";
        //}

        //Debug.Log(str);
        
        
        
        
        
        //list1.Remove(5); //값 5를 제거
        //list1.RemoveAt(5); //인덱스 5번에 있는 값을 제거
        //list1.RemoveRange(1,3); //인덱스 1번에서부터 (1번 포함) 3개까지 제거
        
        //list1.RemoveAll(x => x > 5);//x는 굳이 x아니여도 상관없고 이런 식이 람다식!, x는 int타입! 
                                    // 현재 List안에서 x > 5값은 모두 제거

        //list1.Clear(); //데이터 모두 제거

        //list1.Sort(); // 오름차순 정렬

    }

    /// 1
    //private object[] array = new object[3]; //object: 어떤 타입이든 들어갈수 있는 최상위 객체
    //void Add(object o)
    //{
    //    int newSize = array.Length * 2; // 동적배열은 넉넉히 잡아야 해서 이런식으로 코드가 들어가긴해야 함
    //    var temp = new object[array.Length + 1];

    //    for (int i = 0; i < array.Length; i++)
    //    {
    //        temp[i] = array[i];
    //    }

    //    array = temp;
    //    array[array.Length -1] = o;
    //}

    /// 2
    //private List<int> list1 = new List<int>(); //실제로 쓸때는 new이하 모두 작성해줘야 함
    //private List<int> list2 = new List<int>() { 1, 2, 3, 4, 5 };

    //public List<int> list3; //원래 오류날법한데, 유니티 에디터에서 조절가능하니까 오류까지는 뜨지는 않음
    //// 퍼블릭은 그렇게 가능한데, 프라이빗으로 접근제한자 변경할 경우는 무조건 new이하 모두 붙혀주기

    //[SerializeField] private List<int> list4 = new List<int>();
    //public List<int> list5 = new List<int>();



    //private void Start()
    //{
    //    list1.Add(10);

    //    list2.Add(10);

    //    list3.Add(10);
    //}




}
