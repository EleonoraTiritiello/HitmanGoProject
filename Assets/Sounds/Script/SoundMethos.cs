using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMethos : MonoBehaviour
{
    //questo è il suono che si sente quando il giocatore arriva alla fine del livello e compare 1 sola carta ( quindi si usa per tutti i livelli dall 1-1 all 1-5) 
    public void LevelCompletePlay() 
    {
        AudioManager.Instance.PlaySound("LevelComplete");
    }
    // questo è quando i nodi (percorso che deve fare agente47) vengono creati ad inizio livello 
    public void CreationNodesPlay()
    {
        AudioManager.Instance.PlaySound("CreationNodes");
    }

    //
    public void CreationNodesPlay()
    {
        AudioManager.Instance.PlaySound("CreationNodes");
    }



    // StopSound va messo solo per le musiche che quindi vanno in loop (questo sotto andrà eliminato) 
    public void LevelCompleteStop()
    {
        AudioManager.Instance.StopSound("LevelComplete");
    }

}

