using System.Collections.Generic;
using UnityEngine;

namespace HitmanGO
{
    /// <summary>
    /// Class <c> GridManager </c> manages the set of nodes
    /// </summary>
    public class GridManager : Singleton<GridManager>
    {
        #region Variables

        #region Public Variables

        /// <summary>
        /// The value by which the global coordinates of each node will be divided to derive the grid coordinates
        /// </summary>
        [Range(1, 10)]
        [Tooltip("The value by which the global coordinates of each node will be divided to derive the grid coordinates \n" +
            "Es. If the nodes have been placed at a distance of 4 units from each other, this value must be set to 4")]
        public byte WorldTransformDivider = 1;

        #endregion

        #region Private Variables

        /// <summary>
        /// The list of nodes
        /// </summary>
        private readonly List<Node> _nodes = new List<Node>();

        #endregion

        #endregion

        #region Public Methods

        /// <summary>
        /// Converts global coordinates to grid coordinates
        /// </summary>
        /// <param name="worldPosition"> The position in world coordinates </param>
        /// <returns> The position in grid coordinates </returns>
        public Vector2Int GetGridPosition(Vector3 worldPosition, bool snapToNearestNode = false)
        {
            if (snapToNearestNode)
            {
                Node nearestNode = GetNearestNode(worldPosition);
                return nearestNode.GridPosition;
            }

            Vector2Int gridPosition = Vector2Int.zero;

            if ((int)worldPosition.x % WorldTransformDivider == 0)
                gridPosition.x = (int)worldPosition.x / WorldTransformDivider;
            else
                throw new GridCoordinatesException($"An error occurred while converting the x of the global coordinates {worldPosition} to grid coordinates");

            if ((int)worldPosition.z % WorldTransformDivider == 0)
                gridPosition.y = (int)worldPosition.z / WorldTransformDivider;
            else
                throw new GridCoordinatesException($"An error occurred while converting the y of the global coordinates {worldPosition} to grid coordinates");

            return gridPosition;
        }

        public Node GetNearestNode(Vector3 worldPosition)
        {
            Node _nearestNode = _nodes[0];

            foreach (Node node in _nodes)
            {
                if (Vector3.Distance(worldPosition, node.transform.position) < Vector3.Distance(worldPosition, _nearestNode.transform.position))
                    _nearestNode = node;
            }

            return _nearestNode;
        }

        /// <summary>
        /// Check if a <c> Node </c> is present in the list of nodes
        /// </summary>
        /// <param name="node"> A given <c> Node </c> </param>
        /// <returns> Returns true if the node is in the list, otherwise it returns false </returns>
        public bool Contains(Node node) => _nodes.Contains(node);

        /// <summary>
        /// Add a <c> Node </c> to the list of nodes
        /// </summary>
        /// <param name="node"> A given <c> Node </c> </param>
        public void AddNode(Node node) => _nodes.Add(node);

        #region GetNode

        /// <summary>
        /// Get a <c> Node </c> from the list by passing its coordinates on the grid as a <c> Vector2Int </c>
        /// </summary>
        /// <param name="gridPosition"> The grid coordinates of the <c> Node </c> </param>
        /// <returns> Returns the <c> Node </c> if it is present in the list, otherwise it returns <c> null </c> </returns>
        public Node GetNode(Vector2Int gridPosition)
        {
            foreach(Node node in _nodes)
            {
                if (node.GridPosition == gridPosition)
                    return node;
            }

            throw new NoNodeException($"You are trying to get a nonexistent node in position {gridPosition}");
        }

        /// <summary>
        /// Get a <c> Node </c> from the list by passing its x and y coordinates on the grid
        /// </summary>
        /// <param name="gridPositionX"> The x coordinate of the <c> Node </c> </param>
        /// /// <param name="gridPositionY"> The y coordinate of the <c> Node </c> </param>
        /// <returns> Returns the <c> Node </c> if it is present in the list, otherwise it returns <c> null </c> </returns>
        public Node GetNode(int gridPositionX, int gridPositionY)
        {
            return GetNode(new Vector2Int(gridPositionX, gridPositionY));
        }

        #endregion

        #endregion
    }
}
