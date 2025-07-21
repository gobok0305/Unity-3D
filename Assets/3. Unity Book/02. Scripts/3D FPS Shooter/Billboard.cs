using UnityEngine;

public class Billboard : MonoBehaviour
{
    public Transform target;

    private void Update()
    {
                            // main camera tag를 가진 카메라 오브젝트
        transform.forward = Camera.main.transform.forward;
    }
}
