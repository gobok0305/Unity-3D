using UnityEngine;

public class Billboard : MonoBehaviour
{
    public Transform target;

    private void Update()
    {
                            // main camera tag�� ���� ī�޶� ������Ʈ
        transform.forward = Camera.main.transform.forward;
    }
}
