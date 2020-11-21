using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace HitmanGO
{
    public class BoxSelectMenu : MonoBehaviour
    {
        public void OnLevelButtonClicked(int levelIndex)
        {

            GameManager.GetInstance.ChangeState(GameManager.States.Gameplay);

            SceneManager.LoadScene(levelIndex + 2);
        }

        public void OnResetButtonClicked(int levelIndex)
        {

            GameManager.GetInstance.ChangeState(GameManager.States.MainMenu);

            SceneManager.LoadScene(levelIndex + 0);
        }
    }
}
