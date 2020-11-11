using System.Collections.Generic;
using UnityEngine;

namespace HitmanGO
{
    /// <summary>
    /// Class <c> PathFindingManager </c> takes care of the management of all <c> PathFindingComponent </c> in the scene
    /// </summary>
    public class PathFindingManager : Singleton<PathFindingManager>
    {
        #region Private Variables

        /// <summary>
        /// The list that contains all the <c> PathFindingComponents </c> in the scene
        /// </summary>
        private readonly List<PathFindingComponent> _pfcList = new List<PathFindingComponent>();

        private Node _lastNode;

        #endregion

        #region Unity Callbacks

        private void Start()
        {
            foreach (PathFindingComponent pfc in _pfcList)
            {
                if (pfc != this)
                    pfc.SetTargetNode += ArrangePFCComponents;
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        public void ArrangePFCComponents(Node node)
        {
            if (_lastNode != node)
                ArrangePFCComponents(_lastNode);

            if (node == null)
            {
                _lastNode = node;
                return;
            }

            PathFindingComponent[] nodePopulation = GetNodePopulation(node);

            if (nodePopulation.Length == 1)
            {
                ResetPFCTargetPosition(nodePopulation[0]);
                RequestPositionAdjustment(nodePopulation[0], nodePopulation[0].GetTargetNode().transform.position);

                _lastNode = node;
                return;
            }

            int i;   
            float angle;
            Vector3 targetPosition = Vector3.zero;

            for (i = 0; i < nodePopulation.Length; i++)
            {
                angle = 360f / nodePopulation.Length * i;

                targetPosition.x = Mathf.Cos(angle * Mathf.Deg2Rad);
                targetPosition.z = Mathf.Sin(angle * Mathf.Deg2Rad);

                targetPosition += node.transform.position;

                nodePopulation[i].SetTargetPosition(targetPosition);
                RequestPositionAdjustment(nodePopulation[i], targetPosition);
            }

            _lastNode = node;
        }

        /// <summary>
        /// Get all the <c> PathFindingComponents </c> that target the given <c> Node </c>
        /// </summary>
        /// <param name="targetNode"> A given node </param>
        /// <returns> A <c> PathFindingComponent </c> array </returns>
        public PathFindingComponent[] GetNodePopulation(Node targetNode)
        {
            List<PathFindingComponent> population = new List<PathFindingComponent>();

            foreach (PathFindingComponent pfc in _pfcList)
            {
                if (pfc.GetTargetNode() == targetNode)
                    population.Add(pfc);
            }

            return population.ToArray();
        }

        /// <summary>
        /// Get the <c> PathFindingComponent </c> array
        /// </summary>
        /// <returns> A <c> PathFindingComponent </c> array </returns>
        public PathFindingComponent[] GetPFCArray() => _pfcList.ToArray();

        /// <summary>
        /// Checks if the <c> PathFindingComponent </c> list contains a given element
        /// </summary>
        /// <param name="pfc"> A given <c> PathFindingComponent </c> </param>
        /// <returns> Returns true if the item is in the list, otherwise returns false </returns>
        public bool Contains(PathFindingComponent pfc) => _pfcList.Contains(pfc);

        /// <summary>
        /// Add a <c> PathFindingComponent </c> to the list
        /// </summary>
        /// <param name="pfc"> A given <c> PathFindingComponent </c> </param>
        public void AddPFC(PathFindingComponent pfc) => _pfcList.Add(pfc);

        #endregion

        #region Private Methods

        private void RequestPositionAdjustment(PathFindingComponent pfc, Vector3 adjustedPosition)
        {
            if (pfc.AdjustPosition != null)
                pfc.AdjustPosition.Invoke(adjustedPosition);
        }

        /// <summary>
        /// Resets the target position of a <c> PathFindingComponent </c> to the position of its target node
        /// </summary>
        /// <param name="pfc"> A given <c> PathFindingComponent </c> </param>
        private void ResetPFCTargetPosition(PathFindingComponent pfc) => pfc.SetTargetPosition(pfc.GetTargetNode().transform.position);

        #endregion

        #endregion
    }
}
