using System.Collections.Generic;
using UnityEngine;

namespace HitmanGO
{
    /// <summary>
    /// Class <c> GameManager </c> Manages the Game manager
    /// </summary>
    public class GameManager : Singleton<GameManager>
    {

        #region Variables

        #region Public Variables
        /// <summary>
        /// GameManager State
        /// </summary>
        public enum State
        {
            Gameplay
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
        private readonly Dictionary<State, string> _animatorTriggers = new Dictionary<State, string>
        {
            {State.Gameplay, "GoToGameplay"}
        };

        #endregion

        #endregion

        #region Unity Callbacks

        public void Awake()
        {
            if(_animator == null)
            {
                _animator = GetComponent<Animator>();
            }
            
        }
        private void Update()
        {
            VictoryCondition();
            LoseCondition();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Change the current GameManager state
        /// </summary>
        /// <param name="state"> The state you want to put </param>
        public void ChangeState(State state)
        {
            _animator.SetTrigger(_animatorTriggers[state]);
        }


        /// <summary>
        /// Victory condition
        /// </summary>
        public void VictoryCondition()
        {

        }

        /// <summary>
        /// Lose condition
        /// </summary>
        public void LoseCondition()
        {

        }
        #endregion
    }


}
