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

            LevelManger.GetInstance.ChangeState(LevelManger.States.OnCalculatingEnemyAction);
        }

        private void CalculatePlayerAction()
        {
            switch (_player.CurrentAction)
            {
                case PlayerController.Actions.None:
                    Debug.LogError("An error occurred while selecting the Player action");
                    break;
                case PlayerController.Actions.MoveUp:
                    _player.PFC.SetTargetNode.Invoke(_player.PFC.UpNode);
                    if (_player.PFC.GetTargetNode() == null)
                        _player.CurrentAction = PlayerController.Actions.None;
                    break;
                case PlayerController.Actions.MoveDown:
                    _player.PFC.SetTargetNode.Invoke(_player.PFC.DownNode);
                    if (_player.PFC.GetTargetNode() == null)
                        _player.CurrentAction = PlayerController.Actions.None;
                    break;
                case PlayerController.Actions.MoveLeft:
                    _player.PFC.SetTargetNode.Invoke(_player.PFC.LeftNode);
                    if (_player.PFC.GetTargetNode() == null)
                        _player.CurrentAction = PlayerController.Actions.None;
                    break;
                case PlayerController.Actions.MoveRight:
                    _player.PFC.SetTargetNode.Invoke(_player.PFC.RightNode);
                    if (_player.PFC.GetTargetNode() == null)
                        _player.CurrentAction = PlayerController.Actions.None;
                    break;
                default:
                    break;
            }
        }
    }
}
