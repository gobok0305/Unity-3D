using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Vector3 dir;
    private float speed = 5;

    public GameObject explosionFactory;

    void Start()
    {
        int ranValue = UnityEngine.Random.Range(0, 10);

        if (ranValue < 3) //30%
        {
            GameObject target = GameObject.Find("Player");
            dir = target.transform.position - transform.position;
            //플레이어를 바라보는 방향 값 
            dir.Normalize(); //자동으로 dir을 계산하는 기능
        }
        else //70%
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
        GameObject smObject = GameObject.Find("ScoreManager");
        ScoreManager sm = smObject.GetComponent<ScoreManager>();
        
        sm.currentScore++;
       

        //파티클 생성
        GameObject explosion = Instantiate(explosionFactory);
        explosion.transform.position = transform.position;

        // 파괴 가능
        Destroy(other.gameObject); 
        Destroy(gameObject); 
    }
}
