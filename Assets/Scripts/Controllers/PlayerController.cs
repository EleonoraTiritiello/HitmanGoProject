using DG.Tweening;
using System;
using System.Collections;
using UnityEngine;

namespace HitmanGO
{
    /// <summary>
    /// Class <c> PlayerController </c> contains the methods for player movement and its animations, inherits from <c> CharacterController </c>
    /// </summary>
    [RequireComponent(typeof(MeshFilter))]
    public class PlayerController : CharacterController
    {
        #region Variables

        #region Public Variables

        [HideInInspector]
        public GameObject ThrowPositionUp;
        [HideInInspector]
        public GameObject ThrowPositionDown;
        [HideInInspector]
        public GameObject ThrowPositionLeft;
        [HideInInspector]
        public GameObject ThrowPositionRight;

        public Action Move;
        public Action PickUpRock;
        public Action ThrowRockEvent;

        /// <summary>
        /// The actions that the Player can perform
        /// </summary>
        public enum Actions
        {
            None,
            MoveUp,
            MoveDown,
            MoveLeft,
            MoveRight,
            Select,
            PickupRock,
            Die,
        }

        /// <summary>
        /// The action that the Player must perform in the current cycle
        /// </summary>
        [HideInInspector]
        public Actions ToDoAction = Actions.None;

        /// <summary>
        /// The states that the Player can have
        /// </summary>
        public enum States { Setup, Idle, Selected, Moving }

        /// <summary>
        /// The current state of the Player
        /// </summary>
        public States CurrentState { get; private set; }

        [Space(5)]
        #region Events

        public Action Select;

        #endregion

        #endregion

        #region Private Variables 

        private MeshFilter _meshFilter;

        [SerializeField]
        private Mesh _defaultStance;
        [SerializeField]
        private Mesh _rockStance;

        private GameObject _rock;

        #region Selection Animation

        /// <summary>
        /// The height the player reaches when it is selected
        /// </summary>
        [Header("Animations")]
        [SerializeField]
        private float _selectionAnimationHeight = 0.1f;
        /// <summary>
        /// The duration of the selection animation
        /// </summary>
        [SerializeField]
        private float _selectionAnimationDuration = 0.15f;
        /// <summary>
        /// The player switches to the selected state after x seconds for which x is equal to the duration of the animation divided by this value
        /// </summary>
        [SerializeField]
        private float _selectionAnimationCut = 3f;

        #endregion

        #region Movement Animation

        /// <summary>
        /// How much the player rotates when the motion animation runs
        /// </summary>
        [Space(5)]
        [SerializeField]
        private Vector3 _movementAnimationRotationAmount = new Vector3(0, 10, 0);
        /// <summary>
        /// How hard the shaking animation is performed
        /// </summary>
        [SerializeField]
        private float _movementAnimationShakeStrength = 5f;

        #endregion

        #region Death Animation

        /// <summary>
        /// The duration of the death animation
        /// </summary>
        [Space(5)]
        [SerializeField]
        private float _dieAnimationDuration = 1f;
        /// <summary>
        /// Vector3 for changing vibration when the player is dying
        /// </summary>
        [SerializeField]
        private Vector3 _dieAnimationVibrationAmount = Vector3.zero;

        #endregion

        #endregion

        #endregion

        #region Unity Callbacks

        private void Awake()
        {
            if (_meshFilter == null) _meshFilter = transform.GetChild(0).GetComponent<MeshFilter>();

            if (_rock == null) _rock = transform.GetChild(0).GetChild(0).gameObject;

            if (PFC == null) PFC = GetComponent<PathFindingComponent>();

            if (Select == null) Select = OnSelected;
            if (Die == null) Die = OnDie;

            if (GameManager.GetInstance.Player != this) GameManager.GetInstance.Player = this;
        }

        void Start()
        {
            if (_defaultStance == null || _rockStance == null)
                Debug.LogError("Non è stata impostata la mesh del player");

            SetDefaultStance();

            SetCurrentState(States.Idle);
        }

