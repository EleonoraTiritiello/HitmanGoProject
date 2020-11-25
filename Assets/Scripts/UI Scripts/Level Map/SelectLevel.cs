using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace HitmanGO
{
    public class SelectLevel : MonoBehaviour
    {
        [SerializeField]
        private Image _blackPanel;

        [SerializeField]
        private GameObject _blackObject;

        int levelIndex;
        public void OnLevel1ButtonClicked()
        {
            BlackPanelAppears();
            FadeIn();
            Invoke("ToLevel1", 0.4f);

            AudioManager.Instance.PlaySound("SelectedButton");
        }

        private void ToLevel1()
        {
            GameManager.GetInstance.ChangeState(GameManager.States.Gameplay);

            SceneManager.LoadScene(levelIndex + 3);

            AudioManager.Instance.StopSound("MenuSoundtrack");
            AudioManager.Instance.PlaySound("GameSoundtrack");

        }
        public void OnLevel2ButtonClicked()
        {
            BlackPanelAppears();
            FadeIn();
            Invoke("ToLevel2", 0.4f);

            AudioManager.Instance.PlaySound("SelectedButton");

        }
        private void ToLevel2()
        {
            GameManager.GetInstance.ChangeState(GameManager.States.Gameplay);

            SceneManager.LoadScene(levelIndex + 4);

            AudioManager.Instance.StopSound("MenuSoundtrack");
            AudioManager.Instance.PlaySound("GameSoundtrack");

        }

        public void OnLevel3ButtonClicked()
        {
            BlackPanelAppears();
            FadeIn();
            Invoke("ToLevel3", 0.4f);

            AudioManager.Instance.PlaySound("SelectedButton");

        }
        private void ToLevel3()
        {
            GameManager.GetInstance.ChangeState(GameManager.States.Gameplay);

            SceneManager.LoadScene(levelIndex + 5);

            AudioManager.Instance.StopSound("MenuSoundtrack");
            AudioManager.Instance.PlaySound("GameSoundtrack");

        }

        public void OnLevel4ButtonClicked()
        {
            BlackPanelAppears();
            FadeIn();
            Invoke("ToLevel4", 0.4f);

            AudioManager.Instance.PlaySound("SelectedButton");

        }
        private void ToLevel4()
        {

            GameManager.GetInstance.ChangeState(GameManager.States.Gameplay);

            SceneManager.LoadScene(levelIndex + 6);

            AudioManager.Instance.StopSound("MenuSoundtrack");
            AudioManager.Instance.PlaySound("GameSoundtrack");

        }

        public void OnLevel5ButtonClicked()
        {
            BlackPanelAppears();
            FadeIn();
            Invoke("ToLevel5", 0.4f);

            AudioManager.Instance.PlaySound("SelectedButton");

        }
        private void ToLevel5()
        {
            GameManager.GetInstance.ChangeState(GameManager.States.Gameplay);

            SceneManager.LoadScene(levelIndex + 7);

            AudioManager.Instance.StopSound("MenuSoundtrack");
            AudioManager.Instance.PlaySound("GameSoundtrack_1_5");

        }

        public void OnLevel6ButtonClicked()
        {
            BlackPanelAppears();
            FadeIn();
            Invoke("ToLevel6", 0.4f);

            AudioManager.Instance.PlaySound("SelectedButton");

        }
        private void ToLevel6()
        {
            GameManager.GetInstance.ChangeState(GameManager.States.Gameplay);

            SceneManager.LoadScene(levelIndex + 8);

            AudioManager.Instance.StopSound("MenuSoundtrack");
            AudioManager.Instance.PlaySound("GameSoundtrack");

        }




        public void OnResetButtonClicked()
        {
            GameManager.GetInstance.ChangeState(GameManager.States.BoxSelectMenu);

            SceneManager.LoadScene(levelIndex + 1);

            AudioManager.Instance.PlaySound("SelectedButton");
            AudioManager.Instance.StopSound("GameSoundtrack");
            AudioManager.Instance.StopSound("GameSoundtrack_1_5");
        }
        private void FadeIn()
        {
            //cambia l'alpha del pannello nero a 1(totalmente nero) in X secondi(secondo paramentro) dopo averla impostata a 0
            _blackPanel.canvasRenderer.SetAlpha(0f);
            _blackPanel.CrossFadeAlpha(1, 0.4f, false);
        }
        private void BlackPanelAppears()
        {
            //disattiva il gameobject del pannello nero

            _blackObject.SetActive(true);
        }

    }


}
