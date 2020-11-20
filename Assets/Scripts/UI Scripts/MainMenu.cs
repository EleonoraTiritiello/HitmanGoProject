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

        public void GoButtonPressed()
        {
            //Sequenza quando viene premuto il pulsante GO(forse era meglio una coroutine ma sono designer)
            StartCoroutine(UIMenu.GetInstance.FadeIn());
            StartCoroutine(UIMenu.GetInstance.BlackPanelAppears());
            StartCoroutine(UIMenu.GetInstance.FadeOut());
            StartCoroutine(UIMenu.GetInstance.BlackPanelDisappears());

            Debug.Log("GoButtonClicked");
        }

        public void OptionButtonPressed()
        {
            //Sequenza quando viene premuto il pulsante opzioni(forse era meglio una coroutine ma sono designer)
            StartCoroutine(UIMenu.GetInstance.FadeIn());
            StartCoroutine(UIMenu.GetInstance.BlackPanelAppears());
            StartCoroutine(UIMenu.GetInstance.FadeOut());
            StartCoroutine(UIMenu.GetInstance.BlackPanelDisappears());

            Debug.Log("OptionButtonClicked");
        }

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
            SceneManager.LoadScene(levelIndex + 1);
        }

        public void OnExitButtonClicked()
        {
            Debug.Log("Exit");
        }

    }

}

