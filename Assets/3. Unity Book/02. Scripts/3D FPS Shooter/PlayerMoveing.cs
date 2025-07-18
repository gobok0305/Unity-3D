using UnityEngine;

public class PlayerMoveing : MonoBehaviour
{
    private CharacterController cc;

    public float moveSpeed = 7f;

    private float gravity = -20f;
    private float yVelocity = 0f;

    public float jumpPower = 10f;
    public bool isJumping = false;

    private void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(h, 0, v); // 크기와 방향이 있는 벡터
        dir = dir.normalized; // 방향만 있는 벡터

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
}
