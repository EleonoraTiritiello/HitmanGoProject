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
        public Vector3 ConnectionOffset = Vector3.zero; //DEBUG
        /// <summary>
        /// With what color the Gizmos will draw the node and its connections
        /// </summary>
        private Color _gizmosColor; //DEBUG

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
        private EnabledConnections _enabledConnections; 

        #endregion

        #endregion

        #region Unity Callbacks

        private void Awake()
        {
            //Randomize the color of the Gizmos to make it different from that of the other nodes
            _gizmosColor = Random.ColorHSV(); //DEBUG

            AddToGrid();
            CalculateGridPosition();
        }

        private void Start()
        {
            SetupConnections();
        }

        #region DEBUG

        private void OnDrawGizmos() //DEBUG
        {
            Gizmos.color = _gizmosColor;

            //Draw the Node
            if (GridPosition != null)
                Gizmos.DrawWireCube(transform.position, Vector3.one * 0.1f);

            //Draw the connections
            if (Connections != null && Connections.Count > 0)
            {
                foreach (Connection connection in Connections)
                {
                    Gizmos.DrawLine(connection.From.transform.position + ConnectionOffset, connection.To.transform.position + ConnectionOffset);
                }
            }
        }

        #endregion

        #endregion

        #region Private Methods

        /// <summary>
        /// Add this <c> Node </c> to the grid
        /// </summary>
        private void AddToGrid()
        {
            if(!GridManager.GetInstance.Contains(this))
                GridManager.GetInstance.AddNode(this);
        }

        /// <summary>
        /// Calculate the grid position of the <c> Node </c> using the global position of the object
        /// </summary>
        private void CalculateGridPosition()
        {
            int x = 0;
            int y = 0;

            //Divide the object's global coordinates by a defined value to get the grid coordinates
            if ((int)transform.position.x % GridManager.GetInstance.WorldTransformDivider == 0)
                x = (int)transform.position.x / GridManager.GetInstance.WorldTransformDivider;

            if ((int)transform.position.z % GridManager.GetInstance.WorldTransformDivider == 0)
                y = (int)transform.position.z / GridManager.GetInstance.WorldTransformDivider;

            //Assign coordinates to the variable
            GridPosition = new Vector2Int(x, y);
        }

        #region Connections Creation

        /// <summary>
        /// Check which sides the <c> Node </c> can connect on and create the connections
        /// </summary>
        private void SetupConnections()
        {
            if (Connections == null) Connections = new List<Connection>();

            if (_enabledConnections.Up)
                CreateConnection(GridManager.GetInstance.GetNode(GridPosition.x, GridPosition.y + 1));
            if (_enabledConnections.Down)
                CreateConnection(GridManager.GetInstance.GetNode(GridPosition.x, GridPosition.y - 1));
            if (_enabledConnections.Left)
                CreateConnection(GridManager.GetInstance.GetNode(GridPosition.x - 1, GridPosition.y));
            if (_enabledConnections.Right)
                CreateConnection(GridManager.GetInstance.GetNode(GridPosition.x + 1, GridPosition.y));
        }

        /// <summary>
        /// Create a connection between this <c> Node </c> and a given <c> Node </c>
        /// </summary>
        /// <param name="node"> The <c> Node </c> this <c> Node </c> connects to </param>
        private void CreateConnection(Node node)
        {
            Connections.Add(new Connection(this, node));

            //Offset the connection to prevent them from overlapping when drawn in Gizmos
            node.ConnectionOffset = ConnectionOffset + new Vector3(0, 0.06f, 0); //DEBUG
        }

        #endregion

        #endregion
    }
}
