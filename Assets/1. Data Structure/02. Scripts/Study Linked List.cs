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
            
            //stack.Push(i); // 1~10까지 값을  stack에 추가 / Push: 스택에 밀어 넣는다 == add
        }

        
        //Debug.Log(stack[5]); //인덱서 기능을 하지 못함 (무조건 차근차근 쌓이는 거라)
        //Debug.Log(stack.Pop()); // pop은 무조건 배열 중에 가장 마지막(last 값)에 있는 것을 골라온다
        //Debug.Log(stack.Count);

        //Debug.Log(stack.Peek()); //  그 다음에 뽑힐 대상을 확인(하고 다시 값을 돌려놓음
        //Debug.Log(stack.Count);
    }


    //public LinkedList<int> linkedList1 = new LinkedList<int>(); 
    //public LinkedListNode<int> node2; 


    //void Start()
    //{
    //   for (int i = 1; i <= 10; i++)
    //   {
    //        linkedList1.AddLast(i); //1~10까지 추가
    //   }

    //    linkedList1.AddFirst(100); //노드를 처음에 넣을지
    //    linkedList1.AddLast(500); //노드를 마지막에 넣을지

    //    var node = linkedList1.AddFirst(1);
    //    LinkedListNode<int> node2;


    //    linkedList1.AddBefore(node, 200); // 특정 노드의 전에 넣을 것인지
    //    linkedList1.AddAfter(node2, 300); //특정 노드의 후에 넣을 것인지
    //}



}
