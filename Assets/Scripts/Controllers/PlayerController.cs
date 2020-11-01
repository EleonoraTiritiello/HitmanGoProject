using System.Collections;
using UnityEngine;
using System;
using DG.Tweening;

namespace HitmanGO
{
    public class PlayerController : CharacterController
    {
        #region Variables

        #region Public Variables

        public enum PlayerState {setupState, waitingState, movingState, attackingState}

        public PlayerState currentState;

        public GameObject PlayerPrefab;

        public Action Select;

        #endregion

        #region Private Variables 

        [SerializeField]
        private Transform _diePosition;

        [Header("Input")]
        [SerializeField]
        private KeyCode _moveUpKey;
        [SerializeField]
        private KeyCode _moveDownKey;
        [SerializeField]
        private KeyCode _moveLeftKey;
        [SerializeField]
        private KeyCode _moveRightKey;
        [SerializeField]
        private KeyCode _selectKey;
        [SerializeField]
        private KeyCode _dieKey;

        [Header("Stats")]
        [SerializeField]
        private float _movementSpeed;
        [SerializeField]
        private float _translationMultiplier;

        [Header("Animations")]
        [SerializeField]
        private Vector3 _movementAnimationVector;
        [SerializeField]
        private float _movementAnimationSpeed;
        [SerializeField]
        private Vector3 _dieAnimationVector;
        [SerializeField]
        private float _dieAnimationSpeed;

        private bool _selected;
        private bool _isMoving;

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
            if (!_isMoving )
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

        #endregion

        #region Methods

        #region Die

        public override void OnDie()
        {
            PlayDieAnimation();
        }

        private void PlayDieAnimation()
        {
            transform.DOMove(transform.up * 50, _dieAnimationSpeed);
            StartCoroutine("GoDiePosition");
            transform.DOPunchRotation(_dieAnimationVector, _dieAnimationSpeed);
            
        }

        #endregion

        #region Movement 

        private void MoveUp()
        {
            _isMoving = true;
            MoveToPosition(transform.position + Vector3.forward * _translationMultiplier, _movementSpeed);
            StartCoroutine("PlayMovementAnimation");
        }

        private void MoveDown()
        {
            _isMoving = true;
            MoveToPosition(transform.position + Vector3.back * _translationMultiplier, _movementSpeed);
            StartCoroutine("PlayMovementAnimation");
        }

        private void MoveLeft()
        {
            _isMoving = true;
            MoveToPosition(transform.position + Vector3.left * _translationMultiplier, _movementSpeed);
            StartCoroutine("PlayMovementAnimation");
        }

        private void MoveRight()
        {
            _isMoving = true;
            MoveToPosition(transform.position + Vector3.right * _translationMultiplier, _movementSpeed);
            StartCoroutine("PlayMovementAnimation2");
        }

        #region MovementAnimation

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

        private IEnumerator GoDiePosition()
        {
            yield return new WaitForSeconds(_dieAnimationSpeed + 0.5f);
            transform.DOMove(_dieAnimationVector, _dieAnimationSpeed);
        }

        #endregion


        #endregion

        #region Selection

        private void OnSelected()
        {
            StopCoroutine("OnCharacterSelectedAnimation");
            StartCoroutine("OnCharacterSelectedAnimation");
            _selected = true;
        
        }

        private IEnumerator OnCharacterSelectedAnimation()
        {
            transform.DOMoveY(transform.position.y + 0.3f, 0.2f);
            yield return new WaitForSeconds(0.1f);
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