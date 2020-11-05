using System.Collections;
using UnityEngine;
using System;
using DG.Tweening;

namespace HitmanGO
{
    /// <summary>
    /// Class <c> PlayerController contains the methods for player movement and its animations, inherits from CharacterController </c> 
    /// </summary>

    public class PlayerController : CharacterController
    {
        #region Variables

        #region Public Variables

        public enum PlayerState {setupState, waitingState, movingState, rockState, attackingState, endState}

        public PlayerState currentState;

        public GameObject PlayerPrefab;

        public Action Select;

        #endregion

        #region Private Variables 
        /// <summary>
        /// Movement to the death position
        /// </summary>
        
        [SerializeField]
        private Transform _dieMovement;

        /// <summary>
        /// Keycode for forward movement
        /// </summary>
        [Header("Input")]
        [SerializeField]
        private KeyCode _moveUpKey;
        /// <summary>
        /// <c> Keycode </c> for backward movement
        /// </summary>
        [SerializeField]
        private KeyCode _moveDownKey;
        /// <summary>
        /// <c> Keycode </c> for left movement
        /// </summary>
        [SerializeField]
        private KeyCode _moveLeftKey;
        /// <summary>
        /// <c> Keycode </c> for right movement
        /// </summary>
        [SerializeField]
        private KeyCode _moveRightKey;
        /// <summary>
        /// <c> Keycode </c> for selection 
        /// </summary>
        [SerializeField]
        private KeyCode _selectKey;
        /// <summary>
        /// <c> Keycode </c> for die
        /// </summary>
        [SerializeField]
        private KeyCode _dieKey;

        /// <summary>
        /// Variable for movement speed
        /// </summary>
        [Header("Stats")]
        [SerializeField]
        private float _movementSpeed;
        /// <summary>
        /// Variable for chanchng distance move
        /// </summary>
        [SerializeField]
        private float _translationMultiplier;
        
        /// <summary>
        /// Vector3 for changing vibration
        /// </summary>
        [Header("Animations")]
        [SerializeField]
        private Vector3 _movementAnimationVector;
        /// <summary>
        /// Variable to determine the animation speed
        /// </summary>
        [SerializeField]
        private float _movementAnimationSpeed;
        /// <summary>
        /// Vector3 for changing vibration when the player is dying
        /// </summary>
        [SerializeField]
        private Vector3 _dieAnimationVector;
        /// <summary>
        /// Variable to determine the animation speed when the player is dying
        /// </summary>
        [SerializeField]
        private float _dieAnimationSpeed;
        /// <summary>
        /// Bool to represent if the player is moving
        /// </summary>
        private bool _selected;
        /// <summary>
        /// Bool to represent if the player can move
        /// </summary>
        public bool _isMoving;

        #endregion

        #endregion

        #region Unity Callbacks

        void Start()
        {
            setCurrentState(PlayerState.setupState);
        }


        private void Awake()
        {
            if(Select == null) Select = OnSelected;
            if (Die == null) Die = OnDie;
        }

        void Update()
        {
            UpdateMove();
        }

        #endregion

        #region Methods

        #region Movement 

        /// <summary>
        /// Check if the player can move and in case of input it moves
        /// </summary>

        private void UpdateMove()
        {
            if (!_isMoving)
            {
                if (!_selected)
                {
                    if (Input.GetKeyDown(_selectKey))
                        Select.Invoke();
                }
                else
                {
                    if (Input.GetKeyDown(_moveUpKey)) MoveUp();
                    else if (Input.GetKeyDown(_moveDownKey)) MoveDown();
                    else if (Input.GetKeyDown(_moveLeftKey)) MoveLeft();
                    else if (Input.GetKeyDown(_moveRightKey)) MoveRight();
                }
            }
            if (Input.GetKeyDown(_dieKey))
                Die.Invoke();
        }
        /// <summary>
        /// Forward movement for the player 
        /// </summary>
        private void MoveUp()
        {
            _isMoving = true;
            MoveToPosition(transform.position + Vector3.forward * _translationMultiplier, _movementSpeed);
            StartCoroutine("PlayMovementAnimation2");
        }

