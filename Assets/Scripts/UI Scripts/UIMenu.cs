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

        #endregion

    }

}
