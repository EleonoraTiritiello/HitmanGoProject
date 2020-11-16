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
            StartCoroutine(UIMenu.GetInstance.FadeIn());
            StartCoroutine(UIMenu.GetInstance.FadeOut());
            StartCoroutine(UIMenu.GetInstance.BlackPanelAppears());
            StartCoroutine(UIMenu.GetInstance.BlackPanelDisappears());

            OptionsMenuAppears();
            UIMenu.GetInstance.ChangeMenu(UIMenu.Menus.OptionsMenu);
        }

    }

}
