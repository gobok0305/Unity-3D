using System.Collections.Generic;
using UnityEngine;

public class StudyDictionary : MonoBehaviour
{
    public Dictionary<string, int> persons = new Dictionary<string, int>();


    private void Start()
    {
        //Dictionary에 데이터 추가
        persons.Add("철수", 10);
        persons.Add("영희", 15); //중복된 이름의 키값이 있으면 덮어써 버린다. / 뒤에 있는 값은 같아도 상관없음
        persons.Add("둥수", 17);

        persons["철수"] =13; //철수 나이 변경 (값을 덮어 씌운다)

        int age = persons["철수"]; //key 값으로 value를 출력!
        Debug.Log($" 철수의 나이는 {age}입니다. ");

        //string name = persons[15]; //15살인 누군가를 찾고 싶다!
        foreach (var person in persons)
        {
            if (person.Value == 15)
            {
                Debug.Log($"나이가 15인 사람의 이름은 {person.Key}입니다");
            }
            Debug.Log($"{person.Key}의 나이는 {person.Value}입니다.");


            if (persons.ContainsKey("철수"))
            {
                Debug.Log("사람 중에 철수가 있음");
            }

            if (persons.ContainsValue(17)) //true . false
            {
                Debug.Log("17살인 사람이 있다.");
            }
        }
    }
}
