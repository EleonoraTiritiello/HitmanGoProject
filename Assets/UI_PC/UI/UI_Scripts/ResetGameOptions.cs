using UnityEngine;
using UnityEngine.UI;

public class ResetGameOptions : MonoBehaviour
{
    [SerializeField]
    private GameObject optionsMenu;
    [SerializeField]
    private GameObject resetConfirmMenu;
    [SerializeField]
    private GameObject blackPanelObject;
    [SerializeField]
    private Image blackPanelImage;

    public void Confirm()
    {
        //Inserire il behaviour che resetta il gioco
        Debug.Log("VButtonClicked");
    }

    public void Refuse()
    {
        //Sequenza quando viene premuto il pulsante X(forse era meglio una coroutine ma sono designer)
        BlackPanelAppears();
        FadeIn();
        Invoke("ResetConfirmDisappears", 0.4f);
        Invoke("OptionsMenuAppears", 0.4f);
        Invoke("FadeOut", 0.5f);
        Invoke("BlackPanelDisappears", 1f);
        Debug.Log("XButtonClicked");
    }
    private void OptionsMenuAppears()
    {
        //attiva immagini e pulsanti del menu opzioni
        optionsMenu.SetActive(true);
    }
    private void ResetConfirmDisappears()
    {
        //Attiva immagini e pulsanti per la conferma di reset
        resetConfirmMenu.SetActive(false);
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
