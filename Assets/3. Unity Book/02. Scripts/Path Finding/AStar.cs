using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AStar
{
    public static PriorityQueue openList; // 방문할수 있는 후보
    public static PriorityQueue closedList; // 이미 방문한 노드

    //휴리스틱(최단거리를 추측) 기반 최단거리 뽑아내기
    private static float HeuristicEstimateCost(Node curNode, Node endNode)
    {
        Vector3 cost = curNode.pos - endNode.pos;
        return cost.magnitude;
    }

    public static List<Node> FindPath(Node startNode, Node endNode)
    {
        openList = new PriorityQueue();
        openList.Push(startNode);
        startNode.nodeTotalCost = 0f;
        startNode.estimateCost = HeuristicEstimateCost(startNode,endNode);
        closedList = new PriorityQueue();
        Node node = null;

        while (openList.Length != 0)
        {
            node = openList.First();

            if (node.pos == endNode.pos) // 목적지에 도착
            {
                return CalculatePath(node);
            }

            List<Node> neighbors = new List<Node>();
            GridManager.Instance.GetNeighbors(node, neighbors);

            for (int i = 0; i < neighbors.Count; i++)
            {
                Node neighborNode = neighbors[i];

                if (!closedList.Contains(neighborNode))
                {
                    float cost = HeuristicEstimateCost(node, neighborNode);
                    float totalCost = node.nodeTotalCost + cost;

                    float neighborNodeEstCost = HeuristicEstimateCost(neighborNode, endNode);

                    neighborNode.nodeTotalCost = totalCost;
                    neighborNode.parent = node;
                    neighborNode.estimateCost = totalCost + neighborNodeEstCost;

                    if (!openList.Contains(neighborNode))
                    {
                        openList.Push(neighborNode);
                    }
                }
            }
            closedList.Push(node);
            openList.Remove(node);

        }

        if (node.pos != endNode.pos)
        {
            Debug.LogError("Destination Path Not Found");

            return null;
        }

        return CalculatePath(node);

    }

    private static List<Node> CalculatePath(Node node)
    {
        List<Node> list = new List<Node>();

        while (node != null)
        {
            list.Add(node);
            node = node.parent;
        }

        list.Reverse();

        return list;
    }
}
