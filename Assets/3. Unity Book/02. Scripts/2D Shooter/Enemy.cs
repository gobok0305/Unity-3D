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
            //플레이어를 바라보는 방향 값 
            dir.Normalize(); //자동으로 dir을 계산하는 기능
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

    private void OnCollisionEnter(Collision other) // other: 충돌 대상
    {
        object value = ScoreManager.Instance.Score++;

        //파티클 생성
        GameObject explosion = Instantiate(explosionFactory);
        explosion.transform.position = transform.position;


        if (other.gameObject.name.Contains("Bullet"))
        {
            //PlayerFire.Instance.bulletObjectPool.Add(other.gameObject);
            PlayerFire.Instance.bulletObjectPool.Enqueue(other.gameObject);
            other.gameObject.SetActive(false);// 총알 오브젝트 비활성화 , other: 총알 오브젝트
        }
        else
        {
            Destroy(other.gameObject); // other: 플레이어 오브젝트
        }

        //EnemyManager.Instance.enemyObjectPool.Add(gameObject);
        EnemyManager.Instance.enemyObjectPool.Enqueue(gameObject);
        gameObject.SetActive(false); //pool이면 파괴가 아니라 재사용 방식임

        // 파괴 가능
        //Destroy(other.gameObject); 
    }
}
