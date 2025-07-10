using UnityEngine;

public class Fibonacci : MonoBehaviour
{
    
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
           int result = FibonacciFuntion(i);
           Debug.Log(result);
        }
        
    }

    private int FibonacciFuntion(int n)
    {
        if (n <= 1)
        {
            return n;
        }
        
        return FibonacciFuntion(n - 1) + FibonacciFuntion(n - 2);
    }
}
