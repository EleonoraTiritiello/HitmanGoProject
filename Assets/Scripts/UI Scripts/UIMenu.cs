using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace HitmanGO
{
    public class UIMenu : Singleton<UIMenu>
    {

        #region Public Variables

        public enum Menus
        {
            MainMenu,
            OptionsMenu,
            ResetGame,
            BoxSelections
        }

        #endregion


        #region Private Variables

        [SerializeField]
        private GameObject _optionsMenu;

        [SerializeField]
        private GameObject _mainMenu;

        [SerializeField]
        private GameObject _resetGame;

        [SerializeField]
        private GameObject _boxSelection;

        [SerializeField]
        private Image _blackPanel;

        [SerializeField]
        private GameObject _blackObject;

        #endregion

        #region Private Methods

        private void Start()
        {
            if (!_mainMenu.activeSelf) _mainMenu.SetActive(true);
            if (_optionsMenu.activeSelf) _optionsMenu.SetActive(false);
            if (_resetGame.activeSelf) _resetGame.SetActive(false);
            if (_boxSelection.activeSelf) _boxSelection.SetActive(false);

        }

        #endregion

        #region Public Methods

        public void ChangeMenu(Menus menu)
        {
            switch (menu)
            {
                case Menus.MainMenu:
                    _mainMenu.SetActive(true);
                    break;
                case Menus.OptionsMenu:
                    _optionsMenu.SetActive(true);
                    break;
                case Menus.ResetGame:
                    _resetGame.SetActive(true);
                    break;
                case Menus.BoxSelections:
                    _boxSelection.SetActive(true);
                    break;
                default:
                    break;
            }
        }

        public IEnumerator FadeIn()
        {
            yield return new WaitForSeconds(1f);

            //cambia l'alpha del pannello nero a 1(totalmente nero) in X secondi(secondo paramentro) dopo averla impostata a 0
            _blackPanel.canvasRenderer.SetAlpha(0f);
            _blackPanel.CrossFadeAlpha(1, 0.4f, true);
        }

        public IEnumerator FadeOut()
        {
            yield return new WaitForSeconds(0f);

            //cambia l'alpha del pannello nero a 0(totalmente trasparente) in X secondi(secondo paramentro)
            _blackPanel.CrossFadeAlpha(0, 0.4f, false);
        }

        public IEnumerator BlackPanelAppears()
        {
            yield return new WaitForSeconds(1f);

            //disattiva il gameobject del pannello nero

            _blackObject.SetActive(true);
        }
        public IEnumerator BlackPanelDisappears()
        {
            yield return new WaitForSeconds(0.5f);

            //attiva il gameobject del pannello nero
            _blackObject.SetActive(false);
        }

        #endregion

    }

}
