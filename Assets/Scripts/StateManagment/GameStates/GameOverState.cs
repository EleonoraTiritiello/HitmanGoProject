using UnityEngine;
using UnityEngine.SceneManagement;

namespace HitmanGO
{
    public class GameOverState : StateMachineBehaviour
    {
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (Input.GetKeyDown(KeyCode.E))
                LevelManger.GetInstance.ChangeState(LevelManger.States.GameOver);
        }
    }

}
