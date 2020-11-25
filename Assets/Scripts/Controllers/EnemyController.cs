using System;
using System.Collections.Generic;
using UnityEngine;

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

        public Action AlertEvent;

        public Action Rotate;

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
        public bool IsAlerted { get; private set; }

        public States CurrentState { get; private set; }

        [HideInInspector]
        public Node TargetNode { get; private set; }

        #endregion

        #region Private Variables

        [SerializeField]
        private GameObject _alertIcon;

        #endregion

        #endregion

        #region Unity Callbacks

        private void Awake()
        {
            if (PFC == null) PFC = GetComponent<PathFindingComponent>();

            if (Die == null) Die += OnDie;

            if (PFC.AdjustPosition == null) PFC.AdjustPosition = MoveToPosition;

            IsAlerted = false;

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

        public void Alert(Node targetNode)
        {
            TargetNode = targetNode;
            IsAlerted = true;
            _alertIcon.SetActive(true);

            Debug.LogWarning($"Enemy {name} alerted!");

            AudioManager.Instance.PlaySound("InterrogativeSound");

        }

        public void DeAlert()
        {
            TargetNode = null;
            IsAlerted = false;
            _alertIcon.SetActive(false);
        }

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
            AudioManager.Instance.PlaySound("EnemyRotation");

            if (PFC.GetTargetNode() == null)
                Debug.LogError($"The enemy '{name}' does not look in any direction");
        }

        #endregion
    }
}
