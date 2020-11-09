using UnityEngine;
using UnityEngine.UI;

public class BoxSelectionMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject mainMenuTopLeftZone;
    [SerializeField]
    private GameObject mainMenuTopRightZone;
    [SerializeField]
    private GameObject mainMenuMiddleCenterZone;
    [SerializeField]
    private GameObject boxSelectionTopLeftZone;
    [SerializeField]
    private GameObject boxSelectionTopRightZone;
    [SerializeField]
    private GameObject boxSelectionBottomMiddleZone;
    [SerializeField]
    private GameObject blackPanelObject;
    [SerializeField]
    private Image blackPanelImage;

    public void BackButtonPressed()
    {
        //Sequenza quando viene premuto il pulsante back(forse era meglio una coroutine ma sono designer)
        BlackPanelAppears();
        FadeIn();
        Invoke("BoxSelectionDisappears", 0.4f);
        Invoke("MainMenuAppears", 0.4f);
        Invoke("FadeOut", 0.5f);
        Invoke("BlackPanelDisappears", 1f);
        Debug.Log("BackButtonClicked");

    }

    public void BoxSelected()
    {
        //inserire interazione con lo SceneManager. Il tasto con questa funzione sarà l'immagine della box
    }

    private void MainMenuAppears()
    {
        //Attiva immagini e pulsanti del menu inziale
        mainMenuTopLeftZone.SetActive(true);
        mainMenuTopRightZone.SetActive(true);
        mainMenuMiddleCenterZone.SetActive(true);
    }
    private void BoxSelectionDisappears()
    {
        //Disattiva immagini e pulsanti della box selection
        boxSelectionTopLeftZone.SetActive(false);
        boxSelectionTopRightZone.SetActive(false);
        boxSelectionBottomMiddleZone.SetActive(false);
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
