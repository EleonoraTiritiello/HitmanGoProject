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

        private void FadeIn()
        {

            //cambia l'alpha del pannello nero a 1(totalmente nero) in X secondi(secondo paramentro) dopo averla impostata a 0
            _blackPanel.canvasRenderer.SetAlpha(0f);
            _blackPanel.CrossFadeAlpha(1, 0.4f, true);
        }

        private void FadeOut()
        {

            //cambia l'alpha del pannello nero a 0(totalmente trasparente) in X secondi(secondo paramentro)
            _blackPanel.CrossFadeAlpha(0, 0.4f, false);
        }

        private void BlackPanelAppears()
        {

            //disattiva il gameobject del pannello nero

            _blackObject.SetActive(true);
        }

        private void BlackPanelDisappears()
        {
            //attiva il gameobject del pannello nero
            _blackObject.SetActive(false);
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
        }

        public void OnExitButtonClicked()
        {
            Debug.Log("Exit");
        }

    }

}

