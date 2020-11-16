using UnityEngine;
using UnityEngine.UI;

namespace HitmanGO
{
    public class OptionsMenu : MonoBehaviour
    {
        #region Private Variables

        [SerializeField]
        private GameObject mainMenu;

        [SerializeField]
        private GameObject resetConfirmMenu;

        [SerializeField]
        private Image _blackPanel;

        [SerializeField]
        private GameObject _blackObject;

        [SerializeField]
        private GameObject soundOnObject;
        [SerializeField]
        private GameObject soundOffObject;
        private bool soundEnabled = true;
       
        [SerializeField]
        private GameObject musicOnObject;
        [SerializeField]
        private GameObject musicOffObject;
        private bool musicEnabled = true;
       
        [SerializeField]
        private GameObject qualityHighObject;
        [SerializeField]
        private GameObject qualityLowObject;
        private bool qualityHigh = true;

        [SerializeField]
        private GameObject vSyncOnObject;
        [SerializeField]
        private GameObject vSyncOffObject;
        private bool vSyncEnable = true;


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


        public void ResetGameButtonPressed()
        {
            //Sequenza quando viene premuto il pulsante resetGame(forse era meglio una coroutine ma sono designer)
            StartCoroutine(UIMenu.GetInstance.FadeIn());
            StartCoroutine(UIMenu.GetInstance.BlackPanelAppears());
            StartCoroutine(UIMenu.GetInstance.FadeOut());
            StartCoroutine(UIMenu.GetInstance.BlackPanelDisappears());
            ResetConfirmAppears();

            Debug.Log("ResetButtonClicked");
        }

        private void ResetConfirmAppears()
        {
            //Attiva immagini e pulsanti per la conferma di reset
            resetConfirmMenu.SetActive(true);
        }

        private void Awake()
        {
            OnSoundOnButtonClicked();
            OnMusicOnButtonClicked();
            OnQualityHighButtonClicked();
            OnVSyncOnButtonClicked();
        }

        public void OnBackButtonClicked()
        {
            gameObject.SetActive(false);
            UIMenu.GetInstance.ChangeMenu(UIMenu.Menus.MainMenu);
        }

        public void OnSoundOnButtonClicked()
        {
            soundEnabled = true;
            soundOffObject.SetActive(false);
            soundOnObject.SetActive(true);
        }

        public void OnSoundOffButtonClicked()
        {
            soundEnabled = false;
            soundOffObject.SetActive(true);
            soundOnObject.SetActive(false);
        }

        public void OnMusicOnButtonClicked()
        {
            musicEnabled = true;
            musicOffObject.SetActive(false);
            musicOnObject.SetActive(true);
        }

        public void OnMusicOffButtonClicked()
        {
            musicEnabled = false;
            musicOffObject.SetActive(true);
            musicOnObject.SetActive(false);
        }

        public void OnVSyncOnButtonClicked()
        {
            vSyncEnable = true;
            vSyncOffObject.SetActive(false);
            vSyncOnObject.SetActive(true);
        }

        public void OnVSyncOffButtonClicked()
        {
            vSyncEnable = false;
            vSyncOffObject.SetActive(true);
            vSyncOnObject.SetActive(false);
        }

        public void OnSupportButtonClicked()
        {
            Debug.Log("Support");
        }

        public void OnRestorePurchasesButtonClicked()
        {
            Debug.Log("RestorePurchases");
        }

        public void OnResetGameButtonClicked()
        {
            gameObject.SetActive(false);
            UIMenu.GetInstance.ChangeMenu(UIMenu.Menus.ResetGame);
        }

        public void OnCreditsButtonClicked()
        {
            Debug.Log("Credits");
        }

        public void OnQualityLowButtonClicked()
        {
            qualityHigh = false;
            qualityLowObject.SetActive(true);
            qualityHighObject.SetActive(false);

        }

        public void OnQualityHighButtonClicked()
        {
            qualityHigh = true;
            qualityLowObject.SetActive(false);
            qualityHighObject.SetActive(true);
        }

        public void OnChangeLanguageButtonClicked()
        {
            Debug.Log("ChangeLanguage");
        }

    }

}
