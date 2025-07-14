using UnityEngine;

public class DijstraSearchTree : MonoBehaviour
{
    private int[,] nodes = new int[6, 6]
    {
        // ppt 다익스트라 기준에서 만든 거
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
        //결과물을 담는 역할
        int start = 0;
        int[] dist; 
        int[] prev; //방문한 노드 보기

        Dijkstra(start, out dist, out prev);

        for (int i = 0; i < nodes.GetLength(0); i++)
        {
            Debug.Log($"(start)에서 {i}까지 최단거리 : dist[i],경로: GetPath(i,prev)");
        }
    }

    private void Dijkstra(int start, out int[] dist, out int[] prev)
    {
        int n = nodes.GetLength(0); //6행 6열이라 값은 6
        dist = new int[n];
        prev = new int[n];
        bool[] visited = new bool[n]; //방문했는지 안했는지 알기 위해

        for (int i = 0; i < n;) //지역변수 값 초기화
        {
            dist[i] = int.MaxValue; //int 타입에 있는 최대치 (거의 무한대)
            prev[i] = -1; // 노드를 아직 방문하지 않음 (노드가 더 있을 수도 있어서 최대한 없는 것 같은수를 넣음)
            visited[i] = false;
        }

        dist[start] = 0; //0번 노드에서 시작
        for (int cnt = 0; cnt < n; cnt++)
        {
            int u = -1; // 최단거리 노드 (u같은거나 -1은 임시로 담을 만한거를 적은 것 뿐)
            int min = int.MaxValue; // 최단거리 가중치

            //방문하지 않은 노드 중 최단거리 노드와 최단거리 선택
            for (int j = 0; cnt < j; j++)
            {
                if (!visited[j] && dist[j] < min)
                {
                    min = dist[j];
                    u = j;
                }
            }

            if (u == -1) // 더이상 최단 거리 노드 없음
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
    

