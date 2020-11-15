using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour
{
    [SerializeField]
    private GameObject blackPanelObject;
    [SerializeField]
    private Image blackPanelImage;

    private void Start()
    {
        BlackPanelAppears();
        FadeOut();
        Invoke("BlackPanelDisappears", 1f);
    }

    public void BackButtonPressed()
    {
        BlackPanelAppears();
        FadeIn();
        Invoke("SceneMinusOne", 0.4f);

    }
    public void FirstLevel()
    {
        BlackPanelAppears();
        FadeIn();
        Invoke("ScenePlusOne", 0.4f);

    }
    public void SecondLevel()
    {
        BlackPanelAppears();
        FadeIn();
        Invoke("ScenePlusTwo", 0.4f);
    }
    public void ThirdLevel()
    {
        BlackPanelAppears();
        FadeIn();
        Invoke("ScenePlusThree", 0.4f);
    }
    public void FourthLevel()
    {
        BlackPanelAppears();
        FadeIn();
        Invoke("ScenePlusFour", 0.4f);

    }
    public void FifthLevel()
    {
        BlackPanelAppears();
        FadeIn();
        Invoke("ScenePlusFive", 0.4f);
    }
    public void SixthLevel()
    {
        BlackPanelAppears();
        FadeIn();
        Invoke("ScenePlusSix", 0.4f);
    }


    public void ScenePlusOne()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Debug.Log("click");
    }
    public void ScenePlusTwo()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        Debug.Log("click");
    }

    public void ScenePlusThree()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
        Debug.Log("click");
    }
    public void ScenePlusFour()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 4);
        Debug.Log("click");
    }
    public void ScenePlusFive()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 5);
        Debug.Log("click");
    }
    public void ScenePlusSix()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 6);
        Debug.Log("click");
    }

    public void SceneMinusOne()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        Debug.Log("click");

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
