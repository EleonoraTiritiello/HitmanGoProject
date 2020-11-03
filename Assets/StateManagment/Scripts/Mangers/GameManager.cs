using System.Collections.Generic;
using UnityEngine;

namespace HitmanGO
{
    public class GameManager : Singleton<GameManager>
    {

        #region Public Variables

        #endregion

        #region Private Variables 

        private Animator _animator;

        #endregion

        public enum State
        {
            Gameplay
        }

        private readonly Dictionary<State, string> _animatorTriggers = new Dictionary<State, string>
        {
            {State.Gameplay, "GoToGameplay"}
        };


        public void ChangeState(State state)
        {
            _animator.SetTrigger(_animatorTriggers[state]);
        }

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

        public void VictoryCondition()
        {

        }

        public void LoseCondition()
        {

        }
    }


}
