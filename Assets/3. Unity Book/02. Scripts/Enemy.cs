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
            //�÷��̾ �ٶ󺸴� ���� �� 
            dir.Normalize(); //�ڵ����� dir�� ����ϴ� ���
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

    private void OnCollisionEnter(Collision other) // other: �浹 ���
    {
        GameObject smObject = GameObject.Find("ScoreManager");
        ScoreManager sm = smObject.GetComponent<ScoreManager>();
        
        sm.currentScore++;
       

        //��ƼŬ ����
        GameObject explosion = Instantiate(explosionFactory);
        explosion.transform.position = transform.position;

        // �ı� ����
        Destroy(other.gameObject); 
        Destroy(gameObject); 
    }
}
