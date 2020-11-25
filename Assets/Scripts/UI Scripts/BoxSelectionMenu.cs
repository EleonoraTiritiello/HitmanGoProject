using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace HitmanGO
{
    public class BoxSelectionMenu : MonoBehaviour
    {
        #region Private Variables 

        [SerializeField]
        private GameObject mainMenu;

        [SerializeField]
        private Image _blackPanel;

        [SerializeField]
        private GameObject _blackObject;

        #endregion

        public void BackButtonPressed()
        {
            //Sequenza quando viene premuto il pulsante back(forse era meglio una coroutine ma sono designer)
            BlackPanelAppears();
            FadeIn();
            BlackPanelDisappears();
            FadeOut();

            AudioManager.Instance.PlaySound("SelectedButton");
            AudioManager.Instance.PlaySound("MenuSoundtrack");

            Debug.Log("BackButtonClicked");


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

        public void BoxSelected()
        {
            //inserire interazione con lo SceneManager. Il tasto con questa funzione sarà l'immagine della box
            SceneManager.LoadScene(1);

            AudioManager.Instance.PlaySound("SelectedButton");
        }

        public void OnBackButtonClicked()
        {
            gameObject.SetActive(false);
            BackButtonPressed();

            AudioManager.Instance.PlaySound("SelectedButton");
            AudioManager.Instance.PlaySound("MenuSoundtrack");

            UIMenu.GetInstance.ChangeMenu(UIMenu.Menus.MainMenu);


        }



    }

}
