using UnityEngine;
using UnityEngine.UI;

namespace HitmanGO
{
    public class ResetGameOptions : MonoBehaviour
    {
        #region Private Variables

        [SerializeField]
        private Image _blackPanel;

        [SerializeField]
        private GameObject _blackObject;

        #endregion

        public void BackButtonPressed()
        {
            //Sequenza quando viene premuto il pulsante back
            BlackPanelAppears();
            FadeIn();
            Invoke("ChangeUIToOptions", 0.4f);
            Invoke("OptionsMenuAppears", 0.4f);
            Invoke("FadeOut", 0.5f);
            Invoke("BlackPanelDisappears", 1f);

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

        private void OptionsMenuAppears()
        {
            //attiva immagini e pulsanti del menu opzioni
            gameObject.SetActive(false);
        }

        public void OnVButtonClicked()
        {
            //Inserire il behaviour che resetta il gioco
            Debug.Log("VButtonClicked");
        }

        public void OnXButtonClicked()
        {
            // StartCoroutine(UIMenu.GetInstance.FadeIn());
            // StartCoroutine(UIMenu.GetInstance.FadeOut());
            // StartCoroutine(UIMenu.GetInstance.BlackPanelAppears());
            // StartCoroutine(UIMenu.GetInstance.BlackPanelDisappears());

            BackButtonPressed();
        }
        private void ChangeUIToOptions()
        {
            UIMenu.GetInstance.ChangeMenu(UIMenu.Menus.OptionsMenu);
        }

    }

}
