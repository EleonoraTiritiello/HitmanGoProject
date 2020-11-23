using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

        [HideInInspector]
        public bool LevelCompleted;

        public Node EndNode;

        public Action EnemyListModifyed;

        public Action CompleteLevel;

        public PathCreator PathCreator;



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
        /// The list of enemies in the level
        /// </summary>
        private List<EnemyController> _enemies;

        /// <summary>
        /// The list of rocks in the level
        /// </summary>
        private List<Rock> _rocks;

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

            if (_enemies == null)
                _enemies = new List<EnemyController>();
            if (_rocks == null)
                _rocks = new List<Rock>();
            if (CompleteLevel == null)
            {
                CompleteLevel = OnLevelCompleted;
            }
        }

        private void Start()
        {
            GameManager.GetInstance.Player.Die += OnLevelFailed;
        }

        #endregion

        #region Methods

        #region Public Methods

        public bool IsRockInList(Rock rock) => _rocks.Contains(rock);

        public void AddRockToList(Rock rock) => _rocks.Add(rock);

        public void RemoveRockFromList(Rock rock) => _rocks.Remove(rock);

        public Rock[] GetRocksArray() => _rocks.ToArray();

        public bool IsEnemyInList(EnemyController enemy) => _enemies.Contains(enemy);

        public void AddEnemyToList(EnemyController enemy)
        {
            _enemies.Add(enemy);

            if (EnemyListModifyed != null)
                EnemyListModifyed.Invoke();
        }

        public void RemoveEnemyFromList(EnemyController enemy)
        {
            _enemies.Remove(enemy);

            if (EnemyListModifyed != null)
                EnemyListModifyed.Invoke();
        }

        public EnemyController[] GetEnemiesArray() => _enemies.ToArray();

        /// <summary>
        /// Change the current Gameplay state
        /// </summary>
        /// <param name="state"> The state you want to put </param>
        public void ChangeState(States state)
        {
            _animator.SetTrigger(_animatorTriggers[state]);
        }

        #endregion

        #region Private Methods

        private void OnLevelFailed()
        {
            ChangeState(States.GameOver);
            Debug.Log("Game Over");
            Invoke("ReloadLevel", 2f);
        }
        private void ReloadLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        private void OnLevelCompleted()
        {
            LevelCompleted = true;
        }

        #endregion

        #endregion
    }

}
