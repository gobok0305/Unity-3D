using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    private GameObject bulletFactory;
    public GameObject firePostition;

    private void Start()
    {
        bulletFactory = Resources.Load<GameObject>("Bullet"); 
        // ���ҽ� �������� �Ѿ� ������ �ε�
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bullet = Instantiate(bulletFactory);
            bullet.transform.position = firePostition.transform.position; // ��ġ �ʱ�ȭ
            //bullet.transform.rotation = firePostition.transform.rotation; // ȸ�� �ʱ�ȭ

            //bullet.transform.SetPositionAndRotation(��ġ, ȸ��)// ��ġ�� ȸ���� �ѹ��� �����ϴ� ���
            //bullet.transform.SetParent(�θ�); //�θ� ������Ʈ ����

        }
    }
}
