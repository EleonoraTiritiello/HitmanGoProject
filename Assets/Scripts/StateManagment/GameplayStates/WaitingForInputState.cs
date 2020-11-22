﻿using UnityEngine;

namespace HitmanGO
{
    public class WaitingForInputState : StateMachineBehaviour
    {
        private InputManager _inputManager;
        private PlayerController _player;


        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (_inputManager == null) _inputManager = InputManager.GetInstance;
            if (_player == null) _player = GameManager.GetInstance.Player;


            Debug.Log("Waiting for input");

            if (_player.CurrentState == PlayerController.States.Idle)
            {
                foreach (Rock rock in LevelManger.GetInstance.GetRocksArray())
                {
                    if (_player.PFC.GetCurrentNode() == rock.PFC.GetCurrentNode())
                        SetPlayerAction(PlayerController.Actions.PickupRock);
                }
            }
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (_player.CurrentState == PlayerController.States.Idle)
            {
                if (Input.GetKeyDown(_inputManager.SelectPlayerKey)) {
                    if (_player.ToDoAction != PlayerController.Actions.PickupRock)
                        SetPlayerAction(PlayerController.Actions.Select);
                }
            }
            else if (_player.CurrentState == PlayerController.States.Selected)
            {
                if (Input.GetKeyDown(_inputManager.MoveUpKey))
                    SetPlayerAction(PlayerController.Actions.MoveUp);
                else if (Input.GetKeyDown(_inputManager.MoveDownKey))
                    SetPlayerAction(PlayerController.Actions.MoveDown);
                else if (Input.GetKeyDown(_inputManager.MoveLeftKey))
                    SetPlayerAction(PlayerController.Actions.MoveLeft);
                else if (Input.GetKeyDown(_inputManager.MoveRightKey))
                    SetPlayerAction(PlayerController.Actions.MoveRight);
            }
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            Debug.Log($"Player TODO -> {_player.ToDoAction}");
        }

        /// <summary>
        /// Set the action to be performed by the player
        /// </summary>
        /// <param name="action"> The action that needs to be performed </param>
        private void SetPlayerAction(PlayerController.Actions action)
        {
            _player.ToDoAction = action;
            LevelManger.GetInstance.ChangeState(LevelManger.States.OnCalculatingPlayerAction);
        }
    }
}
