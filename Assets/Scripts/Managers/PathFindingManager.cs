using System.Collections.Generic;
using UnityEngine;

namespace HitmanGO
{
    /// <summary>
    /// Class <c> PathFindingManager </c> takes care of the management of all <c> PathFindingComponent </c> in the scene
    /// </summary>
    public class PathFindingManager : Singleton<PathFindingManager>
    {
        #region Variables

        #region Public Variables

        /// <summary>
        /// The list that contains all the <c> PathFindingComponents </c> in the scene
        /// </summary>
        public readonly List<PathFindingComponent> PFCList = new List<PathFindingComponent>();

        #endregion

        #region Private Variables

        [SerializeField]
        [Min(0.1f)]
        private float arrangeComponentsMultiplier = 1f; 

        private Node _lastNode;

        private const byte _moveStraightCost = 10;

        #endregion

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Calculate the shortest path from one node to another node
        /// </summary>
        /// <param name="startingNode"> The starting node </param>
        /// <param name="targetNode"> The target node </param>
        /// <returns> If a path is found it returns an array of <c> PathFindingNode </c>, otherwise it returns null </returns>
        public Node[] CalculatePath(Node startingNode, Node targetNode)
        {
            //The starting node
            PathFindingNode startingPathFindingNode = new PathFindingNode(startingNode.GridPosition);
            //The target node
            PathFindingNode targetPathFindingNode = new PathFindingNode(targetNode.GridPosition);

            //List of virtual nodes
            List<PathFindingNode> pathFindingNodes = new List<PathFindingNode>();

            //List of nodes to check
            List<PathFindingNode> openList = new List<PathFindingNode>() { startingPathFindingNode };
            //List of nodes already verified
            List<PathFindingNode> closedList = new List<PathFindingNode>();

            PathFindingNode currentPathFindingNode;

            //Initialize the virtual nodes where the real nodes are
            foreach (Node node in GridManager.GetInstance.Nodes)
            {
                currentPathFindingNode = new PathFindingNode(node.GridPosition)
                {
                    GCost = int.MaxValue,
                    HCost = 0,
                    PreviousNode = null
                };
                pathFindingNodes.Add(currentPathFindingNode);
            }

            //Calculate the shortest distance from start to finish
            startingPathFindingNode.GCost = 0;
            startingPathFindingNode.HCost = CalculateDistanceCost(startingPathFindingNode, targetPathFindingNode);

            //As long as there are nodes to check
            while (openList.Count > 0)
            {
                //Save the node with the lowest combined cost
                currentPathFindingNode = GetLowestFCostNode(openList.ToArray());

                PathFindingNode tmpNode = currentPathFindingNode;
                while(tmpNode.PreviousNode != null)
                {
                    tmpNode = tmpNode.PreviousNode;
                }

                //If the node found is the destination node
                if (currentPathFindingNode.GridPosition == targetNode.GridPosition)
                {
                    targetPathFindingNode = currentPathFindingNode;
                    //Retrace the route to the starting node
                    return ConvertPath(RetracePath(targetPathFindingNode));
                }

                //Otherwise remove the verified node from the list of nodes to be verified
                openList.Remove(currentPathFindingNode);
                //And add it to the list of checked nodes
                closedList.Add(currentPathFindingNode);

                Node currentNode = GridManager.GetInstance.GetNode(currentPathFindingNode.GridPosition);
                PathFindingNode connectedPathFindingNode = null;
                int tentativeGCost;

                //For each node connected to the found node
                foreach (Connection connection in currentNode.Connections)
                {
                    //Check the virtual node corresponding to the "physical" node
                    foreach (PathFindingNode pathFindingNode in pathFindingNodes)
                    {
                        if(pathFindingNode.GridPosition == connection.To.GridPosition)
                        {
                            //When you find the right virtual node save it
                            connectedPathFindingNode = pathFindingNode;
                            break;
                        }
                    }

                    //If the virtual node corresponding to the current node has not been found, give an error
                    if (connectedPathFindingNode == null)
                        Debug.LogError($"Non è stato trovato il nodo virtuale corrispondente al nodo {currentNode.name}");

                    //If the current virtual node has already been verified go to the next node
                    if (closedList.Contains(connectedPathFindingNode)) continue;

                    //Calculate the cost starting from the found node
                    tentativeGCost = currentPathFindingNode.GCost + CalculateDistanceCost(currentPathFindingNode, connectedPathFindingNode);

                    //If starting from the found node it is cheaper to get to the end
                    //than starting from the node verified in the previous iteration
                    if (tentativeGCost < connectedPathFindingNode.GCost)
                    {
                        //Sets the values ​​of the found node
                        connectedPathFindingNode.PreviousNode = currentPathFindingNode;
                        connectedPathFindingNode.GCost = tentativeGCost;
                        connectedPathFindingNode.HCost = CalculateDistanceCost(connectedPathFindingNode, targetPathFindingNode);

                        //If the node is not present in the list of nodes to check add it
                        if (!openList.Contains(connectedPathFindingNode))
                            openList.Add(connectedPathFindingNode);
                    }
                }
            }

            //If a path was not found, it returns "null"
            return null;
        }

