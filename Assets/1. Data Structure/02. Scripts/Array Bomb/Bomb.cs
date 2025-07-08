using System.Collections;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private Rigidbody bombRb;
    public float bombTime = 4f;
    public float bombRange = 10f;
    public LayerMask layerMask;

    private void Awake()
    {
        bombRb = GetComponent<Rigidbody>();
    }

    //원하는 타이밍에 폭파 효과
    private IEnumerator Start()
    {
        yield return new WaitForSeconds(bombTime);

        BombForce();
    }

    private void BombForce()
    {                                              // layermask: 특정 레이어에 해당되는 것만 적용
        Collider[] colliders = Physics.OverlapSphere(transform.position, bombRange, layerMask);

        foreach (var collider in colliders)
        {
            Rigidbody rb = collider.GetComponent<Rigidbody>();

            //AddExplosionforce(폭팔 파워, 폭팔 위치, 폭팔 범위, 폭팔 높이)
            rb.AddExplosionForce(500f, transform.position, bombRange, 1f);
        }

        Destroy(gameObject);
    }

}
