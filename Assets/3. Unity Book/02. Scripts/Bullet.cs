using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject); // 

            Destroy(other.gameObject, 10f); //
        }
    }

    private void OnCollisionStay(Collision other)
    {

    }

    private void OnCollisionExit(Collision other)
    {

    }
}
