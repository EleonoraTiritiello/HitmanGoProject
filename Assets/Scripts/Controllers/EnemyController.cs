using System.Collections;
using UnityEngine;
using DG.Tweening;

namespace HitmanGO
{
    /// <summary>
    /// Class <c> EnemyController contains the methods for player movement and its animations, inherits from CharacterController </c>
    /// </summary>
    public class EnemyController : CharacterController
    {
        #region Variables

        #region Public Variables

        public enum Actions
        {
            None,
            MoveUp,
            MoveDown,
            MoveLeft,
            MoveRight,
            Die,
        }

        [HideInInspector]
        public Actions CurrentAction = Actions.None;

        public enum States { Setup, Idle, Moving }

        public States CurrentState { get; private set; }

        #endregion

        #region Private Variables

        [SerializeField]
        private Directions _facing = default;

        #endregion

        #endregion

        #region Unity Callbacks

        private void Awake()
        {
            if (PFC == null) PFC = GetComponent<PathFindingComponent>();

            if (!LevelManger.GetInstance.Enemies.Contains(this))
                LevelManger.GetInstance.Enemies.Add(this);
        }

        private void Start()
        {
            SetCurrentState(States.Idle);

            if (_facing.Up && PFC.UpNode != null)
                PFC.SetTargetNode.Invoke(PFC.UpNode);
            else if (_facing.Down && PFC.DownNode != null)
                PFC.SetTargetNode.Invoke(PFC.DownNode);
            else if (_facing.Left && PFC.LeftNode != null)
                PFC.SetTargetNode.Invoke(PFC.LeftNode);
            else if (_facing.Right && PFC.RightNode != null)
                PFC.SetTargetNode.Invoke(PFC.RightNode);
            else
                Debug.LogError($"The enemy '{name}' does not look in any direction");
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Set the current state
        /// </summary>
        /// <param name="state"> The state you want to set </param>
        public void SetCurrentState(States state) => CurrentState = state;

        #endregion
    }
}
