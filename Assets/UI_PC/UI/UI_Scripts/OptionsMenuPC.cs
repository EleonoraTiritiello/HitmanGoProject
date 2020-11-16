using UnityEngine;
using UnityEngine.UI;

public class OptionsMenuPC : MonoBehaviour
{
    [SerializeField]
    private GameObject mainMenuBottomLeftZone;
    [SerializeField]
    private GameObject mainMenuBottomRightZone;
    [SerializeField]
    private GameObject mainMenuMiddleCenterZone;
    [SerializeField]
    private GameObject optionsMenu;
    [SerializeField]
    private GameObject resetConfirmMenu;
    [SerializeField]
    private GameObject blackPanelObject;
    [SerializeField]
    private Image blackPanelImage;

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
    private GameObject vSyncHighObject;
    [SerializeField]
    private GameObject vSyncLowObject;
    private bool qualityHigh = true;

    [SerializeField]
    private GameObject fullscreenObject;
    [SerializeField]
    private GameObject windowedObject;
    private bool isFillscreen = true;

    public void BackButtonPressed()
    {
        //Sequenza quando viene premuto il pulsante back(forse era meglio una coroutine ma sono designer)
        BlackPanelAppears();
        FadeIn();
        Invoke("OptionsMenuDisappears", 0.4f);
        Invoke("MainMenuAppears", 0.4f);
        Invoke("FadeOut", 0.5f);
        Invoke("BlackPanelDisappears", 1f);
        Debug.Log("BackButtonClicked");
    }

    public void SoundButtonPressed()
    {
        //Se si clicca sul pulsante suoni quando i suoni sono attivi viene aggiornata l'image e il testo
        //Da aggiungere il behaviour con il sound manager
        if (soundEnabled == true)
        {
            soundEnabled = false;
            soundOnObject.SetActive(false);
            soundOffObject.SetActive(true);
        }
        //Se si clicca sul pulsante suoni quando i suoni sono attivi viene aggiornata l'image e il testo
        //Da aggiungere il behaviour con il sound manager
        else if (soundEnabled == false)
        {
            soundEnabled = true;
            soundOffObject.SetActive(false);
            soundOnObject.SetActive(true);
        }
        Debug.Log("SoundButtonClicked");
    }
    public void MusicButtonPressed()
    {
        //Se si clicca sul pulsante musica quando i suoni sono attivi viene aggiornata l'image e il testo
        //Da aggiungere il behaviour con il sound manager
        if (musicEnabled == true)
        {
            musicEnabled = false;
            musicOnObject.SetActive(false);
            musicOffObject.SetActive(true);
        }
        //Se si clicca sul pulsante musica quando i suoni sono attivi viene aggiornata l'image e il testo
        //Da aggiungere il behaviour con il sound manager
        else if (musicEnabled == false)
        {
            musicEnabled = true;
            musicOffObject.SetActive(false);
            musicOnObject.SetActive(true);
        }
        Debug.Log("MusicButtonClicked");
    }

    public void ResetGameButtonPressed()
    {
        //Sequenza quando viene premuto il pulsante resetGame(forse era meglio una coroutine ma sono designer)
        BlackPanelAppears();
        FadeIn();
        Invoke("OptionsMenuDisappears", 0.4f);
        Invoke("ResetConfirmAppears", 0.4f);
        Invoke("FadeOut", 0.5f);
        Invoke("BlackPanelDisappears", 1f);
        Debug.Log("ResetButtonClicked");
    }

    public void vSyncButtonPressed()
    {
        //Se si clicca sul pulsante qualità quando i suoni sono attivi viene aggiornata l'image e il testo
        //Da aggiungere il behaviour effettivo sulla qualità del gioco
        if (qualityHigh == true)
        {
            qualityHigh = false;
            vSyncHighObject.SetActive(false);
            vSyncLowObject.SetActive(true);
        }
        //Se si clicca sul pulsante qualità quando i suoni sono attivi viene aggiornata l'image e il testo
        //Da aggiungere il behaviour sulla qualità del gioco
        else if (qualityHigh == false)
        {
            qualityHigh = true;
            vSyncLowObject.SetActive(false);
            vSyncHighObject.SetActive(true);
        }
    }

    public void fullScreenButtonPressed()
    {
        if (isFillscreen == true)
        {
            isFillscreen = false;
            fullscreenObject.SetActive(false);
            windowedObject.SetActive(true);
        }
        //se si clicca il pulsante mentre si è in fullscreen, aggiornare il testo e l'immagine
        //manca l'effettivo behavior
        else if (isFillscreen == false)
        {
            isFillscreen = true;
            fullscreenObject.SetActive(true);
            windowedObject.SetActive(false);
        }
    }
    private void MainMenuAppears()
    {
        //Attiva immagini e pulsanti del menu inziale
        mainMenuBottomLeftZone.SetActive(true);
        mainMenuBottomRightZone.SetActive(true);
        mainMenuMiddleCenterZone.SetActive(true);
    }
    private void OptionsMenuDisappears()
    {
        //Disattiva immagini e pulsanti del menu opzioni
        optionsMenu.SetActive(false);
    }
    private void ResetConfirmAppears()
    {
        //Attiva immagini e pulsanti per la conferma di reset
        resetConfirmMenu.SetActive(true);
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
