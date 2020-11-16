using UnityEngine;
using UnityEngine.SceneManagement;

namespace HitmanGO
{
    public class SelectLevel : MonoBehaviour
    {
        public void OnLevelButtonClicked(int levelIndex)
        {

            GameManager.GetInstance.ChangeState(GameManager.States.Gameplay);

            SceneManager.LoadScene(levelIndex + 2);
        }

    }

}
