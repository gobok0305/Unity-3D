using UnityEngine;

public class BombAction : MonoBehaviour
{
    public GameObject bombEffect;

    //����ź�� �����ΰ� �浹�� ���
    private void OnCollisionEnter(Collision collision)
    {
        GameObject eff = Instantiate(bombEffect); //��ƼŬ ����
        eff.transform.position = transform.position; // ��ƼŬ ��ġ �ʱ�ȭ

        Destroy(gameObject);
    }
}
