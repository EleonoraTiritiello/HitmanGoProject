using UnityEngine;
using System.Collections.Generic;

namespace HitmanGO
{
    public class OnPlayerActionState : StateMachineBehaviour
    {
        private PlayerController _player;

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (_player == null) _player = GameManager.GetInstance.Player;

            Debug.Log($"Player -> {_player.ToDoAction}");

            PerformPlayerAction();

            LevelManger.GetInstance.ChangeState(LevelManger.States.OnEnemyAction);
        }

        private void PerformPlayerAction()
        {
            switch (_player.ToDoAction)
            {
                case PlayerController.Actions.MoveUp:
                    _player.SetCurrentState(PlayerController.States.Moving);
                    _player.MoveToPosition(_player.PFC.GetTargetNode().transform.position);
                    _player.PFC.SetCurrentNode.Invoke(_player.PFC.GetTargetNode());
                    VerifyKills();
                    VerifyTargetReached();
                    break;
                case PlayerController.Actions.MoveDown:
                    _player.SetCurrentState(PlayerController.States.Moving);
                    _player.MoveToPosition(_player.PFC.GetTargetNode().transform.position);
                    _player.PFC.SetCurrentNode.Invoke(_player.PFC.GetTargetNode());
                    VerifyKills();
                    VerifyTargetReached();
                    break;
                case PlayerController.Actions.MoveLeft:
                    _player.SetCurrentState(PlayerController.States.Moving);
                    _player.MoveToPosition(_player.PFC.GetTargetNode().transform.position);
                    _player.PFC.SetCurrentNode.Invoke(_player.PFC.GetTargetNode());
                    VerifyKills();
                    VerifyTargetReached();
                    break;
                case PlayerController.Actions.MoveRight:
                    _player.SetCurrentState(PlayerController.States.Moving);
                    _player.MoveToPosition(_player.PFC.GetTargetNode().transform.position);
                    _player.PFC.SetCurrentNode.Invoke(_player.PFC.GetTargetNode());
                    VerifyKills();
                    VerifyTargetReached();
                    break;
                case PlayerController.Actions.Select:
                    if(_player.Select != null)
                        _player.Select.Invoke();
                    break;
                case PlayerController.Actions.PickupRock:
                    _player.SetRockStance();

                    List<PathFindingComponent> nodePopulation = PathFindingManager.GetInstance.GetNodePopulation(_player.PFC.GetCurrentNode());

                    for (int i = 0; i < nodePopulation.Count; i++)
                    {
                        Rock rock = nodePopulation[i].transform.GetComponent<Rock>();

                        if (rock != null)
                            Destroy(rock.gameObject);
                    }

                    ShowThrowPositions();             
                    break;
                case PlayerController.Actions.Die:
                    if(_player.Die != null)
                        _player.Die.Invoke();
                    break;
                default:
                    break;
            }
        }

        private void VerifyTargetReached()
        {
            if (_player.PFC.GetCurrentNode() == LevelManger.GetInstance.EndNode)
                LevelManger.GetInstance.LevelCompleted = true;
        }

        private void VerifyKills()
        {
            EnemyController currentEnemy = null;

            foreach(PathFindingComponent pfc in PathFindingManager.GetInstance.GetNodePopulation(_player.PFC.GetCurrentNode()))
            {
                currentEnemy = pfc.transform.GetComponent<EnemyController>();

                if (currentEnemy != null)
                    currentEnemy.Die.Invoke();
            }
        }

        private void ShowThrowPositions()
        {
            Node node = GridManager.GetInstance.GetNode(_player.PFC.GetCurrentNode().GridPosition + Vector2Int.up, true);

            if (node != null)
            {
                _player.ThrowPositionUp.transform.position = node.transform.position;
                _player.ThrowPositionUp.SetActive(true);
            }

            node = GridManager.GetInstance.GetNode(_player.PFC.GetCurrentNode().GridPosition + Vector2Int.down, true);

            if (node != null)
            {
                _player.ThrowPositionDown.transform.position = node.transform.position;
                _player.ThrowPositionDown.SetActive(true);
            }

            node = GridManager.GetInstance.GetNode(_player.PFC.GetCurrentNode().GridPosition + Vector2Int.left, true);

            if (node != null)
            {
                _player.ThrowPositionLeft.transform.position = node.transform.position;
                _player.ThrowPositionLeft.SetActive(true);
            }

            node = GridManager.GetInstance.GetNode(_player.PFC.GetCurrentNode().GridPosition + Vector2Int.right, true);

            if (node != null)
            {
                _player.ThrowPositionRight.transform.position = node.transform.position;
                _player.ThrowPositionRight.SetActive(true);
            }
        }
    }

}
