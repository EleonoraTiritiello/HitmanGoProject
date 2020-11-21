using UnityEngine;
using System.Collections.Generic;

namespace HitmanGO
{
    public class OnCalculatingEnemyActionState : StateMachineBehaviour
    {
        private PlayerController _player;
        private EnemyController[] _enemies;

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (_player == null) _player = GameManager.GetInstance.Player;
            if (_enemies == null)
            {
                UpdateEnemyArray();
                LevelManger.GetInstance.EnemyListModifyed += UpdateEnemyArray;
            }

            CalculateEnemiesActions();
            LevelManger.GetInstance.ChangeState(LevelManger.States.OnPlayerAction);
        }

        #region Private Methods

        private void CalculateEnemiesActions()
        {
            foreach (EnemyController enemy in _enemies)
            {
                CalculateEnemyAction(enemy);

                Debug.Log($"Setting {enemy.name} action to -> {enemy.ToDoAction}");
            }
        }

        private void CalculateEnemyAction(EnemyController enemy)
        {
            enemy.ToDoAction = EnemyController.Actions.None;

            MoveTowardsPlayer(enemy);

            bool overrideAction = false;

            if (enemy.IsAlerted && enemy.ToDoActions.Count <= 0)
            {
                Debug.LogWarning("Calculate path to player");
                CalculatePathToNode(enemy, enemy.TargetNode);
            }

            if(enemy.ToDoActions.Count > 0)
            {
                EnemyController.Actions toDoAction = enemy.ToDoActions.Peek();
                Debug.LogWarning($"Il nemico dovrebbe -> {toDoAction}");

                if (_player.ToDoAction == PlayerController.Actions.Select)
                {
                    if (toDoAction == EnemyController.Actions.MoveUp
                        || toDoAction == EnemyController.Actions.MoveDown
                        || toDoAction == EnemyController.Actions.MoveLeft
                        || toDoAction == EnemyController.Actions.MoveRight)
                    {
                        Debug.LogWarning("Il nemico voleva muoversi ma il player è stato selezionato");
                        enemy.ToDoAction = EnemyController.Actions.None;
                        overrideAction = true;
                    }
                }
                else if(_player.ToDoAction == PlayerController.Actions.MoveUp
                    || _player.ToDoAction == PlayerController.Actions.MoveDown
                    || _player.ToDoAction == PlayerController.Actions.MoveLeft
                    || _player.ToDoAction == PlayerController.Actions.MoveRight)
                {
                    if (toDoAction == EnemyController.Actions.FaceUp
                    || toDoAction == EnemyController.Actions.FaceDown
                    || toDoAction == EnemyController.Actions.FaceLeft
                    || toDoAction == EnemyController.Actions.FaceRight)
                    {
                        Debug.LogWarning("Il nemico voleva girarsi ma il player si vuole muovere");
                        enemy.ToDoAction = EnemyController.Actions.None;
                        overrideAction = true;
                    }
                }

                if (!overrideAction)
                    enemy.ToDoAction = enemy.ToDoActions.Pop();
            }

            switch (enemy.ToDoAction)
            {
                case EnemyController.Actions.FaceUp:
                    if (enemy.PFC.UpNode == null)
                        enemy.ToDoAction = EnemyController.Actions.None;
                    break;
                case EnemyController.Actions.FaceDown:
                    if (enemy.PFC.DownNode == null)
                        enemy.ToDoAction = EnemyController.Actions.None;
                    break;
                case EnemyController.Actions.FaceLeft:
                    if (enemy.PFC.LeftNode == null)
                        enemy.ToDoAction = EnemyController.Actions.None;
                    break;
                case EnemyController.Actions.FaceRight:
                    if (enemy.PFC.RightNode == null)
                        enemy.ToDoAction = EnemyController.Actions.None;
                    break;
                case EnemyController.Actions.MoveUp:
                    if (enemy.PFC.UpNode != null)
                        enemy.PFC.SetTargetNode.Invoke(enemy.PFC.UpNode);
                    else
                        enemy.ToDoAction = EnemyController.Actions.None;
                    break;
                case EnemyController.Actions.MoveDown:
                    if (enemy.PFC.DownNode != null)
                        enemy.PFC.SetTargetNode.Invoke(enemy.PFC.DownNode);
                    else
                        enemy.ToDoAction = EnemyController.Actions.None;
                    break;
                case EnemyController.Actions.MoveLeft:
                    if (enemy.PFC.LeftNode != null)
                        enemy.PFC.SetTargetNode.Invoke(enemy.PFC.LeftNode);
                    else
                        enemy.ToDoAction = EnemyController.Actions.None;
                    break;
                case EnemyController.Actions.MoveRight:
                    if (enemy.PFC.RightNode != null)
                        enemy.PFC.SetTargetNode.Invoke(enemy.PFC.RightNode);
                    else
                        enemy.ToDoAction = EnemyController.Actions.None;
                    break;
                default:
                    break;
            }

        }

