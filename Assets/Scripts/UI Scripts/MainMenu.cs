using UnityEngine;
using UnityEngine.UI;

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
            BlackPanelAppears();
            FadeIn();
            Invoke("ChangeUIToOptions", 0.4f);
            Invoke("DeactivateMainMenu", 0.4f);
            Invoke("FadeOut", 0.5f);
            Invoke("BlackPanelDisappears", 1f);
        }

        private void ChangeUIToOptions()
        {
            UIMenu.GetInstance.ChangeMenu(UIMenu.Menus.OptionsMenu);
        }
        private void DeactivateMainMenu()
        {
            gameObject.SetActive(false);

        }
        public void OnAchievementButtonClicked()
        {
        }

        public void OnFacebookButtonClicked()
        {
        }

        public void OnTwitterButtonClicked()
        {
        }

        public void OnGooglePlayButtonClicked()
        {
        }

        public void OnGOButtonClicked(int levelIndex)
        {
            gameObject.SetActive(false);
            // UIMenu.GetInstance.ChangeMenu(UIMenu.Menus.BoxSelections);
            GameManager.GetInstance.ChangeState(GameManager.States.BoxSelectMenu);
        }

        public void OnExitButtonClicked()
        {
            Application.Quit();
        }
        private void FadeIn()
        {
            //cambia l'alpha del pannello nero a 1(totalmente nero) in X secondi(secondo paramentro) dopo averla impostata a 0
            _blackPanel.canvasRenderer.SetAlpha(0f);
            _blackPanel.CrossFadeAlpha(1, 0.4f, false);
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

    }

}
