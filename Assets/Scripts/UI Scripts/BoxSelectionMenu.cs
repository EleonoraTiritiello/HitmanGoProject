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
            StartCoroutine(UIMenu.GetInstance.FadeIn());
            StartCoroutine(UIMenu.GetInstance.BlackPanelAppears());
            StartCoroutine(UIMenu.GetInstance.FadeOut());
            StartCoroutine(UIMenu.GetInstance.BlackPanelDisappears());

            Debug.Log("BackButtonClicked");

        }

        public void BoxSelected()
        {
            //inserire interazione con lo SceneManager. Il tasto con questa funzione sarà l'immagine della box
            SceneManager.LoadScene(1);

        }

        public void OnBackButtonClicked()
        {
            gameObject.SetActive(false);
            UIMenu.GetInstance.ChangeMenu(UIMenu.Menus.MainMenu);
        }



    }

}
