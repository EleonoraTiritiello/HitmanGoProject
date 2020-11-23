using UnityEngine;
using UnityEngine.SceneManagement;

namespace HitmanGO
{
    public class LevelChanger : MonoBehaviour
    {
        public Animator animator;

        private int levelToLoad;
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.O))
                FadeToNextLevel();
        }

        public void FadeToNextLevel()
        {
            FadeToLevel(SceneManager.GetActiveScene().buildIndex + 1);
            GameManager.GetInstance.ChangeState(GameManager.States.BoxSelectMenu);
        }
        public void FadeToPreviousLevel()
        {
            FadeToLevel(SceneManager.GetActiveScene().buildIndex - 1);
        }

        public void FadeToLevel(int levelIndex)
        {
            levelToLoad = levelIndex;
            animator.SetTrigger("Fade_Out");
        }

        public void OnFadeComplete()
        {
            SceneManager.LoadScene(levelToLoad);
        }
    }
}
