using UnityEngine;

namespace HitmanGO
{
    public class PathFindingNode
    {
        #region Public Variables

        public Vector2Int GridPosition { get; set; }

        public int GCost = int.MaxValue;
        public int HCost = 0;

        public int FCost { get { return GCost + HCost; } }

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