        private void OnDestroy()
        {
            if (Select != null) Select = null;
            if (Die != null) Die = null;
        }

        #endregion

        #region Methods

        #region Public Methods

        public void ThrowRock(RockChecker rockChecker)
        {
            _rock.GetComponent<ThrowableRock>().AddForce(rockChecker);
            SetDefaultStance();
        }

        public void SetDefaultStance()
        {
            _meshFilter.sharedMesh = _defaultStance;
        }

        public void SetRockStance()
        {
            _meshFilter.sharedMesh = _rockStance;
            _rock.SetActive(true);
        }

        /// <summary>
        /// Moves the Player to a given position while simultaneously executing an animation
        /// </summary>
        /// <param name="targetPosition"> The position that the Player must reach </param>
        /// <param name="movementDuration"> The duration of the movement </param>
        public override void MoveToPosition(Vector3 targetPosition)
        {
            base.MoveToPosition(targetPosition);
            StartCoroutine(PlayMovementAnimation(targetPosition));
        }

        /// <summary>
        /// Set the current state
        /// </summary>
        /// <param name="state"> The state you want to set </param>
        public void SetCurrentState(States state) => CurrentState = state;

        /// <summary>
        /// A callback that is called when the player dies
        /// </summary>
        public override void OnDie()
        {
            PlayDieAnimation();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Start Coroutine character selection animation
        /// </summary>
        private void OnSelected()
        {
            StopCoroutine(OnCharacterSelectedAnimation());
            StartCoroutine(OnCharacterSelectedAnimation());
        }

        /// <summary>
        /// Do character selection animation when player it's selected
        /// </summary>
        private IEnumerator OnCharacterSelectedAnimation()
        {
            transform.DOMoveY(transform.position.y + _selectionAnimationHeight, _selectionAnimationDuration / 3f * 2f);
            yield return new WaitForSeconds(_selectionAnimationHeight);
            transform.DOMoveY(transform.position.y - _selectionAnimationHeight, _selectionAnimationDuration / 3f);
            yield return new WaitForSeconds(_selectionAnimationDuration / _selectionAnimationCut);

            SetCurrentState(States.Selected);
        }

        /// <summary>
        /// Player animation when is moving backward & left
        /// </summary>
        /// <returns> return <c> IEnumerator </c> </returns>
        private IEnumerator PlayMovementAnimation(Vector3 targetPosition)
        {
            Sequence sequence = DOTween.Sequence();

            if (targetPosition.z > transform.position.z || targetPosition.x > transform.position.x)
                sequence.Append(transform.DORotate(new Vector3(-_movementAnimationRotationAmount.x, transform.rotation.eulerAngles.y - _movementAnimationRotationAmount.y, -_movementAnimationRotationAmount.z), MovementDuration / 10 * 2));
            else if (targetPosition.z <= transform.position.z || targetPosition.x <= transform.position.x)
                sequence.Append(transform.DORotate(new Vector3(_movementAnimationRotationAmount.x, transform.rotation.eulerAngles.y + _movementAnimationRotationAmount.y, _movementAnimationRotationAmount.z), MovementDuration / 10 * 2));

            sequence.Append(transform.DOShakeRotation(MovementDuration / 10 * 6, strength: _movementAnimationShakeStrength, vibrato: 6, randomness: 70));
            sequence.Append(transform.DORotate(new Vector3(0, transform.rotation.eulerAngles.y, 0), MovementDuration / 10 * 2));

            yield return new WaitForSeconds(MovementDuration);

            SetCurrentState(States.Idle);
        }

        /// <summary>
        /// Animation to the death position
        /// </summary>
        private void PlayDieAnimation()
        {
            Sequence sequence = DOTween.Sequence();

            sequence.Append(transform.DOPunchRotation(_dieAnimationVibrationAmount, _dieAnimationDuration / 2f));
            sequence.Append(transform.DORotate(new Vector3(transform.rotation.eulerAngles.x + 90, 0, 0), _dieAnimationDuration / 2f));
        }

        #endregion

        #endregion
    }
}
