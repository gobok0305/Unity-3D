using System.Collections.Generic;
using UnityEngine;

public class StudyDictionary : MonoBehaviour
{
    public Dictionary<string, int> persons = new Dictionary<string, int>();


    private void Start()
    {
        //Dictionary�� ������ �߰�
        persons.Add("ö��", 10);
        persons.Add("����", 15); //�ߺ��� �̸��� Ű���� ������ ����� ������. / �ڿ� �ִ� ���� ���Ƶ� �������
        persons.Add("�ռ�", 17);

        persons["ö��"] =13; //ö�� ���� ���� (���� ���� �����)

        int age = persons["ö��"]; //key ������ value�� ���!
        Debug.Log($" ö���� ���̴� {age}�Դϴ�. ");

        //string name = persons[15]; //15���� �������� ã�� �ʹ�!
        foreach (var person in persons)
        {
            if (person.Value == 15)
            {
                Debug.Log($"���̰� 15�� ����� �̸��� {person.Key}�Դϴ�");
            }
            Debug.Log($"{person.Key}�� ���̴� {person.Value}�Դϴ�.");


            if (persons.ContainsKey("ö��"))
            {
                Debug.Log("��� �߿� ö���� ����");
            }

            if (persons.ContainsValue(17)) //true . false
            {
                Debug.Log("17���� ����� �ִ�.");
            }
        }
    }
}
