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
            }
        }

        private void CalculateEnemyAction(EnemyController enemy)
        {
            if (enemy.PFC.GetTargetNode() == _player.PFC.GetTargetNode())
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
            else
            {
                if (enemy.CurrentAction != EnemyController.Actions.Die)
                {
                    if (_player.CurrentAction == PlayerController.Actions.Select)
                    {
                        if (enemy.FacingDirection == EnemyController.FacingDirections.Up)
                            enemy.CurrentAction = EnemyController.Actions.FaceRight;
                        else if (enemy.FacingDirection == EnemyController.FacingDirections.Right)
                            enemy.CurrentAction = EnemyController.Actions.FaceDown;
                        else if (enemy.FacingDirection == EnemyController.FacingDirections.Down)
                            enemy.CurrentAction = EnemyController.Actions.FaceLeft;
                        else if (enemy.FacingDirection == EnemyController.FacingDirections.Left)
                            enemy.CurrentAction = EnemyController.Actions.FaceUp;
                        else
                            Debug.LogError($"Il nemico '{enemy.name}' non sta guardando in nessuna direzione (?) LOL");
                    }
                }
            }

            switch (enemy.CurrentAction)
            {
                case EnemyController.Actions.MoveUp:
                    if (enemy.PFC.UpNode == null)
                        enemy.CurrentAction = EnemyController.Actions.None;
                    else
                        enemy.PFC.SetTargetNode(enemy.PFC.UpNode);
                    break;
                case EnemyController.Actions.MoveDown:
                    if (enemy.PFC.DownNode == null)
                        enemy.CurrentAction = EnemyController.Actions.None;
                    else
                        enemy.PFC.SetTargetNode(enemy.PFC.DownNode);
                    break;
                case EnemyController.Actions.MoveLeft:
                    if (enemy.PFC.LeftNode == null)
                        enemy.CurrentAction = EnemyController.Actions.None;
                    else
                        enemy.PFC.SetTargetNode(enemy.PFC.LeftNode);
                    break;
                case EnemyController.Actions.MoveRight:
                    if (enemy.PFC.RightNode == null)
                        enemy.CurrentAction = EnemyController.Actions.None;
                    else
                        enemy.PFC.SetTargetNode(enemy.PFC.RightNode);
                    break;
                case EnemyController.Actions.FaceUp:
                    if (enemy.PFC.UpNode == null)
                        enemy.CurrentAction = EnemyController.Actions.None;
                    break;
                case EnemyController.Actions.FaceDown:
                    if (enemy.PFC.DownNode == null)
                        enemy.CurrentAction = EnemyController.Actions.None;
                    break;
                case EnemyController.Actions.FaceLeft:
                    if (enemy.PFC.LeftNode == null)
                        enemy.CurrentAction = EnemyController.Actions.None;
                    break;
                case EnemyController.Actions.FaceRight:
                    if (enemy.PFC.RightNode == null)
                        enemy.CurrentAction = EnemyController.Actions.None;
                    break;
                case EnemyController.Actions.Die:
                    if(enemy.Die != null)
                        enemy.Die.Invoke();
                    break;
                default:
                    break;
            }
        }

        private void UpdateEnemyArray()
        {
            _enemies = LevelManger.GetInstance.GetEnemiesArray();
        }

        #endregion
    }

}
