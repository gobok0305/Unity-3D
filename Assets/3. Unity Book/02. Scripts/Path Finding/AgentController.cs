using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class AgentController : MonoBehaviour
{
    /// <summary>
    /// ������ ����Ʈ�� �̵�
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


    /// ���콺�� Ŭ���ؼ� agent�� �̵�
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


    ///���� ����Ʈ �̵�
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
    //    //agent.SetDestination(player.transform.position); //������ ����
    //    agent.SetDestination(points[index].position); //������ ����

    //    if (agent.remainingDistance <= 1.5f) // ���������� �Ÿ��� 1.5 ���ϴ� ���
    //    {
    //        Debug.Log("������ ����");

    //        int temp = index;
    //        index = Random.Range(0, points.Length);

    //        if (temp == index)
    //            index = Random.Range(0, points.Length);
    //    }
    //}
}
