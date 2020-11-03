using UnityEngine;

namespace HitmanGO
{
    public class OnCalculatingEnemyActionState : StateMachineBehaviour
    {
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {

        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (Input.GetKeyDown(KeyCode.Space))
                LevelManger.GetInstance.ChangeState(LevelManger.States.OnPlayerAction);
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {

        }
    }

}
