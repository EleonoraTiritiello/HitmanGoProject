using System.Collections.Generic;
using UnityEngine;

namespace SB.HitmanGO
{
    public sealed class PathFindingManager : Singleton<PathFindingManager>
    {
        #region Private Variables

        private List<Node> _nodes = new List<Node>();

        #endregion

        #region Public Methods

        public List<Node> GetNodes() => _nodes;

        public bool CheckNode(Node node) => _nodes.Contains(node);

        public void AddNode(Node node) => _nodes.Add(node);

        public Vector3 GetNodePosition(Node node) => node.Position;

        #endregion
    }
}
