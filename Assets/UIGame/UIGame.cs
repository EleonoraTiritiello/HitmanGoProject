using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace HitmanGO
{
    public class UIGame : MonoBehaviour
    {
        [SerializeField]
        private GameObject optionButton;
        [SerializeField]
        private GameObject restartButton;
        [SerializeField]
        private GameObject hintsButton;
        [SerializeField]
        private GameObject restartButton2;
        [SerializeField]
        private GameObject backToLevelSelectionButton;
        [SerializeField]
        private GameObject levelInfo;
        [SerializeField]
        private GameObject completionCard1;
        [SerializeField]
        private GameObject background;
        [SerializeField]
        private GameObject boxImage;
        [SerializeField]
        private GameObject loading;
        [SerializeField]
        private GameObject completed1;
        [SerializeField]
        private GameObject completed2;
        [SerializeField]
        private GameObject completed3;
        [SerializeField]
        private GameObject completed4;


        [SerializeField]
        private GameObject blackPanelObject;
        [SerializeField]
        private Image blackPanelImage;

        private void Awake()
        {
            LevelManger.GetInstance.CompleteLevel += OnLevelCompleted;
        }

        private void Start()
        {
            BlackPanelAppears();
            FadeOut();
            Invoke("BlackPanelDisappears", 0.5f);
        }

        private void OnLevelCompleted()
        {
            completed1.SetActive(true);
            completed2.SetActive(true);
            completed3.SetActive(true);
            completed4.SetActive(true);
            UI1Disappears();
            UI2Disappears();
        }
        public void RestartButtonPressed()
        {
            BlackPanelAppears();
            FadeIn();
            Invoke("UI1Disappears", 0.4f);
            Invoke("UI4Disappears", 0.4f);
            Invoke("UI3Appears", 0.4f);
            Invoke("FadeOut", 0.5f);
            Invoke("FadeIn", 3f);
            Invoke("ReloadScene", 3f);

        }
        public void OptionMenuPressed()
        {
            UI1Disappears();
            UI2Appears();
        }

        public void BackToMenuPressed()
        {
            BlackPanelAppears();
            FadeIn();
            Invoke("UI1Disappears", 0.4f);
            Invoke("UI4Disappears", 0.4f);
            Invoke("UI3Appears", 0.4f);
            Invoke("FadeOut", 0.5f);
            Invoke("FadeIn", 3f);
            Invoke("ToLevelSelection", 3f);

        }

        public void XButtonPressed()
        {
            UI2Disappears();
            UI1Appears();
        }


        private void UI1Disappears()
        {
            optionButton.SetActive(false);
            restartButton.SetActive(false);
            hintsButton.SetActive(false);
        }

        private void UI1Appears()
        {
            optionButton.SetActive(true);
            restartButton.SetActive(true);
            hintsButton.SetActive(true);
        }

        private void UI2Disappears()
        {
            restartButton2.SetActive(false);
            backToLevelSelectionButton.SetActive(false);
            levelInfo.SetActive(false);
            completionCard1.SetActive(false);
        }
        private void UI2Appears()
        {
            restartButton2.SetActive(true);
            backToLevelSelectionButton.SetActive(true);
            levelInfo.SetActive(true);
            completionCard1.SetActive(true);
        }

        private void UI3Appears()
        {
            background.SetActive(true);
            boxImage.SetActive(true);
            loading.SetActive(true);
        }
        private void UI3Disappears()
        {
            background.SetActive(false);
            boxImage.SetActive(false);
            loading.SetActive(false);
        }

        private void UI4Disappears()
        {
            completed1.SetActive(false);
            completed2.SetActive(false);
            completed3.SetActive(false);
            completed4.SetActive(false);

        }





        public void ToLevelSelection()
        {
            SceneManager.LoadScene(2);
        }
        public void ReloadScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }


        private void FadeIn()
        {
            //cambia l'alpha del pannello nero a 1(totalmente nero) in X secondi(secondo paramentro) dopo averla impostata a 0
            blackPanelImage.canvasRenderer.SetAlpha(0f);
            blackPanelImage.CrossFadeAlpha(1, 0.4f, false);
        }
        private void FadeOut()
        {
            //cambia l'alpha del pannello nero a 0(totalmente trasparente) in X secondi(secondo paramentro)
            blackPanelImage.CrossFadeAlpha(0, 0.4f, false);
        }
        private void BlackPanelAppears()
        {
            //disattiva il gameobject del pannello nero

            blackPanelObject.SetActive(true);
        }
        private void BlackPanelDisappears()
        {
            //attiva il gameobject del pannello nero
            blackPanelObject.SetActive(false);
        }

    }
}
