using UnityEngine;
using System.Collections.Generic;

namespace HitmanGO
{
    [RequireComponent(typeof(Animator))]
    public sealed class LevelManger : Singleton<LevelManger>
    {
        private Animator _animator;
       
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

        private readonly Dictionary<States, string> _animatorTriggers = new Dictionary<States, string>()
        {
            {States.GameplayIntro,"GoToGameplayIntro"},
            {States.WaitingForInput, "GoToWaitingForInput"},
            {States.OnCalculatingPlayerAction, "GoToOnCalculatingPlayerAction"},
            {States.OnCalculatingEnemyAction, "GoToCalculatingEnemyAction"},
            {States.OnPlayerAction, "GoToPlayerAction"},
            {States.OnEnemyAction, "GoToEnemyAction"},
            {States.GameOver, "GoToGameOver"}
              
        };


        private void Awake()
        {
            if (_animator == null)
                _animator = GetComponent<Animator>();


        }

        public void ChangeState(States state)
        {
            _animator.SetTrigger(_animatorTriggers[state]);

        }

    }

}


