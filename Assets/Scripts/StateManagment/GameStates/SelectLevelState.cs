using UnityEngine;
using UnityEngine.SceneManagement;

namespace HitmanGO 
{ 
    public class SelectLevelState : StateMachineBehaviour
    {
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            SceneManager.LoadScene(2);
            //GameManager.GetInstance.ChangeState(GameManager.States.Gameplay);
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {

        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {

        }
    }

}

