using UnityEngine;

public class DestroyEffect : MonoBehaviour
{
    public float destroyTime = 2f; //파티클 리소스 시간에 따라서 설정
    
    public float currentTime = 0f;

    private void Update()
    {
        if (currentTime > destroyTime)
        {
            Destroy(gameObject);
        }

        currentTime += Time.deltaTime;
    }
}
