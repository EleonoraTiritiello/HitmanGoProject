using UnityEngine;
using System.Collections.Generic;

namespace HitmanGO
{
    /// <summary>
    /// Class <c> LevelManager </c> Manages the current level 
    /// </summary>
    [RequireComponent(typeof(Animator))]
    public sealed class LevelManger : Singleton<LevelManger>
    {

        #region Variables

        #region Public Variables 
        /// <summary>
        /// Gameplay states
        /// </summary>
        public enum States
        {
            GameplayIntro,
            WaitingForInput,
            OnCalculatingPlayerAction,
            OnCalculatingEnemyAction,
            OnPlayerAction,
            OnEnemyAction,
            GameOver

        }
        #endregion

        #region Private Variables
        /// <summary>
        /// Component that contains the states of the gameplay
        /// </summary>
        private Animator _animator;

        /// <summary>
        /// Allows access to animator triggers
        /// </summary>
        private readonly Dictionary<States, string> _animatorTriggers = new Dictionary<States, string>()
        {
            {States.GameplayIntro,"GoToGameplayIntro"},
            {States.WaitingForInput, "GoToWaitingForInput"},
            {States.OnCalculatingPlayerAction, "GoToOnCalculatingPlayerAction"},
            {States.OnCalculatingEnemyAction, "GoToOnCalculatingEnemyAction"},
            {States.OnPlayerAction, "GoToOnPlayerAction"},
            {States.OnEnemyAction, "GoToOnEnemyAction"},
            {States.GameOver, "GoToGameOver"}
              
        };
        #endregion

        #endregion

        #region Unity Callbacks
        private void Awake()
        {
            if (_animator == null)
                _animator = GetComponent<Animator>();

        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Change the current Gameplay state
        /// </summary>
        /// <param name="state"> The state you want to put </param>
        public void ChangeState(States state)
        {
            _animator.SetTrigger(_animatorTriggers[state]);

        }
        #endregion

    }

}


