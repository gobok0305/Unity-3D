using System.Collections.Generic;
using UnityEngine;

public class AStarMover : MonoBehaviour
{
    private Transform startPos, endPos;
    public Node startNode, endNode;

    public List<Node> pathList = new List<Node>();

    public GameObject startCube, endCube;

    private void Start()
    {
        GetPath();
    }

    private void GetPath()
    {
        startPos = startCube.transform;
        endPos = endCube.transform;

        // astar에게  start와 end지점을  알려주고 길을 알려달라고 설정
        int startIndex = GridManager.Instance.GetGridIndex(startPos.position);
        int startRow = GridManager.Instance.GetRow(startIndex);
        int startCol = GridManager.Instance.GetColumn(startIndex);
        startNode = GridManager.Instance.nodes[startRow, startCol];

        int endIndex = GridManager.Instance.GetGridIndex(endPos.position);
        int endRow = GridManager.Instance.GetRow(endIndex);
        int endCol = GridManager.Instance.GetColumn(endIndex);
        endNode = GridManager.Instance.nodes[endRow, endCol];

        // start에서 end까지의 방문한 node list
        pathList = AStar.FindPath(startNode, endNode);

    }

    private void OnDrawGizmos()
    {
        if (pathList == null)
            return;

        if (pathList.Count > 0)
        {
            int index = 1;
            foreach (Node node in pathList)
            {
                Node nextNode = pathList[index];
                Debug.DrawLine(node.pos, nextNode.pos, Color.green);
                index++;
            }

        }
    }
}
