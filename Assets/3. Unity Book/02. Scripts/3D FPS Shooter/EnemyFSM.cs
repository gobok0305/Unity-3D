using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EnemyFSM : MonoBehaviour
{
    private enum EnemyState { Idle, Move, Attack, Return, Damaged, Die }
    private EnemyState m_State;
    
    private CharacterController cc;
    private Transform player; // Ÿ��

    private Animator anim;

    public float findDistance = 8f; //Ž���Ÿ�
    public float attackDistance = 3f; //���� ���ݰ��� �Ÿ�
    public float moveSpeed = 5f; // ���� �̵� �ӵ�
    
    private float currentTime = 0f; // Ÿ�̸�
    private float attackDelay = 2f; // ���� ������

    public int attackPower = 3;
    public int hp = 15;
    private int maxHp = 15;
    public Slider hpSlider;

    private Vector3 originPos;
    public float moveDistance = 20f;


    private void Start()
    {
        m_State = EnemyState.Idle;
        player = GameObject.Find("Player").transform;
        cc = GetComponent<CharacterController>();
        originPos = transform.position;
        anim = transform.GetComponentInChildren<Animator>();

        Cursor.visible = false; //Ŀ�� �Ⱥ��̴� ���
        Cursor.lockState = CursorLockMode.Locked; //Ŀ�� esc������ ���Ǯ��
    }

    private void Update()
    {
        switch (m_State)
        {
            case EnemyState.Idle:
                Idle();
                break;
            case EnemyState.Move:
                Move();
                break;
            case EnemyState.Attack:
                Attack();
                break;
            case EnemyState.Return:
                Return();
                break;
            case EnemyState.Damaged:
                //Damaged(); //�������� ���� �ݺ��ϱ� ������ �ʱ�ȭ ���� �ʿ���
                break;
            case EnemyState.Die:
                //Die();
                break;
        }

        hpSlider.value = (float)hp / (float)maxHp;
    }

    private void Idle()
    {
        if (Vector3.Distance(transform.position, player.position) < findDistance)
        {
            m_State = EnemyState.Move; //������ ������� �ʵ��� �ؾ� ��(�ڵ� ����)
            anim.SetTrigger("IdleToMove");
            Debug.Log("������ȯ: Idle -> Move");
        }
    }

    private void Move()
    {
        //�̷� ���ǹ��� ��� 3�� �ϳ��� �����
        if (Vector3.Distance(transform.position, originPos) > moveDistance)
        {
            m_State = EnemyState.Return;
            Debug.Log("���� ��ȯ Move -> Return");
        }
        //Ÿ���� ���� �Ÿ����� �� ��� -> �̵�
        else if (Vector3.Distance(transform.position, player.position) > attackDistance)
        {
            Vector3 dir = (player.position - transform.position).normalized;
            cc.Move(dir * moveSpeed * Time.deltaTime);

            transform.forward = dir; //�̵������� �������� �ۿ�
        }
        else //Ÿ���� ���� �Ÿ� ���� �ִ� ��� -> ���� ��ȯ
        {
            currentTime = attackDelay; // ������ ������ �ٷ� ������ȯ
            m_State = EnemyState.Attack; 
            Debug.Log("������ȯ: Move -> Attack");
        }
    }

    private void Attack()
    {
        //���� �Ÿ� ���� �ִ� ��� -> ���� ����
        if (Vector3.Distance(transform.position, player.position) < attackDistance)
        {
            currentTime += Time.deltaTime;
            if (currentTime > attackDelay)
            {
                currentTime = 0f; // �ʱ�ȭ
                player.GetComponent<PlayerMoveing>().DamageAction(attackPower);
                Debug.Log("����");
            }
        }
        else //���� �����ۿ� �ִ� ��� -> move ��ȯ
        {
            currentTime = 0f;
            m_State = EnemyState.Move;
            Debug.Log("���� ��ȯ: Attack -> Move");
        }
    }
    public void HitEnemy(int hitPower)
    {
        // ���� ���°� ����� ���� ��, ���� ��, �ǵ��ư���
        if (m_State == EnemyState.Damaged || m_State == EnemyState.Die || m_State == EnemyState.Return)
        {
            return; //�Լ� ����
        }

        hp -= hitPower;

        if (hp > 0) //������ �޾Ҵµ� ��Ҵٸ�
        {
            m_State = EnemyState.Damaged;
            Debug.Log("���� ��ȯ: any state -> Damaged");
            Damaged();
        }
        else // ������ �޾Ƽ� �׾��ٸ�
        {
            m_State = EnemyState.Die;
            Debug.Log("���� ��ȯ: any state -> Die");
            Die();
        }
    }

    private void Return()
    {
        //���� ��ġ�� �ƴ� ���,���� ��ġ�� ���� 
        //0.1 = �뷫 10cm (�˳��ϰ� �� ���)
        if (Vector3.Distance(transform.position, originPos) > 0.1f)
        {
            Vector3 dir = (originPos - transform.position).normalized;
            cc.Move(dir * moveSpeed * Time.deltaTime);
            transform.forward = dir;
        }
        else //���� ��ġ�� ���ƿ� ���
        {
            transform.position = originPos;
            hp = 15;
            anim.SetTrigger("MoveToIdle");
            m_State = EnemyState.Idle;
            Debug.Log("������ȯ: Retrun -> Idle");
        }
    }

    private void Damaged()
    {
        StartCoroutine(DamageProcess());
    }

    IEnumerator DamageProcess()
    {
        //�ǰ� �ִϸ��̼� �ð���ŭ ��� 
        yield return new WaitForSeconds(0.5f);

        m_State = EnemyState.Move;
        Debug.Log("���� ��ȯ: Damaged -> Move");
    }

    private void Die()
    {
        StopAllCoroutines();

        StartCoroutine(DieProcess());
    }

    IEnumerator DieProcess()
    {
        cc.enabled = false;

        yield return new WaitForSeconds(2f);
        Debug.Log("�Ҹ�");
        Destroy(gameObject);
    }
}
