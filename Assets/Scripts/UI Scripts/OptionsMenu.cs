using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace HitmanGO
{
    public class OptionsMenu : MonoBehaviour
    {
        #region Public Variables

        public int textureQuality;
        public int resolutionIndex;
        public int vSync;

        // List of horizontal resolutions to include
            int[] resolutions = new int[] { 600, 800, 1024, 1280, 1400, 1600, 1920 };

        public Resolution displayResolution;

        #endregion

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

        [SerializeField]
        private GameObject resolution1;
        [SerializeField]
        private GameObject resolution2;
        private bool resolution1Bool = true;
        
        [SerializeField]
        private GameObject fullScreenObject;
        [SerializeField]
        private GameObject windowObject;
        private bool fullScreenMode = true;

        [SerializeField]
        private GameObject resolutionChangePage1;
        [SerializeField]
        private GameObject resolutionChangePage2;
        private int resolution = 0;

        [SerializeField]
        private GameObject optionMenu;


        #endregion

        #region Private Methods 

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

        private void ResetConfirmAppears()
        {
            //Attiva immagini e pulsanti per la conferma di reset
            resetConfirmMenu.SetActive(true);
        }

        #endregion

        private void Awake()
        {
            Screen.fullScreen = true;
        }

        public void BackButtonPressed()
        {
            //Sequenza quando viene premuto il pulsante back(forse era meglio una coroutine ma sono designer)
            BlackPanelAppears();
            FadeIn();
            BlackPanelDisappears();
            FadeOut();
            Debug.Log("BackButtonClicked");
        }

        public void ResetGameButtonPressed()
        {
            //Sequenza quando viene premuto il pulsante resetGame(forse era meglio una coroutine ma sono designer)

            BlackPanelAppears();
            FadeIn();
            BlackPanelDisappears();
            FadeOut();

            ResetConfirmAppears();

            Debug.Log("ResetButtonClicked");
        }

        public void OnBackButtonClicked()
        {
            gameObject.SetActive(false);
            BackButtonPressed();
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

            QualitySettings.vSyncCount = 1;
        }

        public void OnVSyncOffButtonClicked()
        {
            vSyncEnable = false;
            vSyncOffObject.SetActive(true);
            vSyncOnObject.SetActive(false);

            QualitySettings.vSyncCount = 0;
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
            ResetGameButtonPressed();
            UIMenu.GetInstance.ChangeMenu(UIMenu.Menus.ResetGame);
        }

        public void OnCreditsButtonClicked()
        {
            Debug.Log("Credits");
        }

        public void OnQualityButtonClicked()
        {
            if(qualityHigh == true)
            {
                qualityLowObject.SetActive(true);
                qualityHighObject.SetActive(false);
                qualityHigh = false;
                QualitySettings.SetQualityLevel(0);
            }
            else if (qualityHigh == false)
            {
                qualityLowObject.SetActive(false);
                qualityHighObject.SetActive(true);
                qualityHigh = true;
                QualitySettings.SetQualityLevel(5);
            }
        }

        public void FullScreenWindowedMode()
        {

            Screen.fullScreen = !Screen.fullScreen;
            if(fullScreenMode == true)
            {
                fullScreenObject.SetActive(false);
                windowObject.SetActive(true);
                fullScreenMode = false;

            }
            else if(fullScreenMode == false)
            {
                fullScreenObject.SetActive(true);
                windowObject.SetActive(false);
                fullScreenMode = true;
            }

        }


        public void OnResolutionButtonClicked()
        {
            if (resolution1Bool == true)
            {

                resolution1.SetActive(false);
                resolution2.SetActive(true);
                resolution1Bool = false;
            }
            else if (resolution1Bool == false)
            {

                resolution1.SetActive(true);
                resolution2.SetActive(false);
                resolution1Bool = true;

            }
        }

        public void ToResolutionConfirm()
        {
            if (resolution == 0 && resolution1Bool == false)
            {
                resolutionChangePage1.SetActive(true);
                resolutionChangePage2.SetActive(true);
                optionMenu.SetActive(false);
                Screen.SetResolution(1680, 1050, true);

            }
            else if (resolution == 1 && resolution1Bool == true)
            {
                resolutionChangePage1.SetActive(true);
                resolutionChangePage2.SetActive(true);
                optionMenu.SetActive(false);
                Screen.SetResolution(1920, 1080, true);
            }
        }

        public void ConfirmResolutionChange()
        {
            if (resolution == 0)
            {
                resolutionChangePage1.SetActive(false);
                resolutionChangePage2.SetActive(false);
                optionMenu.SetActive(true);

                resolution = 1;
            }
            else if (resolution == 1)
            {
                resolutionChangePage1.SetActive(false);
                resolutionChangePage2.SetActive(false);
                optionMenu.SetActive(true);

                resolution = 0;
            }
        }

        public void CancelResolutionChange()
        {
            if (resolution == 0)
            {
                resolutionChangePage1.SetActive(false);
                resolutionChangePage2.SetActive(false);
                Screen.SetResolution(1920, 1080, true);
                optionMenu.SetActive(true);

            }
            else if (resolution == 1)
            {
                resolutionChangePage1.SetActive(false);
                resolutionChangePage2.SetActive(false);
                Screen.SetResolution(1680, 1050, true);
                optionMenu.SetActive(true);
            }
        }

        public void OnChangeLanguageButtonClicked()
        {
            Debug.Log("ChangeLanguage");
        }

    }

}
