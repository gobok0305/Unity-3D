using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StudyStack : MonoBehaviour
{
    public Stack<int> stack = new Stack<int>();
    public List<int> list1 = new List<int>();

    public int[] array = new int[3] { 1, 2, 3 };
    public int[] array2;
    
    private void Start()
    {
        for (int i = 1; i <= 10; i++)
        {
            stack = new Stack<int>(array);

            array2 = stack.ToArray();
            list1 = stack.ToList();
            
            //stack.Push(i); // 1~10���� ����  stack�� �߰� / Push: ���ÿ� �о� �ִ´� == add
        }

        
        //Debug.Log(stack[5]); //�ε��� ����� ���� ���� (������ �������� ���̴� �Ŷ�)
        //Debug.Log(stack.Pop()); // pop�� ������ �迭 �߿� ���� ������(last ��)�� �ִ� ���� ���´�
        //Debug.Log(stack.Count);

        //Debug.Log(stack.Peek()); //  �� ������ ���� ����� Ȯ��(�ϰ� �ٽ� ���� ��������
        //Debug.Log(stack.Count);
    }


    //public LinkedList<int> linkedList1 = new LinkedList<int>(); 
    //public LinkedListNode<int> node2; 


    //void Start()
    //{
    //   for (int i = 1; i <= 10; i++)
    //   {
    //        linkedList1.AddLast(i); //1~10���� �߰�
    //   }

    //    linkedList1.AddFirst(100); //��带 ó���� ������
    //    linkedList1.AddLast(500); //��带 �������� ������

    //    var node = linkedList1.AddFirst(1);
    //    LinkedListNode<int> node2;


    //    linkedList1.AddBefore(node, 200); // Ư�� ����� ���� ���� ������
    //    linkedList1.AddAfter(node2, 300); //Ư�� ����� �Ŀ� ���� ������
    //}



}
