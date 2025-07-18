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

        Vector3 dir = new Vector3(h, 0, v); // ũ��� ������ �ִ� ����
        dir = dir.normalized; // ���⸸ �ִ� ����

        // ī�޶��� transform �������� ��ȯ
        dir = Camera.main.transform.TransformDirection(dir);

        transform.position += dir * moveSpeed * Time.deltaTime;

        yVelocity += gravity * Time.deltaTime; //player�� �߷� ��
        dir.y = yVelocity;

        cc.Move(dir * moveSpeed * Time.deltaTime); //ĳ���� ��Ʈ�ѷ��� ����� �̵����

        //���������� �����ö� �� ����� �������� �� ����
        // �Ʒ��ʿ� �����ΰ� ���� ����
        if (cc.collisionFlags == CollisionFlags.Below) 
        {
            if (isJumping)
            {
                isJumping = false;
            }
            yVelocity = 0f;
        }

        //������� �׸��� 2������ ����
        if (Input.GetButtonDown("Jump") && !isJumping) 
        {
            isJumping = true;
            yVelocity = jumpPower; //�����ϴ� ������ yvelocity�� �ʱ�ȭ
        }
    }
}
