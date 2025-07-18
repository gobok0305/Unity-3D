using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Vector3 dir;
    private float speed = 5;

    public GameObject explosionFactory;

    void OnEnable()
    {
        int ranValue = UnityEngine.Random.Range(0, 10);

        if (ranValue < 7) //70%
        {
            GameObject target = GameObject.Find("Player");
            dir = target.transform.position - transform.position;
            //�÷��̾ �ٶ󺸴� ���� �� 
            dir.Normalize(); //�ڵ����� dir�� ����ϴ� ���
        }
        else //30%
        {
            dir = Vector3.down;
        }
    }

    private void Update()
    {
        transform.position += dir * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision other) // other: �浹 ���
    {
        object value = ScoreManager.Instance.Score++;

        //��ƼŬ ����
        GameObject explosion = Instantiate(explosionFactory);
        explosion.transform.position = transform.position;


        if (other.gameObject.name.Contains("Bullet"))
        {
            //PlayerFire.Instance.bulletObjectPool.Add(other.gameObject);
            PlayerFire.Instance.bulletObjectPool.Enqueue(other.gameObject);
            other.gameObject.SetActive(false);// �Ѿ� ������Ʈ ��Ȱ��ȭ , other: �Ѿ� ������Ʈ
        }
        else
        {
            Destroy(other.gameObject); // other: �÷��̾� ������Ʈ
        }

        //EnemyManager.Instance.enemyObjectPool.Add(gameObject);
        EnemyManager.Instance.enemyObjectPool.Enqueue(gameObject);
        gameObject.SetActive(false); //pool�̸� �ı��� �ƴ϶� ���� �����

        // �ı� ����
        //Destroy(other.gameObject); 
    }
}
