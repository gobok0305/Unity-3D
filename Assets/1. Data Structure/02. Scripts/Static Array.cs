using UnityEngine;

public class StaticArray : MonoBehaviour
{
    // �ڷ��� [ ] : ���� �迭
    public int[] array1; //�迭 ����
    public int[] array2 = { 10, 20, 30, 40, 50 }; //�迭 ����� �ʱ�ȭ
    public int[] array3 = new int[5]; //�迭 ���� �� ���� �Ҵ�
    public int[] array4 = new int[5] { 10, 20, 30, 40, 50 };//�迭 ���� �� ���� �Ҵ�� �ʱ�ȭ 

    private void Start()
    {
        //array1 = new int[5]; // �̷��� ���ص� ����Ƽ �����Ϳ� �ν����Ϳ��� ���� ����
        int number = array2[3]; // new ���� ���� �ȿ� �ִ� []�� �ε����� (������ ����), �ε����� 0���� ����
    }

    //NewData[] data = new NewData[5]; //new�� ������ []�� �迭�� ũ�⸦ ���� 

} 

//public class NewData
//{

//}