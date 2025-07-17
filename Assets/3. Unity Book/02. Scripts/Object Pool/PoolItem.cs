using UnityEngine;
using UnityEngine.Pool;

public class PoolItem : MonoBehaviour
{
    private PoolManager poolManager;
    private bool isInit = false;

    void Awake()
    {
        poolManager = GameObject.FindFirstObjectByType<PoolManager>();
    }

    private void Enable()
    {
        if (!isInit)
            isInit = true;
        else
            Invoke("ReturnObject", 2f);
    }

    private void ReturnObject()
    {
        poolManager.pool.Release(gameObject);
    }
}
