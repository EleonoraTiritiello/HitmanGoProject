using System;
using UnityEngine;

namespace HitmanGO
{
    public class GameplayState : StateMachineBehaviour
    {
        private LevelManger _levelManager;

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (_levelManager == null)
            {

                try
                {
                   Instantiate(Resources.Load<GameObject>("Prefabs/Level Manager"));
                }
                catch (Exception e)
                {
                    
                    Debug.LogError($"Impossibile instanziare il Level Manager\n{e.Message}");

                }
            }
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {

        }
    }
}
