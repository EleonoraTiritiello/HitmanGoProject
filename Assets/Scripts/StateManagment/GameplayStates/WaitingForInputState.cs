using UnityEngine;

namespace HitmanGO
{
    public class WaitingForInputState : StateMachineBehaviour
    {
        private InputManager _inputManager;
        private PlayerController _player;
        private Swipe _swipeControl;

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (_inputManager == null) _inputManager = InputManager.GetInstance;
            if (_player == null) _player = GameManager.GetInstance.Player;
            if (_swipeControl == null) _swipeControl = GameObject.FindObjectOfType<Swipe>();
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (_player.CurrentState == PlayerController.States.Idle)
            {
                if (Input.GetKeyDown(_inputManager.SelectPlayerKey) || _swipeControl.tap == true)
                    SetPlayerAction(PlayerController.Actions.Select);

                if (Input.GetKeyDown(_inputManager.DieKey))
                    SetPlayerAction(PlayerController.Actions.Die);
            }
            else if (_player.CurrentState == PlayerController.States.Selected)
            {
                if (Input.GetKeyDown(_inputManager.MoveUpKey) || _swipeControl.swipeUp)
                    SetPlayerAction(PlayerController.Actions.MoveUp);
                else if (Input.GetKeyDown(_inputManager.MoveDownKey) || _swipeControl.swipeDown)
                    SetPlayerAction(PlayerController.Actions.MoveDown);
                else if (Input.GetKeyDown(_inputManager.MoveLeftKey) || _swipeControl.swipeLeft)
                    SetPlayerAction(PlayerController.Actions.MoveLeft);
                else if (Input.GetKeyDown(_inputManager.MoveRightKey) || _swipeControl.swipeRight)
                    SetPlayerAction(PlayerController.Actions.MoveRight);
            }
        }

        private void SetPlayerAction(PlayerController.Actions action)
        {
            _player.CurrentAction = action;
            LevelManger.GetInstance.ChangeState(LevelManger.States.OnCalculatingPlayerAction);
        }
    }
}
