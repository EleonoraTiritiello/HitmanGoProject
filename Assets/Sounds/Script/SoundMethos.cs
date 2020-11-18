using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMethos : MonoBehaviour
{

    public void LevelCompletePlay() 
    {
        AudioManager.Instance.PlaySound("LevelComplete");
    }

    /*public void LevelCompletePlay()
    {
        AudioManager.Instance.PlaySound("LevelComplete");
    }
    */
    
    // StopSound va messo solo per le musiche che quindi vanno in loop (questo sotto andrà eliminato) 
    public void LevelCompleteStop()
    {
        AudioManager.Instance.StopSound("LevelComplete");
    }

}

