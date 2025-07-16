using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    private GameObject bulletFactory;
    public GameObject firePostition;

    private void Start()
    {
        bulletFactory = Resources.Load<GameObject>("Bullet"); 
        // 리소스 폴더에서 총알 프리팹 로드
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bullet = Instantiate(bulletFactory);
            bullet.transform.position = firePostition.transform.position; // 위치 초기화
            //bullet.transform.rotation = firePostition.transform.rotation; // 회전 초기화

            //bullet.transform.SetPositionAndRotation(위치, 회전)// 위치와 회전을 한번에 적용하는 기능
            //bullet.transform.SetParent(부모); //부모 오브젝트 적용

        }
    }
}
