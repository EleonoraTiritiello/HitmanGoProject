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

            AudioManager.Instance.PlaySound("MenuSoundtrack");

            AudioManager.Instance.PlaySound("SelectedButton");
        }

        public void BackButtonPressed()
        {
            //Sequenza quando viene premuto il pulsante back(forse era meglio una coroutine ma sono designer)
            BlackPanelAppears();
            FadeIn();
            Invoke("ChangeUIToMainMenu", 0.4f);
            Invoke("DeactivateOptions", 0.4f);
            Invoke("FadeOut", 0.5f);
            Invoke("BlackPanelDisappears", 1f);

        }

        public void ResetGameButtonPressed()
        {
            //Sequenza quando viene premuto il pulsante resetGame(forse era meglio una coroutine ma sono designer)

            BlackPanelAppears();
            FadeIn();
            Invoke("ChangeUIToResetMenu", 0.4f);
            Invoke("DeactivateOptions", 0.4f);
            Invoke("FadeOut", 0.5f);
            Invoke("BlackPanelDisappears", 1f);
        }

        public void OnBackButtonClicked()
        {
            BackButtonPressed();

            AudioManager.Instance.PlaySound("SelectedButton");
            AudioManager.Instance.PlaySound("MenuSoundtrack");
        }

        private void ChangeUIToMainMenu()
        {
            UIMenu.GetInstance.ChangeMenu(UIMenu.Menus.MainMenu);

            if(soundEnabled == true)
            {
                soundEnabled = false;
                AudioManager.Instance.PlaySound("MenuSoundtrack");
               
            }
            else if (soundEnabled == false)
            {
                soundEnabled = true;
                AudioManager.Instance.StopSound("MenuSoundtrack");
                
            }

            if (musicEnabled == true)
            {
                musicEnabled = false;
                AudioManager.Instance.PlaySound("MenuSoundtrack");

            }
            else if (musicEnabled == false)
            {
                musicEnabled = true;
                AudioManager.Instance.StopSound("MenuSoundtrack");

            }
        }

        private void DeactivateOptions()
        {
            gameObject.SetActive(false);
        }

        public void OnSoundOnButtonClicked()
        {
            soundEnabled = true;
            soundOffObject.SetActive(false);
            soundOnObject.SetActive(true);

            AudioManager.Instance.PlaySound("SelectedButton");
            AudioManager.Instance.PlaySound("MenuSoundtrack");
        }

        public void OnSoundOffButtonClicked()
        {
            soundEnabled = false;
            soundOffObject.SetActive(true);
            soundOnObject.SetActive(false);

            AudioManager.Instance.PlaySound("SelectedButton");
            AudioManager.Instance.StopSound("MenuSoundtrack");
        }

        public void OnMusicOnButtonClicked()
        {
            musicEnabled = true;
            musicOffObject.SetActive(false);
            musicOnObject.SetActive(true);

            AudioManager.Instance.PlaySound("SelectedButton");
            AudioManager.Instance.PlaySound("MenuSoundtrack");
        }

        public void OnMusicOffButtonClicked()
        {
            musicEnabled = false;
            musicOffObject.SetActive(true);
            musicOnObject.SetActive(false);

            AudioManager.Instance.PlaySound("SelectedButton");
            AudioManager.Instance.StopSound("MenuSoundtrack");
        }

        public void OnVSyncOnButtonClicked()
        {
            vSyncEnable = true;
            vSyncOffObject.SetActive(false);
            vSyncOnObject.SetActive(true);

            QualitySettings.vSyncCount = 1;

            AudioManager.Instance.PlaySound("SelectedButton");
        }

        public void OnVSyncOffButtonClicked()
        {
            vSyncEnable = false;
            vSyncOffObject.SetActive(true);
            vSyncOnObject.SetActive(false);

            QualitySettings.vSyncCount = 0;

            AudioManager.Instance.PlaySound("SelectedButton");
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
            ResetGameButtonPressed();

            AudioManager.Instance.PlaySound("SelectedButton");
        }
        private void ChangeUIToResetMenu()
        {
            UIMenu.GetInstance.ChangeMenu(UIMenu.Menus.ResetGame);

        }

        public void OnCreditsButtonClicked()
        {
            Debug.Log("Credits");
        }

        public void OnQualityButtonClicked()
        {
            if (qualityHigh == true)
            {
                qualityLowObject.SetActive(true);
                qualityHighObject.SetActive(false);
                qualityHigh = false;
                QualitySettings.SetQualityLevel(0);

                AudioManager.Instance.PlaySound("SelectedButton");
            }
            else if (qualityHigh == false)
            {
                qualityLowObject.SetActive(false);
                qualityHighObject.SetActive(true);
                qualityHigh = true;
                QualitySettings.SetQualityLevel(5);

                AudioManager.Instance.PlaySound("SelectedButton");
            }
        }

        public void FullScreenWindowedMode()
        {

            Screen.fullScreen = !Screen.fullScreen;
            if (fullScreenMode == true)
            {
                fullScreenObject.SetActive(false);
                windowObject.SetActive(true);
                fullScreenMode = false;

                AudioManager.Instance.PlaySound("SelectedButton");

            }
            else if (fullScreenMode == false)
            {
                fullScreenObject.SetActive(true);
                windowObject.SetActive(false);
                fullScreenMode = true;

                AudioManager.Instance.PlaySound("SelectedButton");
            }

        }


        public void OnResolutionButtonClicked()
        {
            if (resolution1Bool == true)
            {

                resolution1.SetActive(false);
                resolution2.SetActive(true);
                resolution1Bool = false;

                AudioManager.Instance.PlaySound("SelectedButton");
            }
            else if (resolution1Bool == false)
            {

                resolution1.SetActive(true);
                resolution2.SetActive(false);
                resolution1Bool = true;

                AudioManager.Instance.PlaySound("SelectedButton");

            }
        }

        public void ToResolutionConfirm()
        {
            if (resolution == 0 && resolution1Bool == false)
            {
                BlackPanelAppears();
                FadeIn();
                Invoke("ResolutionChangeCheck1", 0.4f);
                Invoke("FadeOut", 0.5f);
                Invoke("BlackPanelDisappears", 1f);
            }
            else if (resolution == 1 && resolution1Bool == true)
            {
                BlackPanelAppears();
                FadeIn();
                Invoke("ResolutionChangeCheck2", 0.4f);
                Invoke("FadeOut", 0.5f);
                Invoke("BlackPanelDisappears", 1f);
            }
        }
        private void ResolutionChangeCheck1()
        {
            resolutionChangePage1.SetActive(true);
            resolutionChangePage2.SetActive(true);
            optionMenu.SetActive(false);
            Screen.SetResolution(1680, 1050, true);

            AudioManager.Instance.PlaySound("SelectedButton");

        }
        private void ResolutionChangeCheck2()
        {
            resolutionChangePage1.SetActive(true);
            resolutionChangePage2.SetActive(true);
            optionMenu.SetActive(false);
            Screen.SetResolution(1920, 1080, true);

            AudioManager.Instance.PlaySound("SelectedButton");

        }


        public void ConfirmResolutionChange()
        {
            if (resolution == 0)
            {
                BlackPanelAppears();
                FadeIn();
                Invoke("ResolutionChange1Confirmed", 0.4f);
                Invoke("FadeOut", 0.5f);
                Invoke("BlackPanelDisappears", 1f);

            }
            else if (resolution == 1)
            {
                BlackPanelAppears();
                FadeIn();
                Invoke("ResolutionChange2Confirmed", 0.4f);
                Invoke("FadeOut", 0.5f);
                Invoke("BlackPanelDisappears", 1f);

            }
        }

        private void ResolutionChange1Confirmed()
        {
            resolutionChangePage1.SetActive(false);
            resolutionChangePage2.SetActive(false);
            optionMenu.SetActive(true);

            resolution = 1;

            AudioManager.Instance.PlaySound("SelectedButton");

        }
        private void ResolutionChange2Confirmed()
        {
            resolutionChangePage1.SetActive(false);
            resolutionChangePage2.SetActive(false);
            optionMenu.SetActive(true);

            resolution = 0;

            AudioManager.Instance.PlaySound("SelectedButton");
        }


        public void CancelResolutionChange()
        {
            if (resolution == 0)
            {
                BlackPanelAppears();
                FadeIn();
                Invoke("ResolutionChange1Canceled", 0.4f);
                Invoke("FadeOut", 0.5f);
                Invoke("BlackPanelDisappears", 1f);

            }
            else if (resolution == 1)
            {
                BlackPanelAppears();
                FadeIn();
                Invoke("ResolutionChange2Canceled", 0.4f);
                Invoke("FadeOut", 0.5f);
                Invoke("BlackPanelDisappears", 1f);
            }
        }

        private void ResolutionChange1Canceled()
        {
            resolutionChangePage1.SetActive(false);
            resolutionChangePage2.SetActive(false);
            Screen.SetResolution(1920, 1080, true);
            optionMenu.SetActive(true);

            AudioManager.Instance.PlaySound("SelectedButton");

        }
        private void ResolutionChange2Canceled()
        {
            resolutionChangePage1.SetActive(false);
            resolutionChangePage2.SetActive(false);
            Screen.SetResolution(1680, 1050, true);
            optionMenu.SetActive(true);

            AudioManager.Instance.PlaySound("SelectedButton");
        }


        public void OnChangeLanguageButtonClicked()
        {
            Debug.Log("ChangeLanguage");
        }

    }

}
