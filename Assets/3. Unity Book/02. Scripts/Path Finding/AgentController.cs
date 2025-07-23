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
        //agent.SetDestination(player.transform.position); //목적지 설정
        agent.SetDestination(points[index].position); //목적지 설정
        
        if (agent.remainingDistance <= 1.5f) // 목적지와의 거리가 1.5 이하는 경우
        {
            Debug.Log("목적지 변경");

            int temp = index;
            index = Random.Range(0, points.Length);

            if (temp == index)
                index = Random.Range(0, points.Length);
        }
    }
}
