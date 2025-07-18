using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : Singleton<PlayerFire>
{
    public GameObject bulletFactory;
    public GameObject firePosition;

    public int poolSize = 10;

    // public GameObject[] bulletObjectPool; // �迭
    // public List<GameObject> bulletObjectPool; // ����Ʈ
    public Queue<GameObject> bulletObjectPool; // ť

    void Start()
    {
        // bulletObjectPool = new GameObject[poolSize]; // �迭
        // bulletObjectPool = new List<GameObject>(); // ����Ʈ
        bulletObjectPool = new Queue<GameObject>(); // ť

        for (int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(bulletFactory);

            // bulletObjectPool[i] = bullet; // �迭
            // bulletObjectPool.Add(bullet); // ����Ʈ
            bulletObjectPool.Enqueue(bullet); // ť

            bullet.SetActive(false);
        }
    }

    void Update()
    {
#if UNITY_STANDALONE || UNITY_EDITOR || DEBUG_TEST
        if (Input.GetButtonDown("Fire1"))
        {
            // ť
            if (bulletObjectPool.Count > 0)
            {
                GameObject bullet = bulletObjectPool.Dequeue();
                bullet.SetActive(true);
                bullet.transform.position = firePosition.transform.position;
            }
        }


#elif UNITY_ANDROID || UNITY_IOS
        if (Input.GetTouch(0),phase == TouchPhase.Began)
        {    
             Debug.Log("�հ��� ��ġ")
             if (bulletObjectPool.Count > 0 )
             {
                GameObject bullet = bulletObjectPool.Dequeue();
                bullet.SetActive(true);
                bullet.transform.position = firePosition.transform.position;
             }

         }
#else
         DEbug.Log("�׿� ������ �÷���")
#endif
    }
    //if (bulletObjectPool.Count > 0)
    //{
    //    GameObject bullet = bulletObjectPool[0]; // ������ ������Ʈ ����
    //    bullet.SetActive(true); // ������Ʈ ���

    //    bulletObjectPool.Remove(bullet); // pool���� ������Ʈ ����

    //    bullet.transform.position = firePostition.transform.position; // �߻� ��ġ ����
    //}

    //for (int i = 0; i < poolSize; i++)
    //{
    //    GameObject bullet = bulletObjectPool[i];

    //    if (!bullet.activeSelf) // ������ �Ѿ� ������Ʈ�� ��Ȱ��ȭ �������� Ȯ��
    //    {
    //        bullet.SetActive(true); // �Ѿ��� ����ϱ� ���� Ȱ��ȭ

    //        break; // �ݺ��� ����
    //    }
    //}



    //bullet.transform.rotation = firePostition.transform.rotation; // ȸ�� �ʱ�ȭ

    //bullet.transform.SetPositionAndRotation(��ġ, ȸ��)// ��ġ�� ȸ���� �ѹ��� �����ϴ� ���
    //bullet.transform.SetParent(�θ�); //�θ� ������Ʈ ����

}