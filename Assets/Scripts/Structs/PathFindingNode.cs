using UnityEngine;

namespace HitmanGO
{
    /// <summary>
    /// Class <c> PathFindingNode </c> it is used in place of the <c> Node </c> class for path finding calculations
    /// </summary>
    public class PathFindingNode
    {
        #region Public Variables

        /// <summary>
        /// The position in grid coordinates
        /// </summary>
        public Vector2Int GridPosition { get; set; }

        /// <summary>
        /// The cost of moving to this node
        /// </summary>
        public int GCost = int.MaxValue;
        /// <summary>
        /// The minimum cost to get from this node to the target node
        /// </summary>
        public int HCost = 0;

        /// <summary>
        /// The final score of this node
        /// </summary>
        public int FCost { get { return GCost + HCost; } }

        /// <summary>
        /// The reference to the node prior to this
        /// </summary>
        public PathFindingNode PreviousNode = null;

        #endregion

        #region Initializers

        public PathFindingNode(Vector2Int gridPosition)
        {
            GridPosition = gridPosition;
        }

        #endregion
    }
}
