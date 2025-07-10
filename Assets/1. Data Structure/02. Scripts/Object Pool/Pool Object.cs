using UnityEngine;

public class PoolObject : MonoBehaviour
{
    
    private ObjectPoolQueue pool; // �Ѿ��� ���ư� pool��
    public float bulletSpeed = 100f;

    private void Awake()
    {
        pool = FindFirstObjectByType<ObjectPoolQueue>();
    }

    private void OnEnable()
    {
        Invoke("ReturnPool", 3f);
    }

    void Update()
    {
        transform.position += Vector3.forward * Time.deltaTime * bulletSpeed;
    }


    private void OnDisable()
    {
        pool.EnqueueObject(gameObject);
    }
}
