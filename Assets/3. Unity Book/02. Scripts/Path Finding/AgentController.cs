using UnityEngine;
using UnityEngine.AI;

public class AgentController : MonoBehaviour
{
    public Transform player;
    private NavMeshAgent agent;

    public Transform[] points;
    public int index;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player").transform;
    }

    private void Update()
    {
        //agent.SetDestination(player.transform.position); //������ ����
        agent.SetDestination(points[index].position); //������ ����
        
        if (agent.remainingDistance <= 1.5f) // ���������� �Ÿ��� 1.5 ���ϴ� ���
        {
            Debug.Log("������ ����");

            int temp = index;
            index = Random.Range(0, points.Length);

            if (temp == index)
                index = Random.Range(0, points.Length);
        }
    }
}
