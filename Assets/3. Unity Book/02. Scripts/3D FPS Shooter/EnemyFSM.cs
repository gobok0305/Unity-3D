using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EnemyFSM : MonoBehaviour
{
    private enum EnemyState { Idle, Move, Attack, Return, Damaged, Die }
    private EnemyState m_State;
    
    private CharacterController cc;
    private Transform player; // 타겟

    private Animator anim;

    public float findDistance = 8f; //탐지거리
    public float attackDistance = 3f; //적의 공격가능 거리
    public float moveSpeed = 5f; // 적의 이동 속도
    
    private float currentTime = 0f; // 타이머
    private float attackDelay = 2f; // 공격 딜레이

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

        Cursor.visible = false; //커서 안보이는 기능
        Cursor.lockState = CursorLockMode.Locked; //커서 esc눌러야 잠금풀림
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
                //Damaged(); //옴팡지게 무한 반복하기 때문에 초기화 값이 필요함
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
            m_State = EnemyState.Move; //여러번 실행되지 않도록 해야 함(코드 꼬임)
            anim.SetTrigger("IdleToMove");
            Debug.Log("상태전환: Idle -> Move");
        }
    }

    private void Move()
    {
        //이런 조건문일 경우 3중 하나만 실행됨
        if (Vector3.Distance(transform.position, originPos) > moveDistance)
        {
            m_State = EnemyState.Return;
            Debug.Log("상태 전환 Move -> Return");
        }
        //타겟이 공격 거리보다 먼 경우 -> 이동
        else if (Vector3.Distance(transform.position, player.position) > attackDistance)
        {
            Vector3 dir = (player.position - transform.position).normalized;
            cc.Move(dir * moveSpeed * Time.deltaTime);

            transform.forward = dir; //이동방향을 정면으로 작용
        }
        else //타겟이 공격 거리 내에 있는 경우 -> 공격 전환
        {
            currentTime = attackDelay; // 범위내 들어오면 바로 공격전환
            m_State = EnemyState.Attack; 
            Debug.Log("상태전환: Move -> Attack");
        }
    }

    private void Attack()
    {
        //공격 거리 내에 있는 경우 -> 공격 실행
        if (Vector3.Distance(transform.position, player.position) < attackDistance)
        {
            currentTime += Time.deltaTime;
            if (currentTime > attackDelay)
            {
                currentTime = 0f; // 초기화
                player.GetComponent<PlayerMoveing>().DamageAction(attackPower);
                Debug.Log("공격");
            }
        }
        else //공격 범위밖에 있는 경우 -> move 전환
        {
            currentTime = 0f;
            m_State = EnemyState.Move;
            Debug.Log("상태 전환: Attack -> Move");
        }
    }
    public void HitEnemy(int hitPower)
    {
        // 적의 상태가 대미지 받을 때, 죽을 때, 되돌아갈때
        if (m_State == EnemyState.Damaged || m_State == EnemyState.Die || m_State == EnemyState.Return)
        {
            return; //함수 정지
        }

        hp -= hitPower;

        if (hp > 0) //공격을 받았는데 살았다면
        {
            m_State = EnemyState.Damaged;
            Debug.Log("상태 전환: any state -> Damaged");
            Damaged();
        }
        else // 공격을 받아서 죽었다면
        {
            m_State = EnemyState.Die;
            Debug.Log("상태 전환: any state -> Die");
            Die();
        }
    }

    private void Return()
    {
        //원래 위치가 아닌 경우,원래 위치로 복귀 
        //0.1 = 대략 10cm (넉넉하게 잢 잡기)
        if (Vector3.Distance(transform.position, originPos) > 0.1f)
        {
            Vector3 dir = (originPos - transform.position).normalized;
            cc.Move(dir * moveSpeed * Time.deltaTime);
            transform.forward = dir;
        }
        else //원래 위치로 돌아온 경우
        {
            transform.position = originPos;
            hp = 15;
            anim.SetTrigger("MoveToIdle");
            m_State = EnemyState.Idle;
            Debug.Log("상태전환: Retrun -> Idle");
        }
    }

    private void Damaged()
    {
        StartCoroutine(DamageProcess());
    }

    IEnumerator DamageProcess()
    {
        //피격 애니메이션 시간만큼 대기 
        yield return new WaitForSeconds(0.5f);

        m_State = EnemyState.Move;
        Debug.Log("상태 전환: Damaged -> Move");
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
        Debug.Log("소멸");
        Destroy(gameObject);
    }
}
