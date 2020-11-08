using UnityEngine;

namespace HitmanGO
{
    public class OnCalculatingEnemyActionState : StateMachineBehaviour
    {
        private PlayerController _player;
        private EnemyController[] _enemies;

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (_player == null) _player = GameManager.GetInstance.Player;
            if (_enemies == null) _enemies = LevelManger.GetInstance.Enemies.ToArray();

            CalculateEnemiesActions();

            LevelManger.GetInstance.ChangeState(LevelManger.States.OnPlayerAction);
        }

        #region Private Methods

        private void CalculateEnemiesActions()
        {
            foreach(EnemyController enemy in _enemies)
            {
                CalculateEnemyAction(enemy);
            }
        }

        private void CalculateEnemyAction(EnemyController enemy)
        {
            if(enemy.PFC.GetTargetNode() == _player.PFC.GetTargetNode())
            {
                if (enemy.PFC.GetTargetNode() == enemy.PFC.UpNode)
                    enemy.CurrentAction = EnemyController.Actions.MoveUp;
                else if (enemy.PFC.GetTargetNode() == enemy.PFC.DownNode)
                    enemy.CurrentAction = EnemyController.Actions.MoveDown;
                else if (enemy.PFC.GetTargetNode() == enemy.PFC.LeftNode)
                    enemy.CurrentAction = EnemyController.Actions.MoveLeft;
                else if (enemy.PFC.GetTargetNode() == enemy.PFC.RightNode)
                    enemy.CurrentAction = EnemyController.Actions.MoveRight;
            }

            switch (enemy.CurrentAction)
            {
                case EnemyController.Actions.MoveUp:
                    enemy.PFC.SetTargetNode.Invoke(enemy.PFC.UpNode);
                    if (enemy.PFC.GetTargetNode() == null)
                        enemy.CurrentAction = EnemyController.Actions.None;
                    break;
                case EnemyController.Actions.MoveDown:
                    enemy.PFC.SetTargetNode.Invoke(enemy.PFC.DownNode);
                    if (enemy.PFC.GetTargetNode() == null)
                        enemy.CurrentAction = EnemyController.Actions.None;
                    break;
                case EnemyController.Actions.MoveLeft:
                    enemy.PFC.SetTargetNode.Invoke(enemy.PFC.LeftNode);
                    if (enemy.PFC.GetTargetNode() == null)
                        enemy.CurrentAction = EnemyController.Actions.None;
                    break;
                case EnemyController.Actions.MoveRight:
                    enemy.PFC.SetTargetNode.Invoke(enemy.PFC.RightNode);
                    if (enemy.PFC.GetTargetNode() == null)
                        enemy.CurrentAction = EnemyController.Actions.None;
                    break;
                default:
                    break;
            }
        }

        #endregion
    }

}
