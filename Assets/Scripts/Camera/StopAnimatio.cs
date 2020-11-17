using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopAnimatio : MonoBehaviour
{
    public GameObject myAnimation;
    public GameObject animationON;
    private void animationQuit()
    {
        myAnimation.gameObject.GetComponent<Animator>().enabled = false;
        animationON.SetActive(true);
    }
}
