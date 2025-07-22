using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMoveing : MonoBehaviour
{
    private CharacterController cc;
    private Animator anim;

    public float moveSpeed = 7f;

    private float gravity = -20f;
    private float yVelocity = 0f;

    public float jumpPower = 10f;
    public bool isJumping = false;

    public int hp = 20;

    private int maxHp = 20;
    public Slider hpSlider;

    public GameObject hitEffect;

    private void Start()
    {
        cc = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if (FPSGameManager.Instance.gState != FPSGameManager.GameState.Run)
            return;

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(h, 0, v); // 크기와 방향이 있는 벡터
        dir = dir.normalized; // 방향만 있는 벡터

        anim.SetFloat("MoveMotion", dir.magnitude);

        // 카메라의 transform 기준으로 변환
        dir = Camera.main.transform.TransformDirection(dir);

        transform.position += dir * moveSpeed * Time.deltaTime;

        yVelocity += gravity * Time.deltaTime; //player의 중력 값
        dir.y = yVelocity;

        cc.Move(dir * moveSpeed * Time.deltaTime); //캐릭터 컨트롤러에 내장된 이동기능

        //높은곳에서 내려올때 뚝 끊기듯 내려오는 거 방지
        // 아래쪽에 무엇인가 닿은 상태
        if (cc.collisionFlags == CollisionFlags.Below) 
        {
            if (isJumping)
            {
                isJumping = false;
            }
            yVelocity = 0f;
        }

        //점프기능 그리고 2단점프 방지
        if (Input.GetButtonDown("Jump") && !isJumping) 
        {
            isJumping = true;
            yVelocity = jumpPower; //점프하는 순간에 yvelocity를 초기화
        }

    }

    public void DamageAction(int damage)
    {
        hp -= damage;
        hpSlider.value = (float)hp / (float)maxHp;

        if (hp > 0)
        {
            StartCoroutine(PlayHitEffect());
        }
    }

    IEnumerator PlayHitEffect()
    {
        hitEffect.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        hitEffect.SetActive(false);
    }
}
