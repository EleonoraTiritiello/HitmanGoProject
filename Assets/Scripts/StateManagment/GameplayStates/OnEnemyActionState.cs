using UnityEngine;

namespace HitmanGO
{
    public class OnEnemyActionState : StateMachineBehaviour
    {
        private PlayerController _player;
        private EnemyController[] _enemies;

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (_player == null) _player = GameManager.GetInstance.Player;
            if (_enemies == null) _enemies = LevelManger.GetInstance.Enemies.ToArray();

            PerformEnemiesActions();

            LevelManger.GetInstance.ChangeState(LevelManger.States.WaitingForInput);
        }

        private void PerformEnemiesActions()
        {
            foreach(EnemyController enemy in _enemies)
            {
                PerformEnemyAction(enemy);
            }
        }

        private void PerformEnemyAction(EnemyController enemy)
        {
            switch (enemy.CurrentAction)
            {
                case EnemyController.Actions.MoveUp:
                    enemy.SetCurrentState(EnemyController.States.Moving);
                    enemy.MoveToPosition(enemy.PFC.GetTargetNode().transform.position, enemy.MovementDuration);
                    enemy.PFC.SetCurrentNode.Invoke(enemy.PFC.GetTargetNode());
                    VerifyGameOver(enemy);
                    break;
                case EnemyController.Actions.MoveDown:
                    enemy.SetCurrentState(EnemyController.States.Moving);
                    enemy.MoveToPosition(enemy.PFC.GetTargetNode().transform.position, enemy.MovementDuration);
                    enemy.PFC.SetCurrentNode.Invoke(enemy.PFC.GetTargetNode());
                    VerifyGameOver(enemy);
                    break;
                case EnemyController.Actions.MoveLeft:
                    enemy.SetCurrentState(EnemyController.States.Moving);
                    enemy.MoveToPosition(enemy.PFC.GetTargetNode().transform.position, enemy.MovementDuration);
                    enemy.PFC.SetCurrentNode.Invoke(enemy.PFC.GetTargetNode());
                    VerifyGameOver(enemy);
                    break;
                case EnemyController.Actions.MoveRight:
                    enemy.SetCurrentState(EnemyController.States.Moving);
                    enemy.MoveToPosition(enemy.PFC.GetTargetNode().transform.position, enemy.MovementDuration);
                    enemy.PFC.SetCurrentNode.Invoke(enemy.PFC.GetTargetNode());
                    VerifyGameOver(enemy);
                    break;
                case EnemyController.Actions.Die:
                    enemy.Die.Invoke();
                    break;
                default:
                    break;
            }
        }

        private void VerifyGameOver(EnemyController enemy)
        {
            if(enemy.PFC.GetCurrentNode() == _player.PFC.GetCurrentNode())
            {
                _player.Die.Invoke();
                LevelManger.GetInstance.ChangeState(LevelManger.States.GameOver);
            }
        }
    }
}
