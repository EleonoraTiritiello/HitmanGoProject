using UnityEngine;
using System.Collections.Generic;
using System.Collections;
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

        public enum FacingDirections { Up, Down, Left, Right, No }

        public FacingDirections FacingDirection = FacingDirections.Up;

        public GameObject DiePosition;

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
        [SerializeField]
        private Vector3 _dieAnimationVector;

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

        public override void OnDie()
        {
            FacingDirection = FacingDirections.No;
            transform.DOMove(transform.up * 50, 1.3f);
            base.OnDie();
            //StartCoroutine("Caca");
            //transform.DOPunchRotation(_dieAnimationVector, 1);

        }
        /*
        public IEnumerator Caca()
        {
            yield return new WaitForSeconds(0.5f);
            gameObject.transform.DOScale(new Vector3(0.000001f, 0.000001f, 0.000001f), 0.1f);
            transform.DOMove(transform.up * 50, 1);
            yield return new WaitForSeconds(1 + 0.5f);
            gameObject.transform.DOScale(new Vector3(1f, 1f, 1f), 0.1f);
            transform.DOMove(_dieAnimationVector, 1);
            //yield return new WaitForSeconds(1);
            //GetComponent<Animator>().enabled = false;
            //transform.DOMove(DiePosition.transform.position, 1);

        }
        */

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
                case FacingDirections.No:
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
