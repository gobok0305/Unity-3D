using UnityEngine;

public class BombAction : MonoBehaviour
{
    public GameObject bombEffect;

    public int attackPower = 10;
    public float explosionRadiaus = 5f;

    //����ź�� �����ΰ� �浹�� ���
    private void OnCollisionEnter(Collision collision)
    {
        Collider[] cols = Physics.OverlapSphere(transform.position, explosionRadiaus, 1 << 9);

        for (int i = 0; i < cols.Length; i++)
            cols[i].GetComponent<EnemyFSM>().HitEnemy(attackPower);

        GameObject eff = Instantiate(bombEffect); //��ƼŬ ����
        eff.transform.position = transform.position; // ��ƼŬ ��ġ �ʱ�ȭ

        Destroy(gameObject);
    }
}
