﻿using System.Collections;
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

    //Questa è la musica che vi è nel menu iniziale(in pratica quando si deve premere su "go" o quando si gira per le impostazioni) 
    public void MainMenuSoundtrackPlay()
    {
        AudioManager.Instance.PlaySound("MainMenuSoundtrack");
    }
    // StopSound va messo solo per le musiche che quindi vanno in loop  
    public void MainMenuSoundtrackStop()
    {
        AudioManager.Instance.StopSound("MainMenuSoundtrack");
    }
    //é il suono di quando premi il tasto "go" nel main menu E di quando selezioni uno dei livelli (i cerchi neri con scritto il numero del livello)
    public void SelectedButtonPlay()
    {
        AudioManager.Instance.PlaySound("SelectedButton");
    }
    //é il suono di quando il giocatore finisce un livello e ritorna nella mappa di selezione livello, se è la prima volta che avviene il completamento di un livello allora all'icona circolare del livello compaiono delle seghettature e questo è il suono che fa  
    public void FinishLevelPlay()
    {
        AudioManager.Instance.PlaySound("FinishLevel");
    }
    //appena finisce il caricamento e si vede il livello vi è questo suono ad aprire la "cut scene" 
    public void StartCinematicPlay()
    {
        AudioManager.Instance.PlaySound("StartCinematic");
    }
    // appena finisce la "cut scene" iniziale e vi è la transizione tra telecamera "cinematografica" e quella che si usa in game vi è questo suono 
    public void EndCinematicPlay()
    {
        AudioManager.Instance.PlaySound("EndCinematic");
    }
    // 
    public void MovingPlayerPlay()
    {
        AudioManager.Instance.PlaySound("MovingPlayer");
    }




}

