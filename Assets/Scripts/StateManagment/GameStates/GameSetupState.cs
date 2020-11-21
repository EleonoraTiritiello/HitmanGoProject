﻿using UnityEngine;

namespace HitmanGO
{
    public class GameSetupState : StateMachineBehaviour
    {
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
                GameManager.GetInstance.ChangeState(GameManager.States.MainMenu);
        }
    }
}