        private void CalculatePathToNode(EnemyController enemy, Node targetNode)
        {
            Node[] path = PathFindingManager.GetInstance.CalculatePath(enemy.PFC.GetCurrentNode(), targetNode); 

            Node currentNode = enemy.PFC.GetCurrentNode();
            Node upNode, downNode, leftNode, rightNode;

            EnemyController.FacingDirections enemyFacingDirection = enemy.FacingDirection;

            List<EnemyController.Actions> toDoActions = new List<EnemyController.Actions>();

            foreach (Node node in path)
            {
                if (node == enemy.PFC.GetCurrentNode())
                    continue;

                upNode = GridManager.GetInstance.GetAdjacentConnectedNode(currentNode, Vector2Int.up, true);
                downNode = GridManager.GetInstance.GetAdjacentConnectedNode(currentNode, Vector2Int.down, true);
                leftNode = GridManager.GetInstance.GetAdjacentConnectedNode(currentNode, Vector2Int.left, true);
                rightNode = GridManager.GetInstance.GetAdjacentConnectedNode(currentNode, Vector2Int.right, true);

                if (node == upNode)
                {
                    if (enemyFacingDirection != EnemyController.FacingDirections.Up)
                    {
                        toDoActions.Add(EnemyController.Actions.FaceUp);
                        enemyFacingDirection = EnemyController.FacingDirections.Up;
                    }

                    toDoActions.Add(EnemyController.Actions.MoveUp);              
                }
                else if (node == downNode)
                {
                    if (enemyFacingDirection != EnemyController.FacingDirections.Down)
                    {
                        toDoActions.Add(EnemyController.Actions.FaceDown);
                        enemyFacingDirection = EnemyController.FacingDirections.Down;
                    }

                    toDoActions.Add(EnemyController.Actions.MoveDown);
                }
                else if (node == leftNode)
                {
                    if (enemyFacingDirection != EnemyController.FacingDirections.Left)
                    {
                        toDoActions.Add(EnemyController.Actions.FaceLeft);
                        enemyFacingDirection = EnemyController.FacingDirections.Left;
                    }

                    toDoActions.Add(EnemyController.Actions.MoveLeft);            
                }
                else if (node == rightNode)
                {
                    if (enemyFacingDirection != EnemyController.FacingDirections.Right)
                    {
                        toDoActions.Add(EnemyController.Actions.FaceRight);
                        enemyFacingDirection = EnemyController.FacingDirections.Right;
                    }

                    toDoActions.Add(EnemyController.Actions.MoveRight); 
                }
                else
                    Debug.LogError($"Il nodo corrente ({node.name}) non corrisponde a nessun nodo adiacente al nodo '{currentNode.name}'");
                
                currentNode = node;
            }

            toDoActions.Reverse();

            foreach(EnemyController.Actions action in toDoActions)
            {
                enemy.ToDoActions.Push(action);
            }
        }

        private void MoveTowardsPlayer(EnemyController enemy)
        {
            if (_player.PFC.GetTargetNode() == enemy.PFC.UpNode && enemy.FacingDirection == EnemyController.FacingDirections.Up)
                enemy.ToDoActions.Push(EnemyController.Actions.MoveUp);
            else if (_player.PFC.GetTargetNode() == enemy.PFC.DownNode && enemy.FacingDirection == EnemyController.FacingDirections.Down)
                enemy.ToDoActions.Push(EnemyController.Actions.MoveDown);
            else if (_player.PFC.GetTargetNode() == enemy.PFC.LeftNode && enemy.FacingDirection == EnemyController.FacingDirections.Left)
                enemy.ToDoActions.Push(EnemyController.Actions.MoveLeft);
            else if (_player.PFC.GetTargetNode() == enemy.PFC.RightNode && enemy.FacingDirection == EnemyController.FacingDirections.Right)
                enemy.ToDoActions.Push(EnemyController.Actions.MoveRight);
        }

        private void UpdateEnemyArray()
        {
            _enemies = LevelManger.GetInstance.GetEnemiesArray();
        }

        #endregion
    }

}
