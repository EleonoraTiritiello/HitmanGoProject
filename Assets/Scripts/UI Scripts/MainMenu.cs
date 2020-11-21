using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace HitmanGO
{
    public class MainMenu : MonoBehaviour
    {
        #region Private Variables

        [SerializeField]
        private GameObject boxSelection;

        [SerializeField]
        private Image _blackPanel;

        [SerializeField]
        private GameObject _blackObject;

        #endregion


        public void OnOptionsButtonClicked()
        {
            gameObject.SetActive(false);
            UIMenu.GetInstance.ChangeMenu(UIMenu.Menus.OptionsMenu);
        }

        public void OnAchievementButtonClicked()
        {
            Debug.Log("Achievement");
        }

        public void OnFacebookButtonClicked()
        {
            Debug.Log("Facebook");
        }

        public void OnTwitterButtonClicked()
        {
            Debug.Log("Twitter");
        }

        public void OnGooglePlayButtonClicked()
        {
            Debug.Log("GooglePlay");
        }

        public void OnGOButtonClicked(int levelIndex)
        {
            gameObject.SetActive(false);
            // UIMenu.GetInstance.ChangeMenu(UIMenu.Menus.BoxSelections);
            GameManager.GetInstance.ChangeState(GameManager.States.BoxSelectMenu);
        }

        public void OnExitButtonClicked()
        {
            Debug.Log("Exit");
        }

    }

}

