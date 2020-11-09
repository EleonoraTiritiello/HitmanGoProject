﻿using System.Collections.Generic;
using UnityEngine;

namespace HitmanGO
{
    /// <summary>
    /// Class <c> PathFindingManager </c> takes care of the management of all <c> PathFindingComponent </c> in the scene
    /// </summary>
    public class PathFindingManager : Singleton<PathFindingManager>
    {
        #region Variables

        #region Public Variables

        /// <summary>
        /// The list that contains all the <c> PathFindingComponents </c> in the scene
        /// </summary>
        public readonly List<PathFindingComponent> PFCList = new List<PathFindingComponent>();

        #endregion

        #region Private Variables

        private Node _lastNode;

        #endregion

        #endregion

        #region Unity Callbacks

        private void Start()
        {
            foreach (PathFindingComponent pfc in PFCList)
            {
                if(pfc.GetComponent<EnemyController>() != null)
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
                RequestPositionAdjustment(nodePopulation[0], nodePopulation[0].GetCurrentNode().transform.position);

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

            foreach (PathFindingComponent pfc in PFCList)
            {
                if (pfc.GetCurrentNode() == targetNode)
                    population.Add(pfc);
            }

            return population.ToArray();
        }

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
