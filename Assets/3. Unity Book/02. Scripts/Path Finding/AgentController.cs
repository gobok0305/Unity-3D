<<<<<<< HEAD
using Unity.AI.Navigation;
=======
>>>>>>> parent of f6e4bcf (3FPS Shooter (517~551p))
using UnityEngine;
using UnityEngine.AI;

public class AgentController : MonoBehaviour
{
<<<<<<< HEAD
    /// <summary>
    /// ������ ����Ʈ�� �̵�
    /// </summary>
    private NavMeshAgent agent;
    public Transform[] points;
    private int index;
=======
    public Transform player;
    private NavMeshAgent agent;

    public Transform[] points;
    public int index;
>>>>>>> parent of f6e4bcf (3FPS Shooter (517~551p))

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
<<<<<<< HEAD
        agent.SetDestination(points[index].position);
=======
        player = GameObject.Find("Player").transform;
>>>>>>> parent of f6e4bcf (3FPS Shooter (517~551p))
    }

    void Update()
    {
<<<<<<< HEAD
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
=======
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
>>>>>>> parent of f6e4bcf (3FPS Shooter (517~551p))
}
