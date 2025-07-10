using UnityEngine;

public class PoolObject : MonoBehaviour
{
    
    private ObjectPoolQueue pool; // 총알이 돌아갈 pool장
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
