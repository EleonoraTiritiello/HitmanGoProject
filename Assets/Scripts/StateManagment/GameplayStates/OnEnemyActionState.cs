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
            if(_enemies == null)
            {
                UpdateEnemyArray();
                LevelManger.GetInstance.EnemyListModifyed += UpdateEnemyArray;
            }

            PerformEnemiesActions();

            LevelManger.GetInstance.ChangeState(LevelManger.States.WaitingForInput);
        }

        /// <summary>
        /// Perform the action of all enemies in the level
        /// </summary>
        private void PerformEnemiesActions()
        {
            for(int i = 0; i < _enemies.Length; i++)
            {
                Debug.Log($"{_enemies[i].name} -> {_enemies[i].ToDoAction}");
                PerformEnemyAction(_enemies[i]);
            }

            foreach(EnemyController enemy in _enemies)
            {
                PathFindingManager.GetInstance.ArrangePFCComponents(enemy.PFC.GetCurrentNode());
            }
        }

        /// <summary>
        /// Perform the action of an enemy
        /// </summary>
        /// <param name="enemy"> A given enemy </param>
        private void PerformEnemyAction(EnemyController enemy)
        {
            switch (enemy.ToDoAction)
            {
                case EnemyController.Actions.MoveUp:
                    enemy.SetCurrentState(EnemyController.States.Moving);
                    enemy.MoveToPosition(enemy.PFC.GetTargetNode().transform.position);
                    enemy.PFC.SetCurrentNode.Invoke(enemy.PFC.GetTargetNode());
                    VerifyGameOver(enemy);
                    VerifyTargetReached(enemy);
                    break;
                case EnemyController.Actions.MoveDown:
                    enemy.SetCurrentState(EnemyController.States.Moving);
                    enemy.MoveToPosition(enemy.PFC.GetTargetNode().transform.position);
                    enemy.PFC.SetCurrentNode.Invoke(enemy.PFC.GetTargetNode());
                    VerifyGameOver(enemy);
                    VerifyTargetReached(enemy);
                    break;
                case EnemyController.Actions.MoveLeft:
                    enemy.SetCurrentState(EnemyController.States.Moving);
                    enemy.MoveToPosition(enemy.PFC.GetTargetNode().transform.position);
                    enemy.PFC.SetCurrentNode.Invoke(enemy.PFC.GetTargetNode());
                    VerifyGameOver(enemy);
                    VerifyTargetReached(enemy);
                    break;
                case EnemyController.Actions.MoveRight:
                    enemy.SetCurrentState(EnemyController.States.Moving);
                    enemy.MoveToPosition(enemy.PFC.GetTargetNode().transform.position);
                    enemy.PFC.SetCurrentNode.Invoke(enemy.PFC.GetTargetNode());
                    VerifyGameOver(enemy);
                    VerifyTargetReached(enemy);
                    break;
                case EnemyController.Actions.FaceUp:
                    enemy.SetCurrentState(EnemyController.States.Idle);
                    enemy.RotateTowards(Vector3.zero);
                    enemy.FacingDirection = EnemyController.FacingDirections.Up;
                    break;
                case EnemyController.Actions.FaceDown:
                    enemy.SetCurrentState(EnemyController.States.Idle);
                    enemy.RotateTowards(Vector3.up * 180f);
                    enemy.FacingDirection = EnemyController.FacingDirections.Down;
                    break;
                case EnemyController.Actions.FaceLeft:
                    enemy.SetCurrentState(EnemyController.States.Idle);
                    enemy.RotateTowards(Vector3.up * 90f);
                    enemy.FacingDirection = EnemyController.FacingDirections.Left;
                    break;
                case EnemyController.Actions.FaceRight:
                    enemy.SetCurrentState(EnemyController.States.Idle);
                    enemy.RotateTowards(Vector3.up * 90f);
                    enemy.FacingDirection = EnemyController.FacingDirections.Right;
                    break;
                case EnemyController.Actions.Die:
                    if(enemy.Die != null)
                        enemy.Die.Invoke();
                    break;
                default:
                    break;
            }
        }

        private void VerifyGameOver(EnemyController enemy)
        {
            if(enemy.PFC.GetTargetNode() == _player.PFC.GetCurrentNode())
            {
                _player.Die.Invoke();
                LevelManger.GetInstance.ChangeState(LevelManger.States.GameOver);
            }
        }

        private void VerifyTargetReached(EnemyController enemy)
        {
            if (enemy.IsAlerted && enemy.PFC.GetCurrentNode() == enemy.TargetNode)
                enemy.DeAlert();
        }

        private void UpdateEnemyArray()
        {
            _enemies = LevelManger.GetInstance.GetEnemiesArray();
        }
    }
}
