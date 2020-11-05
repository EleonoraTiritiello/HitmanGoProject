using System.Collections.Generic;
using UnityEngine;

namespace HitmanGO
{
    /// <summary>
    /// Class <c> Node </c> represents a point on the grid
    /// </summary>
    public class Node : MonoBehaviour
    {
        #region DEBUG

        /// <summary>
        /// Apply an offset to the Gizmos to prevent the lines from overlapping
        /// </summary>
        [HideInInspector]
        public Vector3 ConnectionOffset = Vector3.zero; //DEBUG
        /// <summary>
        /// With what color the Gizmos will draw the node and its connections
        /// </summary>
        private Color _gizmosColor = Color.black; //DEBUG

        #endregion

        #region Variables

        #region Public Variables

        /// <summary>
        /// The coordinates of the node on the grid
        /// </summary>
        public Vector2Int GridPosition { get; private set; }
        /// <summary>
        /// The list that contains all the connections of the node
        /// </summary>
        public List<Connection> Connections { get; private set; }

        #endregion

        #region Private Variables

        /// <summary>
        /// A structure that saves in which directions the node can connect to other nodes
        /// </summary>
        [SerializeField]
        private EnabledConnections _enabledConnections = default; 

        #endregion

        #endregion

        #region Unity Callbacks

        private void Awake()
        {
            //Randomize the color of the Gizmos to make it different from that of the other nodes
            _gizmosColor = Random.ColorHSV(); //DEBUG

            AddToGrid();

            //Calculate the grid position of the Node using the global position of the object
            GridPosition = GridManager.GetInstance.GetGridPosition(transform.position);
        }

        private void Start()
        {
            if (_enabledConnections.Up || _enabledConnections.Down || _enabledConnections.Left || _enabledConnections.Right)
                StartConnectionsCreation();
        }

        private void OnDrawGizmos() //DEBUG
        {
            Gizmos.color = _gizmosColor;

            //Draw the Node
            Gizmos.DrawWireCube(transform.position, Vector3.one * 0.1f);

            if (Application.isPlaying)
            {
                //Draw the connections
                if (Connections != null && Connections.Count > 0)
                {
                    foreach (Connection connection in Connections)
                    {
                        Gizmos.DrawLine(connection.From.transform.position + ConnectionOffset, connection.To.transform.position + ConnectionOffset);
                    }
                }

                Gizmos.color = Color.yellow;

                //Draw connections error
                if (_enabledConnections.Up)
                    if (!GridManager.GetInstance.GetNode(GridPosition + Vector2Int.up, bypassError: true))
                        Gizmos.DrawWireCube(transform.position, Vector3.one * 0.4f);
                if (_enabledConnections.Down)
                    if (!GridManager.GetInstance.GetNode(GridPosition + Vector2Int.down, bypassError: true))
                        Gizmos.DrawWireCube(transform.position, Vector3.one * 0.4f);
                if (_enabledConnections.Left)
                    if (!GridManager.GetInstance.GetNode(GridPosition + Vector2Int.left, bypassError: true))
                        Gizmos.DrawWireCube(transform.position, Vector3.one * 0.4f);
                if (_enabledConnections.Right)
                    if (!GridManager.GetInstance.GetNode(GridPosition + Vector2Int.right, bypassError: true))
                        Gizmos.DrawWireCube(transform.position, Vector3.one * 0.4f);
            }

            Gizmos.color = Color.yellow;

            //Draw connections warning
            if (!_enabledConnections.Up && !_enabledConnections.Down && !_enabledConnections.Left && !_enabledConnections.Right)
                Gizmos.DrawWireCube(transform.position, Vector3.one * 0.4f);    
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Add this <c> Node </c> to the grid
        /// </summary>
        private void AddToGrid()
        {
            if (!GridManager.GetInstance.Contains(this))
                GridManager.GetInstance.AddNode(this);
        }

        #region Connections Creation

        /// <summary>
        /// Check which sides the <c> Node </c> can connect on and create the connections
        /// </summary>
        private void StartConnectionsCreation()
        {
            List<Node> targetNodes = GetTargetNodes();
            CreateConnections(targetNodes);
            VerifyConnections();
        }

        /// <summary>
        /// Try to get the nodes this <c> Node </c> needs to connect to
        /// </summary>
        /// <returns> The list of nodes </returns>
        private List<Node> GetTargetNodes()
        {
            List<Node> targetNodes = new List<Node>();

            if (_enabledConnections.Up)
                targetNodes.Add(GridManager.GetInstance.GetNode(GridPosition + Vector2Int.up, bypassError: true));
            if (_enabledConnections.Down)
                targetNodes.Add(GridManager.GetInstance.GetNode(GridPosition + Vector2Int.down, bypassError: true));
            if (_enabledConnections.Left)
                targetNodes.Add(GridManager.GetInstance.GetNode(GridPosition + Vector2Int.left, bypassError: true));
            if (_enabledConnections.Right)
                targetNodes.Add(GridManager.GetInstance.GetNode(GridPosition + Vector2Int.right, bypassError: true));

            return targetNodes;
        }

        /// <summary>
        /// Create a connection between this <c> Node </c> and every <c> Node </c> in an array
        /// </summary>
        /// <param name="nodes"> The array of nodes </param>
        private void CreateConnections(List<Node> nodes)
        {
            foreach (Node node in nodes)
            {
                if (node == null)
                {
                    Debug.LogWarning($"Failed to create a connection between node '{name}' and an adjacent node");
                    continue;
                }

                CreateConnection(node);
            }
        }

        /// <summary>
        /// Create a connection between this <c> Node </c> and a given <c> Node </c>
        /// </summary>
        /// <param name="node"> The <c> Node </c> this <c> Node </c> connects to </param>
        private void CreateConnection(Node node)
        {
            if (Connections == null)
                Connections = new List<Connection>();

            Connections.Add(new Connection(this, node));

            //Offset the connection to prevent them from overlapping when drawn in Gizmos
            node.ConnectionOffset = ConnectionOffset + new Vector3(0, 0.06f, 0); //DEBUG
               
        }

        /// <summary>
        /// Check if any connections have been created
        /// </summary>
        private void VerifyConnections()
        {
            if (Connections == null)
                Debug.LogWarning($"The node '{name}' does not have a connection list");
        }

        #endregion

        #endregion
    }
}
