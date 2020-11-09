using UnityEngine;

namespace HitmanGO
{
    public class OnPlayerActionState : StateMachineBehaviour
    {
        private PlayerController _player;

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (_player == null) _player = GameManager.GetInstance.Player;

            PerformPlayerAction();

            LevelManger.GetInstance.ChangeState(LevelManger.States.OnEnemyAction);
        }

        private void PerformPlayerAction()
        {
            switch (_player.CurrentAction)
            {
                case PlayerController.Actions.MoveUp:
                    _player.SetCurrentState(PlayerController.States.Moving);
                    _player.MoveToPosition(_player.PFC.GetTargetNode().transform.position);
                    _player.PFC.SetCurrentNode.Invoke(_player.PFC.GetTargetNode());
                    break;
                case PlayerController.Actions.MoveDown:
                    _player.SetCurrentState(PlayerController.States.Moving);
                    _player.MoveToPosition(_player.PFC.GetTargetNode().transform.position);
                    _player.PFC.SetCurrentNode.Invoke(_player.PFC.GetTargetNode());
                    break;
                case PlayerController.Actions.MoveLeft:
                    _player.SetCurrentState(PlayerController.States.Moving);
                    _player.MoveToPosition(_player.PFC.GetTargetNode().transform.position);
                    _player.PFC.SetCurrentNode.Invoke(_player.PFC.GetTargetNode());
                    break;
                case PlayerController.Actions.MoveRight:
                    _player.SetCurrentState(PlayerController.States.Moving);
                    _player.MoveToPosition(_player.PFC.GetTargetNode().transform.position);
                    _player.PFC.SetCurrentNode.Invoke(_player.PFC.GetTargetNode());
                    break;
                case PlayerController.Actions.Select:
                    if(_player.Select != null)
                        _player.Select.Invoke();
                    break;
                case PlayerController.Actions.Die:
                    if(_player.Die != null)
                        _player.Die.Invoke();
                    break;
                default:
                    break;
            }
        }
    }

}
