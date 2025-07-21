using UnityEngine;

public class FPSPlayerFire : MonoBehaviour
{
    public GameObject firePosition;

    public GameObject bombFactory;

    public float throwPower = 15;
    public int weaponPower = 5;

    public GameObject bulletEffect;
    public ParticleSystem ps;
    

    private void Start()
    {
        ps = bulletEffect.GetComponent<ParticleSystem>();
    }


    private void Update()
    {
        if (FPSGameManager.Instance.gState != FPSGameManager.GameState.Run)
            return;

        if (Input.GetMouseButtonDown(0)) // ���콺 ���� Ŭ��
        {
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            //�����                             //����
            RaycastHit hitInfo = new RaycastHit();

            if (Physics.Raycast(ray, out hitInfo))
            {
                // raycast�� ���� ����� enemy�� ���� ���
                if (hitInfo.transform.gameObject.layer == LayerMask.NameToLayer("Enemy"))
                {
                    EnemyFSM eFSM = hitInfo.transform.GetComponent<EnemyFSM>();
                    eFSM.HitEnemy(weaponPower);
                }
                else // raycast�� ���� ����� enemy�� �ƴ� ���
                {
                    bulletEffect.transform.position = hitInfo.point;
                    bulletEffect.transform.forward = hitInfo.normal; //��ƼŬ�� tranform ������ ��������!

                    ps.Play();
                }
        
            }
        }

        if (Input.GetMouseButtonDown(1)) //���콺 ������ ��ư Ŭ��
        {
            GameObject bomb = Instantiate(bombFactory);
            bomb.transform.position = firePosition.transform.position;

            Rigidbody rb = bomb.GetComponent<Rigidbody>();
            rb.AddForce(Camera.main.transform.forward * throwPower, ForceMode.Impulse);
        }
    }
}
