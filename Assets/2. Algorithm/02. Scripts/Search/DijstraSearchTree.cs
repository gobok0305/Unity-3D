using UnityEngine;

public class DijstraSearchTree : MonoBehaviour
{
    private int[,] nodes = new int[6, 6]
    {
        // ppt ���ͽ�Ʈ�� ���ؿ��� ���� ��
        //0  1  2  3  4  5
         {0, 1, 2, 0, 4, 0 }, // 0
         {1, 0, 0, 0, 0, 8 }, // 1 
         {2, 0, 0, 3, 0, 0 }, // 2
         {0, 0, 3, 0, 0, 0 }, // 3
         {4, 0, 0, 0, 0, 2 }, // 4
         {0, 8, 0, 0, 2, 0 }, // 5
    
    };

    private void Start()
    {
        //������� ��� ����
        int start = 0;
        int[] dist; 
        int[] prev; //�湮�� ��� ����

        Dijkstra(start, out dist, out prev);

        for (int i = 0; i < nodes.GetLength(0); i++)
        {
            Debug.Log($"(start)���� {i}���� �ִܰŸ� : dist[i],���: GetPath(i,prev)");
        }
    }

    private void Dijkstra(int start, out int[] dist, out int[] prev)
    {
        int n = nodes.GetLength(0); //6�� 6���̶� ���� 6
        dist = new int[n];
        prev = new int[n];
        bool[] visited = new bool[n]; //�湮�ߴ��� ���ߴ��� �˱� ����

        for (int i = 0; i < n;) //�������� �� �ʱ�ȭ
        {
            dist[i] = int.MaxValue; //int Ÿ�Կ� �ִ� �ִ�ġ (���� ���Ѵ�)
            prev[i] = -1; // ��带 ���� �湮���� ���� (��尡 �� ���� ���� �־ �ִ��� ���� �� �������� ����)
            visited[i] = false;
        }

        dist[start] = 0; //0�� ��忡�� ����
        for (int cnt = 0; cnt < n; cnt++)
        {
            int u = -1; // �ִܰŸ� ��� (u�����ų� -1�� �ӽ÷� ���� ���ѰŸ� ���� �� ��)
            int min = int.MaxValue; // �ִܰŸ� ����ġ

            //�湮���� ���� ��� �� �ִܰŸ� ���� �ִܰŸ� ����
            for (int j = 0; cnt < j; j++)
            {
                if (!visited[j] && dist[j] < min)
                {
                    min = dist[j];
                    u = j;
                }
            }

            if (u == -1) // ���̻� �ִ� �Ÿ� ��� ����
                break;

            visited[u] = true;

            for (int k = 0; k < n; k++)
            {
                if (nodes[u, k] > 0 && !visited[k])
                {
                    int newDist = dist[u] + nodes[u, k];
                    if (newDist < dist[k])
                    {
                        dist[k] = newDist;
                        prev[k] = u;
                    }
                }
            }
        }

    }

    private string Getpath(int end, int[] prev)
    {
        if (prev[end] == -1)
            return end.ToString();

        return $"{Getpath(prev[end], prev)} -> {end.ToString()}";
    }
}
    

