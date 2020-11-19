using UnityEngine;
using System.Collections.Generic;
using System.Collections;

namespace HitmanGO
{
    /// <summary>
    /// Class <c> EnemyController contains the methods for player movement and its animations, inherits from CharacterController </c>
    /// </summary>
    public class EnemyController : CharacterController
    {
        #region Variables

        #region Public Variables

        public enum FacingDirections { Up, Down, Left, Right }

        public FacingDirections FacingDirection = FacingDirections.Up;

        public enum Actions
        {
            None,
            FaceUp,
            FaceDown,
            FaceLeft,
            FaceRight,
            MoveUp,
            MoveDown,
            MoveLeft,
            MoveRight,
            Die,
        }

        [HideInInspector]
        public Actions ToDoAction = Actions.None;

        public Stack<Actions> ToDoActions = new Stack<Actions>();

        public enum States { Setup, Idle, Moving }
        public bool IsAlerted = false;

        public States CurrentState { get; private set; }

        #endregion

        #endregion

        #region Unity Callbacks

        private void Awake()
        {
            if (PFC == null) PFC = GetComponent<PathFindingComponent>();

            if (Die == null) Die += OnDie;          

            if (PFC.AdjustPosition == null) PFC.AdjustPosition = MoveToPosition;

            if (!LevelManger.GetInstance.IsEnemyInList(this))
                LevelManger.GetInstance.AddEnemyToList(this);     
        }

        private void Start()
        {
            SetCurrentState(States.Idle);

            SetupFacingDirection();
        }

        private void OnDestroy()
        {
            if (LevelManger.GetInstance.IsEnemyInList(this))
                LevelManger.GetInstance.RemoveEnemyFromList(this);

            if (Die != null) Die = null;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Set the current state
        /// </summary>
        /// <param name="state"> The state you want to set </param>
        public void SetCurrentState(States state) => CurrentState = state;

        #endregion

        #region Private Methods

        private void SetupFacingDirection()
        {
            switch (FacingDirection)
            {
                case FacingDirections.Up:
                    if (PFC.UpNode != null)
                    {
                        PFC.SetTargetNode.Invoke(PFC.UpNode);
                        transform.rotation = Quaternion.Euler(Vector3.zero);
                    }
                    break;
                case FacingDirections.Down:
                    if (PFC.DownNode != null)
                    {
                        PFC.SetTargetNode.Invoke(PFC.DownNode);
                        transform.rotation = Quaternion.Euler(Vector3.up * 180f);
                    }
                    break;
                case FacingDirections.Left:
                    if (PFC.LeftNode != null)
                    {
                        PFC.SetTargetNode.Invoke(PFC.LeftNode);
                        transform.rotation = Quaternion.Euler(Vector3.up * -90f);
                    }
                    break;
                case FacingDirections.Right:
                    if (PFC.RightNode != null)
                    {
                        PFC.SetTargetNode.Invoke(PFC.RightNode);
                        transform.rotation = Quaternion.Euler(Vector3.up * 90f);
                    }
                    break;
                default:
                    break;
            }

            if (PFC.GetTargetNode() == null)
                Debug.LogError($"The enemy '{name}' does not look in any direction");
        }

        #endregion
    }
}
