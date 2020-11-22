using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationCamera3 : MonoBehaviour
{
    public GameObject myAnimation;
    public GameObject animationON;
    public GameObject animLookAt;

    private void StartLevel()
    {
        myAnimation.gameObject.GetComponent<Animator>().enabled = false;
        animationON.SetActive(true);
        animLookAt.SetActive(false);
    }
}
