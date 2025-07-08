using UnityEngine;

public class StudyString : MonoBehaviour
{
    public string str1 = " Hello World*** "; //얘는 그녕 스트링
    
    public string[] str2 = new string[3] { "Hello", "Unity", "world" }; // 얘는 스트링 배열

    private void Start()
    {
        //Debug.Log(str1[0]); // H
        //Debug.Log(str1[2]); // l

        //Debug.Log(str2[0]);//  Hello
        //Debug.Log(str2[2]);//  World

        //Debug.Log(str1.Length); // 문자열 길이 : 11
        //Debug.Log(str1.Trim()); //앞뒤 공백 제거: Hello World
        ////Debug.Log(str1.Trim('ㅣ')); //앞뒤 특정 문제 제거: Heo word (지금 L제거상황)
        //Debug.Log(str1.Trim('*')); //앞뒤 특정 문제 제거: 지금 *제거상황

        //Debug.Log(str1.Contains('H')); //대문자 H가 있는지
        //Debug.Log(str1.Contains('h')); // 소문자 h가 있는지

        //Debug.Log(str1.Contains("Hello")); //Hello가 있는지

        //Debug.Log(str1.ToUpper()); //대문자 변환
        //Debug.Log(str1.ToLower()); //소문자 변환

        //str1 = str1.Replace("World", "Unity"); //이걸 써줘야 원본데이터가 완전히 바뀜 (str1에 할당해줘야 함)
        //Debug.Log(str1.Replace(" World ", "Unity")); //월드를 유니티로 임시로 변경
        //Debug.Log(str1);

        string text = "Apple,Banana,Orange,Melon,Mango,Water Melon";

        string[] fruits = text.Split(','); //특정 문자로 쪼개기

        foreach (var fruit in fruits)
            Debug.Log(fruit);



    }
}
