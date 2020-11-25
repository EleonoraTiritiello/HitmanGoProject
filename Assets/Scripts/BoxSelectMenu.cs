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

            AudioManager.Instance.PlaySound("SelectedButton");
        }

        public void OnResetButtonClicked(int levelIndex)
        {

            GameManager.GetInstance.ChangeState(GameManager.States.MainMenu);

            SceneManager.LoadScene(levelIndex + 0);

            AudioManager.Instance.PlaySound("SelectedButton");
        }
    }
}
