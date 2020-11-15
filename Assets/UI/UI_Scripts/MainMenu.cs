using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject mainMenuTopLeftZone;
    [SerializeField]
    private GameObject mainMenuTopRightZone;
    [SerializeField]
    private GameObject mainMenuMiddleCenterZone;
    [SerializeField]
    private GameObject optionsMenu;
    [SerializeField]
    private GameObject boxSelectionTopLeftZone;
    [SerializeField]
    private GameObject boxSelectionTopRightZone;
    [SerializeField]
    private GameObject boxSelectionBottomMiddleZone;
    [SerializeField]
    private GameObject boxSelectionMiddleCenterZone;
    [SerializeField]
    private GameObject blackPanelObject;
    [SerializeField]
    private Image blackPanelImage;

    public void GoButtonPressed()
    {
        //Sequenza quando viene premuto il pulsante GO(forse era meglio una coroutine ma sono designer)
        BlackPanelAppears();
        FadeIn();
        Invoke("MainMenuDisappears", 0.4f);
        Invoke("BoxSelectionAppears", 0.4f);
        Invoke("FadeOut", 0.5f);
        Invoke("BlackPanelDisappears", 1f);
        Debug.Log("GoButtonClicked");
    }

    public void OptionButtonPressed()
    {
        //Sequenza quando viene premuto il pulsante opzioni(forse era meglio una coroutine ma sono designer)
        BlackPanelAppears();
        FadeIn();
        Invoke("MainMenuDisappears", 0.4f);
        Invoke("OptionsMenuAppears", 0.4f);
        Invoke("FadeOut", 0.5f);
        Invoke("BlackPanelDisappears", 1f);
        Debug.Log("OptionButtonClicked");
    }

    private void MainMenuDisappears()
    {
        //disattiva immagini e pulsanti del menu inziale
        mainMenuTopLeftZone.SetActive(false);
        mainMenuTopRightZone.SetActive(false);
        mainMenuMiddleCenterZone.SetActive(false);
    }
    private void BoxSelectionAppears()
    {
        //attiva immagini e pulsanti della box selection
        boxSelectionTopLeftZone.SetActive(true);
        boxSelectionTopRightZone.SetActive(true);
        boxSelectionBottomMiddleZone.SetActive(true);
        boxSelectionMiddleCenterZone.SetActive(true);
    }
    private void OptionsMenuAppears()
    {
        //attiva immagini e pulsanti del menu opzioni
        optionsMenu.SetActive(true);
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
