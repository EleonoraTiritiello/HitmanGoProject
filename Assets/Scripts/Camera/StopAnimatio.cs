using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopAnimatio : MonoBehaviour
{
    public GameObject myAnimation;
    private void faiquellochetidico()
    {
        myAnimation.gameObject.GetComponent<Animator>().enabled = false;
    }
}
