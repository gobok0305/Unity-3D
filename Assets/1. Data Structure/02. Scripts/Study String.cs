using UnityEngine;

public class StudyString : MonoBehaviour
{
    public string str1 = " Hello World*** "; //��� �׳� ��Ʈ��
    
    public string[] str2 = new string[3] { "Hello", "Unity", "world" }; // ��� ��Ʈ�� �迭

    private void Start()
    {
        //Debug.Log(str1[0]); // H
        //Debug.Log(str1[2]); // l

        //Debug.Log(str2[0]);//  Hello
        //Debug.Log(str2[2]);//  World

        //Debug.Log(str1.Length); // ���ڿ� ���� : 11
        //Debug.Log(str1.Trim()); //�յ� ���� ����: Hello World
        ////Debug.Log(str1.Trim('��')); //�յ� Ư�� ���� ����: Heo word (���� L���Ż�Ȳ)
        //Debug.Log(str1.Trim('*')); //�յ� Ư�� ���� ����: ���� *���Ż�Ȳ

        //Debug.Log(str1.Contains('H')); //�빮�� H�� �ִ���
        //Debug.Log(str1.Contains('h')); // �ҹ��� h�� �ִ���

        //Debug.Log(str1.Contains("Hello")); //Hello�� �ִ���

        //Debug.Log(str1.ToUpper()); //�빮�� ��ȯ
        //Debug.Log(str1.ToLower()); //�ҹ��� ��ȯ

        //str1 = str1.Replace("World", "Unity"); //�̰� ����� ���������Ͱ� ������ �ٲ� (str1�� �Ҵ������ ��)
        //Debug.Log(str1.Replace(" World ", "Unity")); //���带 ����Ƽ�� �ӽ÷� ����
        //Debug.Log(str1);

        string text = "Apple,Banana,Orange,Melon,Mango,Water Melon";

        string[] fruits = text.Split(','); //Ư�� ���ڷ� �ɰ���

        foreach (var fruit in fruits)
            Debug.Log(fruit);



    }
}
