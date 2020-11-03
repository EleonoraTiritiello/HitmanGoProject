using UnityEngine;

namespace HitmanGO
{
    public class OnEnemyActionState : StateMachineBehaviour
    {
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {

        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (Input.GetKeyDown(KeyCode.Space))
                LevelManger.GetInstance.ChangeState(LevelManger.States.WaitingForInput);

            else if (Input.GetKeyDown(KeyCode.Q))
                LevelManger.GetInstance.ChangeState(LevelManger.States.GameOver);
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {

        }
    }

}
