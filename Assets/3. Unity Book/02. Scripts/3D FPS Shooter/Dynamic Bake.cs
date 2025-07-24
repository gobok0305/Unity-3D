using UnityEngine;
using UnityEngine.AI;

public class DynamicBake : MonoBehaviour
{
    private NavMeshAgent agent;
    private Vector3 originPos;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        originPos = transform.position;
    }

    
    void Update()
    {
        float h = Input.GetAxis("Horizontal");    
        float v = Input.GetAxis("Vertical");

        var dir = new Vector3(h, 0, v);
        dir = dir.normalized;

        agent.SetDestination(dir);
    }
}