        /// <summary>
        /// Backward movement for the player 
        /// </summary>
        private void MoveDown()
        {
            _isMoving = true;
            MoveToPosition(transform.position + Vector3.back * _translationMultiplier, _movementSpeed);
            StartCoroutine("PlayMovementAnimation");
        }

        /// <summary>
        /// Left movement for the player 
        /// </summary>
        private void MoveLeft()
        {
            _isMoving = true;
            MoveToPosition(transform.position + Vector3.left * _translationMultiplier, _movementSpeed);
            StartCoroutine("PlayMovementAnimation");
        }

        /// <summary>
        /// right movement for the player 
        /// </summary>
        private void MoveRight()
        {
            _isMoving = true;
            MoveToPosition(transform.position + Vector3.right * _translationMultiplier, _movementSpeed);
            StartCoroutine("PlayMovementAnimation2");
        }

        #region MovementAnimation

        /// <summary>
        /// Player animation when is moving backward & left
        /// </summary>
        /// <returns> return <c> IEnumerator </c> </returns>
        private IEnumerator PlayMovementAnimation()
        {
            Sequence sequence = DOTween.Sequence();
       
            sequence.Append(transform.DORotate(new Vector3(0, transform.rotation.eulerAngles.y + 10, 0), 0.1f));
            sequence.Append(transform.DOShakeRotation(0.8f,strength: 5 ,vibrato: 6 ,randomness: 70));
            sequence.Append(transform.DORotate(new Vector3(0, transform.rotation.eulerAngles.y - 0, 0), 0.15f));
            yield return new WaitForSeconds(_movementAnimationSpeed);
            _isMoving = false;
            _selected = false;
        }

        /// <summary>
        /// Player animation when is moving forward & right
        /// </summary>
        /// <returns> return <c> IEnumerator </c> </returns>
        //rinominare metodo e farne uno solo
        private IEnumerator PlayMovementAnimation2()
        {
            Sequence sequence = DOTween.Sequence();

            sequence.Append(transform.DORotate(new Vector3(0, transform.rotation.eulerAngles.y - 10, 0), 0.1f));
            sequence.Append(transform.DOShakeRotation(0.8f, strength: 5, vibrato: 6, randomness: 70));
            sequence.Append(transform.DORotate(new Vector3(0, transform.rotation.eulerAngles.y + 0, 0), 0.15f));
            yield return new WaitForSeconds(_movementAnimationSpeed);
            _isMoving = false;
            _selected = false;
        }

        #region Die

        /// <summary>
        /// Callback 
        /// </summary>
        public override void OnDie()
        {
            PlayDieAnimation();
        }

        /// <summary>
        /// Movement and animation to the death position
        /// </summary>
        private void PlayDieAnimation()
        {
            Sequence sequence = DOTween.Sequence();

            sequence.Append(transform.DOPunchRotation(_dieAnimationVector, 0.4f));
            sequence.Append(transform.DORotate(new Vector3(transform.rotation.eulerAngles.x + 90, 0, 0), _dieAnimationSpeed - 0.5f));
        }

        #endregion

        #endregion


        #endregion

        #region Selection

        /// <summary>
        /// Start Coroutine character selection animation
        /// </summary>
        private void OnSelected()
        {
            StopCoroutine("OnCharacterSelectedAnimation");
            StartCoroutine("OnCharacterSelectedAnimation");
            _selected = true;
        
        }

        /// <summary>
        /// Do character selection animation when player it's selected
        /// </summary>
        private IEnumerator OnCharacterSelectedAnimation()
        {
            transform.DOMoveY(transform.position.y + 0.3f, 0.2f);
            yield return new WaitForSeconds(0.2f);
            transform.DOMoveY(transform.position.y - 0.3f, 0.1f);
            yield return new WaitForEndOfFrame();
        }

        #endregion

        #region SetCurrentState

        void setCurrentState(PlayerState state)
        {
            currentState = state;
        }

        #endregion

        #endregion

    }
}