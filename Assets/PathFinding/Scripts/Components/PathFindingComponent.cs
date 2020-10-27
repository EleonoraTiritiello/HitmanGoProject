using UnityEngine;

namespace HitmanGO
{
    /// <summary>
    /// Class <c> PathFindingComponent </c> it's a component that communicates with the grid of nodes to allow movement on the grid
    /// </summary>
    public class PathFindingComponent : MonoBehaviour
    {
        #region Variables

        #region Public Variables

        /// <summary>
        /// Returns the <c> Node </c> above the current <c> Node </c>
        /// </summary>
        public Node UpNode { get { return GetAdjacentConnectedNode(Vector2Int.up); } }
        /// <summary>
        /// Returns the <c> Node </c> below the current <c> Node </c>
        /// </summary>
        public Node DownNode { get { return GetAdjacentConnectedNode(Vector2Int.down); } }
        /// <summary>
        /// Returns the <c> Node </c> to the left of the current <c> Node </c>
        /// </summary>
        public Node LeftNode { get { return GetAdjacentConnectedNode(Vector2Int.left); } }
        /// <summary>
        /// Returns the <c> Node </c> to the right of the current <c> Node </c>
        /// </summary>
        public Node RightNode { get { return GetAdjacentConnectedNode(Vector2Int.right); } }

        #endregion

        #region Private Variables

        /// <summary>
        /// The current <c> Node </c>
        /// </summary>
        private Node _currentNode;
        /// <summary>
        /// The <c> Node </c> you want to get to
        /// </summary>
        private Node _targetNode;

        #endregion

        #endregion

        #region Unity Callbacks

        private void Start()
        {
            _currentNode = GridManager.GetInstance.GetNode(GridManager.GetInstance.GetGridPosition(transform.position, snapToNearestNode: true));
            transform.position = new Vector3(_currentNode.transform.position.x, transform.position.y, _currentNode.transform.position.z);
            _targetNode = _currentNode;
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Get the <c> Node </c> you want to get to
        /// </summary>
        /// <returns> The target <c> Node </c> </returns>
        public Node GetTargetNode() => _targetNode;
        /// <summary>
        /// Allows you to change the <c> Node </c> you want to reach
        /// </summary>
        /// <param name="node"> The <c> Node </c> you want to get to </param>
        public void SetTargetNode(Node node) => _targetNode = node;

        /// <summary>
        /// Get the current <c> Node </c>
        /// </summary>
        /// <returns> The current <c> Node </c> </returns>
        public Node GetCurrentNode() => _currentNode;
        /// <summary>
        /// Allows you to change the <c> Node </c> you are on
        /// </summary>
        /// <param name="node"> The <c> Node </c> you want to set </param>
        public void SetCurrentNode(Node node) => _currentNode = node;

        #endregion

        #region Private Methods

        /// <summary>
        /// Get the first <c> Node </c> connected to the current <c> Node </c> in a given direction
        /// </summary>
        /// <param name="direction"> The direction in which the <c> Node </c> must be relative to the current <c> Node </c> </param>
        /// <returns> Returns the connected <c> Node </c> if found, otherwise it returns <c> null </c> </returns>
        private Node GetAdjacentConnectedNode(Vector2Int direction)
        {
            if (_currentNode == null)
                throw new NoNodeException($"The 'currentNode' of the 'PathFindingComponent' on the object '{name}' does not exist");

            if (_currentNode.Connections == null)
                throw new NodeConnectionException($"The 'currentNode' connection list of the 'PathFindingComponent' on the object '{name}' is non-existent");

            if (_currentNode.Connections.Count > 0)
            {
                //Check all connections of the current Node
                foreach (Connection connection in _currentNode.Connections)
                {
                    //Check if the Node is in the correct direction
                    if (connection.To.GridPosition == _currentNode.GridPosition + direction)
                        return connection.To;
                }
            }
                
            return null;
        }

        #endregion

        #endregion
    }
}