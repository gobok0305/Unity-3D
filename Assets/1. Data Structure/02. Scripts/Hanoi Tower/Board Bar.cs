using System.Collections.Generic;
using UnityEngine;

public class BoardBar : MonoBehaviour
{
    public enum BarType { Left, Center, Right }
    public BarType barType;

    public Stack<GameObject> barStack = new Stack<GameObject>();

    void OnMouseDown() // Collider�� ������ ����
    {
        if (!HanoiTowerManager.isSelected) // ������ �ȵ� ������ ��
        {
            HanoiTowerManager.selectedDonut = PopDonut();
        }
        else // ���õ� ������ ��
        {
            PushDonut(HanoiTowerManager.selectedDonut);
        }
    }

    public bool CheckDonut(GameObject donut)
    {
        if (barStack.Count > 0)
        {
            int pushNumber = donut.GetComponent<Ring>().dountNumber;

            GameObject peekDonut = barStack.Peek();
            int peekNumber = peekDonut.GetComponent<Ring>().dountNumber;

            if (pushNumber < peekNumber)
            {
                return true;
            }
            else
            {
                Debug.Log($"���� �������� ������ {pushNumber}�̰�, �ش� ����� ���� ���� ������ {peekNumber}�Դϴ�.");
                return false;
            }
        }

        return true;
    }

    public void PushDonut(GameObject donut)
    {
        if (!CheckDonut(donut))
        return;

        HanoiTowerManager.moveCount++;
        HanoiTowerManager.isSelected = false;
        HanoiTowerManager.selectedDonut = null;

        donut.transform.position = transform.position + Vector3.up * 5f;
        donut.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
        donut.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

        barStack.Push(donut); // Stack�� GameObject�� �ִ� ���
    }

    public GameObject PopDonut()
    {
        if (barStack.Count > 0)
        {
            HanoiTowerManager.currBar = this;
            HanoiTowerManager.isSelected = true; // �ϳ��� Ÿ�� �Ŵ������� ������ ������ ��!
            GameObject donut = barStack.Pop(); // Stack���� GameObject�� ������ ���
            
           return donut; // ���� ������ ��ȯ
        }

        return null;
        


    }
}
