using System;
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

        #region Events

        public Action<Vector3> AdjustPosition;

        public Action<Node> SetCurrentNode;
        public Action<Node> SetTargetNode;

        #endregion

        #region Adjacent Nodes

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

        /// <summary>
        /// Returns the list of <c> PathFindingComponent </c> which have as <c> _targetNode </c> the same node as this component
        /// </summary>
        public PathFindingComponent[] TargetNodePopulation { get { return PathFindingManager.GetInstance.GetNodePopulation(_targetNode); } }

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

        /// <summary>
        /// The world position of the <c> _targetNode </c>
        /// </summary>
        private Vector3 _targetPosition;

        #endregion

        #endregion

        #region Unity Callbacks

        private void Awake()
        {
            if (!PathFindingManager.GetInstance.Contains(this))
                PathFindingManager.GetInstance.AddPFC(this);

            if (SetCurrentNode == null) SetCurrentNode = OnCurrentNodeSetted;
            if (SetTargetNode == null) SetTargetNode = OnTargetNodeSetted;
        }

        private void Start()
        {
            Initialize();
        }

        #endregion

        #region Methods

        #region Public Methods

        #region Getters

        /// <summary>
        /// Get the global coordinates of the <c> _targetNode </c>
        /// </summary>
        /// <returns> The global coordinates of the <c> _targetNode </c> </returns>
        public Vector3 GetTargetPosition() => _targetPosition;

        /// <summary>
        /// Get the <c> Node </c> you want to get to
        /// </summary>
        /// <returns> The target <c> Node </c> </returns>
        public Node GetTargetNode() => _targetNode;

        /// <summary>
        /// Get the current <c> Node </c>
        /// </summary>
        /// <returns> The current <c> Node </c> </returns>
        public Node GetCurrentNode() => _currentNode;

        #endregion

        #region Setters

        /// <summary>
        /// Set the <c> _targetPosition to a given value </c>
        /// </summary>
        /// <param name="targetPosition"> A given target position </param>
        public void SetTargetPosition(Vector3 targetPosition) => _targetPosition = targetPosition;

        #endregion

        #endregion

        #region Private Methods

        /// <summary>
        /// Sets the initial value of _currentNode and _targetNode
        /// </summary>
        private void Initialize()
        {
            _currentNode = GridManager.GetInstance.GetNode(GridManager.GetInstance.GetGridPosition(transform.position, snapToNearestNode: true));
            transform.position = new Vector3(_currentNode.transform.position.x, transform.position.y, _currentNode.transform.position.z);
            _targetNode = _currentNode;
        }

        #region Setters

        /// <summary>
        /// Change the <c> Node </c> you want to reach
        /// </summary>
        /// <param name="node"> The <c> Node </c> you want to get to </param>
        private void OnTargetNodeSetted(Node node) => _targetNode = node;

        /// <summary>
        /// Change the <c> Node </c> you are on
        /// </summary>
        /// <param name="node"> The <c> Node </c> you want to set </param>
        private void OnCurrentNodeSetted(Node node) => _currentNode = node;

        #endregion

        /// <summary>
        /// Get the first <c> Node </c> connected to the current <c> Node </c> in a given direction
        /// </summary>
        /// <param name="direction"> The direction in which the <c> Node </c> must be relative to the current <c> Node </c> </param>
        /// <returns> Returns the connected <c> Node </c> if found, otherwise it returns <c> null </c> </returns>
        private Node GetAdjacentConnectedNode(Vector2Int direction)
        {
            return GridManager.GetInstance.GetAdjacentConnectedNode(_currentNode, direction);
        }

        #endregion

        #endregion
    }
}