using System.Collections.Generic;
using UnityEngine;

namespace SB.HitmanGO
{
    public class PathFindingComponent : MonoBehaviour
    {
        #region Public Variables

        public float threshold = 3;

        #endregion

        #region Public Methods

        public Vector3 GetNearestNodePosition(Vector3 origin, Vector3 direction)
        {
            Vector3 nearestNodePosition = origin;

            List<Node> nodesInDirection = new List<Node>();

            foreach(Node node in PathFindingManager.GetInstance.GetNodes())
            {
                if(direction == Vector3.forward)
                    if (node.Position.z > origin.z && node.Position.x == origin.x) nodesInDirection.Add(node);
                if(direction == Vector3.back)
                    if (node.Position.z < origin.z && node.Position.x == origin.x) nodesInDirection.Add(node);
                if(direction == Vector3.left)
                    if (node.Position.x < origin.x && node.Position.z == origin.z) nodesInDirection.Add(node);
                if (direction == Vector3.right)
                    if (node.Position.x > origin.x && node.Position.z == origin.z) nodesInDirection.Add(node);
            }

            if(nodesInDirection.Count > 0)
            {
                Node nearestNode = nodesInDirection[0];

                foreach(Node node in nodesInDirection)
                {
                    if (Vector3.Distance(origin, nearestNode.Position) > Vector3.Distance(origin, node.Position))
                        nearestNode = node;
                }

                nearestNodePosition = nearestNode.Position;
                nearestNodePosition.y = origin.y;

                if (Vector3.Distance(origin, nearestNode.Position) < threshold)
                    return nearestNodePosition;
                else
                    return origin;
            }

            return nearestNodePosition;
        }

        #endregion
    }
}
