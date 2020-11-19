using UnityEngine;

namespace HitmanGO
{
    public class OnCalculatingPlayerActionState : StateMachineBehaviour
    {
        private PlayerController _player;

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (_player == null) _player = GameManager.GetInstance.Player;

            CalculatePlayerAction();

            Debug.Log($"Setting player action to -> {_player.ToDoAction}");

            LevelManger.GetInstance.ChangeState(LevelManger.States.OnCalculatingEnemyAction);
        }

        private void CalculatePlayerAction()
        {
            switch (_player.ToDoAction)
            {
                case PlayerController.Actions.None:
                    Debug.LogError("An error occurred while selecting the Player action");
                    break;
                case PlayerController.Actions.MoveUp:
                    _player.PFC.SetTargetNode.Invoke(_player.PFC.UpNode);
                    if (_player.PFC.GetTargetNode() == null)
                        _player.ToDoAction = PlayerController.Actions.None;
                    else
                        VerifyKills();
                    break;
                case PlayerController.Actions.MoveDown:
                    _player.PFC.SetTargetNode.Invoke(_player.PFC.DownNode);
                    if (_player.PFC.GetTargetNode() == null)
                        _player.ToDoAction = PlayerController.Actions.None;
                    else
                        VerifyKills();
                    break;
                case PlayerController.Actions.MoveLeft:
                    _player.PFC.SetTargetNode.Invoke(_player.PFC.LeftNode);
                    if (_player.PFC.GetTargetNode() == null)
                        _player.ToDoAction = PlayerController.Actions.None;
                    else
                        VerifyKills();
                    break;
                case PlayerController.Actions.MoveRight:
                    _player.PFC.SetTargetNode.Invoke(_player.PFC.RightNode);
                    if (_player.PFC.GetTargetNode() == null)
                        _player.ToDoAction = PlayerController.Actions.None;
                    else
                        VerifyKills();
                    break;
                default:
                    break;
            }
        }

        private void VerifyKills()
        {
            PathFindingComponent[] targetNodePopulation = _player.PFC.TargetNodePopulation;

            if (targetNodePopulation.Length > 0)
            {
                for (int i = 0; i < targetNodePopulation.Length; i++)
                {
                    EnemyController enemy = targetNodePopulation[i].GetComponent<EnemyController>();

                    if (enemy != null)
                        enemy.ToDoAction = EnemyController.Actions.Die;
                }
            }
        }
    }
}