        /// <summary>
        /// Get all the <c> PathFindingComponents </c> that target the given <c> Node </c>
        /// </summary>
        /// <param name="targetNode"> A given node </param>
        /// <returns> A <c> PathFindingComponent </c> array </returns>
        public List<PathFindingComponent> GetNodePopulation(Node targetNode)
        {
            List<PathFindingComponent> population = new List<PathFindingComponent>();

            foreach (PathFindingComponent pfc in PFCList)
            {
                if (pfc.GetCurrentNode() == targetNode)
                    population.Add(pfc);
            }

            return population;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Convert an array of <c> PathFindingNode </c> to an array of <c> Node </c>
        /// </summary>
        /// <param name="path"> The <c> PathFindingNode </c> array </param>
        /// <returns> The <c> Node </c> array </returns>
        private Node[] ConvertPath(PathFindingNode[] path)
        {
            Node[] convertedPath = new Node[path.Length];

            for(int i = 0; i < convertedPath.Length; i++)
            {
                convertedPath[i] = GridManager.GetInstance.GetNode(path[i].GridPosition);
            }

            return convertedPath;
        }

        /// <summary>
        /// Recalculate the route starting from the target node to arrive at the starting node
        /// </summary>
        /// <param name="endNode"> The target node </param>
        /// <returns> Return the list of nodes of the path from the starting node to the target node </returns>
        private PathFindingNode[] RetracePath(PathFindingNode endNode)
        {
            List<PathFindingNode> path = new List<PathFindingNode> { endNode };

            PathFindingNode currentNode = endNode;

            while(currentNode.PreviousNode != null)
            {
                path.Add(currentNode.PreviousNode);
                currentNode = currentNode.PreviousNode;
            }
            path.Reverse();

            return path.ToArray();
        }

        /// <summary>
        /// Get the node that is most convenient to go through to get to the target node
        /// </summary>
        /// <param name="nodes"> The list of nodes to check </param>
        /// <returns> The node with the lowest overall cost </returns>
        private PathFindingNode GetLowestFCostNode(PathFindingNode[] nodes)
        {
            PathFindingNode lowestFCostNode = nodes[0];

            foreach(PathFindingNode node in nodes)
            {
                if (node.FCost < lowestFCostNode.FCost)
                    lowestFCostNode = node;
            }

            return lowestFCostNode;
        }

        /// <summary>
        /// Calculate the cost of getting from node 'a' to node 'b'
        /// </summary>
        /// <param name="a"> The current node </param>
        /// <param name="b"> The target node </param>
        /// <returns> Returns the minimum number of moves to get to the target node multiplied by the cost for each move </returns>
        private int CalculateDistanceCost(PathFindingNode a, PathFindingNode b)
        {
            //Calculate the number of nodes to do horizontally to get from "a" to "b"
            int xDistance = Mathf.Abs(b.GridPosition.x - a.GridPosition.x);
            //Calculate the number of nodes to do vertically to get from "a" to "b"
            int yDistance = Mathf.Abs(b.GridPosition.y - a.GridPosition.y);
            //Multiply the minimum number of moves to get to the target node by the cost of each move
            return (xDistance + yDistance) * _moveStraightCost;
        }

        /// <summary>
        /// Calculate how the <c> PathFinding Component </c> should arrange on a node
        /// </summary>
        /// <param name="node"> A given node </param>
        public void ArrangePFCComponents(Node node)
        {
            if (_lastNode != node)
                ArrangePFCComponents(_lastNode);

            if (node == null)
            {
                _lastNode = node;
                return;
            }

            List<PathFindingComponent> nodePopulation = GetNodePopulation(node);

            if (nodePopulation.Count <= 0)
            {
                _lastNode = node;
                return;
            }

            for (int j = 0; j < nodePopulation.Count; j++)
            {
                if (nodePopulation[j] == GameManager.GetInstance.Player.PFC)
                    nodePopulation.Remove(nodePopulation[j]);
            }

            if (nodePopulation.Count == 1)
            {
                RequestPositionAdjustment(nodePopulation[0], nodePopulation[0].GetCurrentNode().transform.position);

                _lastNode = node;
                return;
            }

            int i;
            float angle;
            Vector3 targetPosition = Vector3.zero;

            for (i = 0; i < nodePopulation.Count; i++)
            {
                angle = 360f / nodePopulation.Count * i;

                targetPosition.x = Mathf.Cos(angle * Mathf.Deg2Rad) * arrangeComponentsMultiplier;
                targetPosition.z = Mathf.Sin(angle * Mathf.Deg2Rad) * arrangeComponentsMultiplier;

                targetPosition += node.transform.position;

                RequestPositionAdjustment(nodePopulation[i], targetPosition);
            }

            _lastNode = node;
        }

        /// <summary>
        /// Send a request to a <c> PathFinding Component </c> to settle into a defined position
        /// </summary>
        /// <param name="pfc"> A given PathFindingComponent </param>
        /// <param name="adjustedPosition"> The location where the <c> athFindingComponenet </c> should be </param>
        private void RequestPositionAdjustment(PathFindingComponent pfc, Vector3 adjustedPosition)
        {
            if (pfc.AdjustPosition != null)
                pfc.AdjustPosition.Invoke(adjustedPosition);
        }

        #endregion

        #endregion
    }
}