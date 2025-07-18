using UnityEngine;

public class FPSPlayerFire : MonoBehaviour
{
    public GameObject firePosition;

    public GameObject bombFactory;

    public float throwPower = 15;
    public GameObject bulletEffect;
    public ParticleSystem ps;
    

    private void Start()
    {
        ps = bulletEffect.GetComponent<ParticleSystem>();
    }


    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // ���콺 ���� Ŭ��
        {
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            //�����                             //����
            RaycastHit hitInfo = new RaycastHit();

            if (Physics.Raycast(ray, out hitInfo))
            {
                bulletEffect.transform.position = hitInfo.point;
                bulletEffect.transform.forward = hitInfo.normal; //��ƼŬ�� tranform ������ ��������!

                ps.Play();
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
