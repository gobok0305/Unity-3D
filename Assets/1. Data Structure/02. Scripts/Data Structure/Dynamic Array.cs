using System.Collections.Generic;
using UnityEngine;

public class DynamicArray : MonoBehaviour
{
    public List<int> list1 = new List<int>();

    private void Start()
    {
        //list1.Add(10);// ������ �߰� (������ ���� 10 �߰���)

        for (int i = 1; i <= 10; i++) //1~10���� ���� list1�� �߰�
        {
            list1.Add(i); //�ڿ��� i�� �߰�
        }

        list1.Insert(5,100); //�ε��� 5���� �� 100�� ����

        if (list1.Contains(10))
        {
            Debug.Log("�� 10�� ���� 0");
        }
        else
        {
            Debug.Log("�� 10�� ���� X");
        }
        
        
        
        ///3
        //string str = string.Empty;
        //foreach (var x in list1)
        //{
        //    str += x.ToString() + "/";
        //}

        //Debug.Log(str);
        
        
        
        
        
        //list1.Remove(5); //�� 5�� ����
        //list1.RemoveAt(5); //�ε��� 5���� �ִ� ���� ����
        //list1.RemoveRange(1,3); //�ε��� 1���������� (1�� ����) 3������ ����
        
        //list1.RemoveAll(x => x > 5);//x�� ���� x�ƴϿ��� ������� �̷� ���� ���ٽ�!, x�� intŸ��! 
                                    // ���� List�ȿ��� x > 5���� ��� ����

        //list1.Clear(); //������ ��� ����

        //list1.Sort(); // �������� ����

    }

    /// 1
    //private object[] array = new object[3]; //object: � Ÿ���̵� ���� �ִ� �ֻ��� ��ü
    //void Add(object o)
    //{
    //    int newSize = array.Length * 2; // �����迭�� �˳��� ��ƾ� �ؼ� �̷������� �ڵ尡 �����ؾ� ��
    //    var temp = new object[array.Length + 1];

    //    for (int i = 0; i < array.Length; i++)
    //    {
    //        temp[i] = array[i];
    //    }

    //    array = temp;
    //    array[array.Length -1] = o;
    //}

    /// 2
    //private List<int> list1 = new List<int>(); //������ ������ new���� ��� �ۼ������ ��
    //private List<int> list2 = new List<int>() { 1, 2, 3, 4, 5 };

    //public List<int> list3; //���� ���������ѵ�, ����Ƽ �����Ϳ��� ���������ϴϱ� ���������� ������ ����
    //// �ۺ��� �׷��� �����ѵ�, �����̺����� ���������� ������ ���� ������ new���� ��� �����ֱ�

    //[SerializeField] private List<int> list4 = new List<int>();
    //public List<int> list5 = new List<int>();



    //private void Start()
    //{
    //    list1.Add(10);

    //    list2.Add(10);

    //    list3.Add(10);
    //}




}
