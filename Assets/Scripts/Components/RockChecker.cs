using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HitmanGO
{
    public class RockChecker : MonoBehaviour
    {
        #region Private Variables

        [SerializeField]
        private Vector3 _startingScale = new Vector3(0f, 0.01f, 0f);
        [SerializeField]
        private Vector3 _finalScale = new Vector3(9f, 0.01f, 9f);

        [SerializeField]
        private float _animationSpeed = 2f;

        #endregion

        #region Unity Callback

        private void OnDisable()
        {
            StopCoroutine(ScaleUp());
            transform.localScale = _startingScale;
        }

        private void OnEnable()
        {
            StartCoroutine(ScaleUp());
        }

        #endregion

        #region Private Methods

        private IEnumerator ScaleUp()
        {
            float progress = 0f;

            while (progress < _animationSpeed)
            {
                transform.localScale = Vector3.Lerp(_startingScale, _finalScale, progress);
                progress += Time.deltaTime;
                yield return null;
            }

            Node currentNode = GridManager.GetInstance.GetNearestNode(transform.position);

            List<Node> adjacentNodes = new List<Node>();

            adjacentNodes.Add(GridManager.GetInstance.GetNode(currentNode.GridPosition + Vector2Int.up, true));
            adjacentNodes.Add(GridManager.GetInstance.GetNode(currentNode.GridPosition + Vector2Int.down, true));
            adjacentNodes.Add(GridManager.GetInstance.GetNode(currentNode.GridPosition + Vector2Int.left, true));
            adjacentNodes.Add(GridManager.GetInstance.GetNode(currentNode.GridPosition + Vector2Int.right, true));

            adjacentNodes.Add(GridManager.GetInstance.GetNode(currentNode.GridPosition + Vector2Int.up + Vector2Int.left, true));
            adjacentNodes.Add(GridManager.GetInstance.GetNode(currentNode.GridPosition + Vector2Int.up + Vector2Int.right, true));
            adjacentNodes.Add(GridManager.GetInstance.GetNode(currentNode.GridPosition + Vector2Int.down + Vector2Int.left, true));
            adjacentNodes.Add(GridManager.GetInstance.GetNode(currentNode.GridPosition + Vector2Int.down + Vector2Int.right, true));

            List<PathFindingComponent> pfcs;

            foreach (Node node in adjacentNodes)
            {
                if (node != null)
                {
                    pfcs = PathFindingManager.GetInstance.GetNodePopulation(node);

                    foreach (PathFindingComponent pfc in pfcs)
                    {
                        EnemyController enemy = pfc.transform.GetComponent<EnemyController>();

                        if (enemy != null)
                        {
                            enemy.AlertEvent.Invoke();
                            enemy.Alert(currentNode);
                        }
                    }
                }
            }
            GameManager.GetInstance.Player.ThrowPositionUp.SetActive(false);
            GameManager.GetInstance.Player.ThrowPositionDown.SetActive(false);
            GameManager.GetInstance.Player.ThrowPositionLeft.SetActive(false);
            GameManager.GetInstance.Player.ThrowPositionRight.SetActive(false);

            GameManager.GetInstance.Player.ToDoAction = PlayerController.Actions.None;

            gameObject.SetActive(false);
        }

        #endregion
    }
}
