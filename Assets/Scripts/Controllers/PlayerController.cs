﻿using System.Collections;
using UnityEngine;
using System;
using DG.Tweening;

namespace HitmanGO
{
    [RequireComponent(typeof(PathFindingComponent))]
    /// <summary>
    /// Class <c> PlayerController </c> contains the methods for player movement and its animations, inherits from <c> CharacterController </c>
    /// </summary>
    public class PlayerController : CharacterController
    {
        #region Variables

        #region Public Variables

        /// <summary>
        /// The reference to the <c> PathFindingComponent </c>
        /// </summary>
        public PathFindingComponent PFC { get; private set; }

        /// <summary>
        /// The duration of the movement
        /// </summary>
        public readonly float MovementDuration = 0.5f;

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
            Die,
        }

        /// <summary>
        /// The action that the Player must perform in the current cycle
        /// </summary>
        [HideInInspector]
        public Actions CurrentAction = Actions.None;

        /// <summary>
        /// The states that the Player can have
        /// </summary>
        public enum States {SetupState, Idle, Selected, Moving}

        /// <summary>
        /// The current state of the Player
        /// </summary>
        [HideInInspector]
        public States CurrentState = States.SetupState;

        #region Events

        public Action Select;

        #endregion

        #endregion

        #region Private Variables 

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
            if (Select == null) Select = OnSelected;
            if (Die == null) Die = OnDie;

            if (PFC == null) PFC = GetComponent<PathFindingComponent>();

            if (GameManager.GetInstance.Player != this) GameManager.GetInstance.Player = this;
        }

        void Start()
        {
            SetCurrentState(States.Idle);
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Moves the Player to a given position while simultaneously executing an animation
        /// </summary>
        /// <param name="targetPosition"> The position that the Player must reach </param>
        /// <param name="movementDuration"> The duration of the movement </param>
        public override void MoveToPosition(Vector3 targetPosition, float movementDuration)
        {
            base.MoveToPosition(targetPosition, movementDuration);
            StartCoroutine(PlayMovementAnimation(targetPosition));
        }

        /// <summary>
        /// Set the current state
        /// </summary>
        /// <param name="state"> The state you want to set </param>
        public void SetCurrentState(States state)
        {
            CurrentState = state;
        }

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

            if(targetPosition.z > transform.position.z || targetPosition.x > transform.position.x)
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