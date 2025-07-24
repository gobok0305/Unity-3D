using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class AgentController : MonoBehaviour
{
    /// <summary>
    /// 정해진 포인트로 이동
    /// </summary>
    private NavMeshAgent agent;
    public Transform[] points;
    private int index;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(points[index].position);
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, points[index].position) < 1.5f)
        {
            index++;
            if (index >= points.Length)
            {
                index = 0;
            }
            
            agent.SetDestination(points[index].position);
        }
    }


    /// 마우스를 클릭해서 agent를 이동
    //public Camera camera;
    //private NavMeshAgent agent;
    //public NavMeshSurface surface;

    //private void Start()
    //{
    //    agent = GetComponent<NavMeshAgent>();
    //    surface.transform.position = agent.transform.position;
    //    surface.BuildNavMesh();
    //}

    //private void Update()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
    //        RaycastHit hit;

    //        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
    //        {
    //            agent.SetDestination(hit.point);
    //        }
    //    }

    //    if (Vector3.Distance(transform.position, surface.transform.position) > 4f)
    //    {
    //        surface.transform.position = agent.transform.position;
    //        surface.BuildNavMesh();
    //    }

    //}


    ///랜덤 포인트 이동
    //public Transform player;
    //private NavMeshAgent agent;

    //public Transform[] points;
    //public int index;

    //private void Start()
    //{
    //    agent = GetComponent<NavMeshAgent>();
    //    player = GameObject.Find("Player").transform;
    //}

    //private void Update()
    //{
    //    //agent.SetDestination(player.transform.position); //목적지 설정
    //    agent.SetDestination(points[index].position); //목적지 설정

    //    if (agent.remainingDistance <= 1.5f) // 목적지와의 거리가 1.5 이하는 경우
    //    {
    //        Debug.Log("목적지 변경");

    //        int temp = index;
    //        index = Random.Range(0, points.Length);

    //        if (temp == index)
    //            index = Random.Range(0, points.Length);
    //    }
    //}
}
