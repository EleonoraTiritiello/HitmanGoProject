using UnityEngine;
using UnityEngine.SceneManagement;

namespace HitmanGO
{
    public class GameSetupState : StateMachineBehaviour
    {
        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(1);
                GameManager.GetInstance.ChangeState(GameManager.States.Gameplay);
            }
        }
    }
}
