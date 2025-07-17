using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.Pool;

public class PoolManager : MonoBehaviour
{
    public ObjectPool<GameObject> pool;
    public GameObject prefab;
    void Awake()
    {
        //���� - �������� - ����ִ� ��� ����
        pool = new ObjectPool<GameObject>(CreateObject, OnGetObject, OnReleaseObject, OnDestroyObject); 
    }

    private GameObject CreateObject()
    {
        GameObject obj = Instantiate(prefab);
        obj.SetActive(false);

        return obj;
    }

    private void OnGetObject(GameObject obj) //������ ���
    {
        Rigidbody rb = obj.GetComponent<Rigidbody>();
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        obj.transform.position = Vector3.zero;
        obj.SetActive(true);
    }

    private void OnReleaseObject(GameObject obj) //���� �ִ� ���
    {
        obj.SetActive(false);
    }

    private void OnDestroyObject(GameObject obj) // �ı��ϴ� ���
    {
        Destroy(obj);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) //pool���� ������Ʈ�� �ϳ� ������ ���
        {
            GameObject obj = pool.Get();
            obj.SetActive(true);
        }
    }
}
