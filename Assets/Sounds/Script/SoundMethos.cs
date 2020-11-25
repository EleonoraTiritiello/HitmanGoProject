using System;
using UnityEngine;

namespace HitmanGO
{
    //[RequireComponent(typeof(AudioSource))]
    public class SoundMethos : MonoBehaviour
    {
        public Action Sound;

        private void Awake()
        {
            LevelComplete_OneCardPlay();
            CreationNodesPlay();
            MenuSoundtrackPlay();
            StartCinematicPlay();
            MovingPlayerPlay();
            DefeatPlayerPlay();
            TakeStonePlay();
            ThrowsStonePlay();
            InterrogativeSoundPlay();
            EnemyRotationPlay();
            
        }

        //questo è il suono che si sente quando il giocatore arriva alla fine del livello e compare 1 sola carta ( quindi si usa per tutti i livelli dall 1-1 all 1-5) 
        public void LevelComplete_OneCardPlay()
        {

            if(Sound != null)
            {
                LevelManger.GetInstance.CompleteLevel += LevelComplete_OneCardPlay;
                Sound = LevelComplete_OneCardPlay;

                AudioManager.Instance.PlaySound("LevelComplete_OneCard");
            }
            

        }
        // questo è quando i nodi (percorso che deve fare agente47) vengono creati ad inizio livello 
        public void CreationNodesPlay()
        {

            if(Sound != null)
            {
                LevelManger.GetInstance.PathCreator.CreatePath += CreationNodesPlay;
                Sound = CreationNodesPlay;

                AudioManager.Instance.PlaySound("CreationNodes");
            }

        }

        //Questa è la musica che vi è nel menu iniziale(in pratica quando si deve premere su "go", quando si gira per le impostazioni, quando si sceglie" la scatola" e per la selezione dei livelli) 
        public void MenuSoundtrackPlay()
        {
           float volumeScale;

            if(Sound == null)
            {
                GameManager.GetInstance.GoToMainMenu += MenuSoundtrackPlay;
                Sound = MenuSoundtrackPlay;
                float v = (volumeScale = 1);

                AudioManager.Instance.PlaySound("MenuSoundtrack");
            }
            else if (Sound != null)
            {
                GameManager.GetInstance.GoToMainMenu -= MainMenuSoundtrackStop;
                Sound = MainMenuSoundtrackStop;
                float v = (volumeScale = 0);

                AudioManager.Instance.StopSound("MenuSoundtrack");

            }

        }
        // StopSound va messo solo per le musiche che quindi vanno in loop  
        public void MainMenuSoundtrackStop()
        {
            AudioManager.Instance.StopSound("MenuSoundtrack");

        }
        //é il suono di quando premi i pulsanti: compreso il tasto "go" nel main menu, selezione di una scatola, di quando selezioni uno dei livelli (i cerchi neri con scritto il numero del livello)
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

            if (Sound != null)
            {
                LevelManger.GetInstance.PathCreator.StartDelayEvent += StartCinematicPlay;
                Sound = StartCinematicPlay;

                AudioManager.Instance.PlaySound("StartCinematic");
            }

        }
        // appena finisce la "cut scene" iniziale e vi è la transizione tra telecamera "cinematografica" e quella che si usa in game vi è questo suono 
        public void EndCinematicPlay()
        {
            AudioManager.Instance.PlaySound("EndCinematic");


        }
        // Quando la pedina si sposta da un nodo ad un altro produce questo suono
        public void MovingPlayerPlay()
        {

            if (Sound != null)
            {
                GameManager.GetInstance.Player.Move += MovingPlayerPlay;
                Sound = MovingPlayerPlay;

                AudioManager.Instance.PlaySound("MovingPlayer");
            }

        }
        //quando il giocatore passa davanti ad un nemico e la pedina di agente 47 cade a terra 
        public void DefeatPlayerPlay()
        {

            if (Sound != null)
            {
                GameManager.GetInstance.Player.Die += DefeatPlayerPlay;
                Sound = DefeatPlayerPlay;

                AudioManager.Instance.PlaySound("DefeatPlayer");
            }
        }
        //quando il giocatore uccide un nemico 
        public void DefeatOpponentPlay()
        {
            AudioManager.Instance.PlaySound("DefeatOpponent");


        }
        //quando il giocatore va sopra un noto su cui vi è un sasso e agente 47 lo prende in mano vi è questo suono
        public void TakeStonePlay()
        {

            if (Sound != null)
            {
                GameManager.GetInstance.Player.PickUpRock += TakeStonePlay;
                Sound = TakeStonePlay;

                AudioManager.Instance.PlaySound("TakeStone");
            }
        }
        // la musica che vi è nel livello 1-5 (esclusiva di questo livello)
        public void GameSoundtrack_1_5Play()
        {
            AudioManager.Instance.PlaySound("GameSoundtrack_1_5");
        }
        public void GameSoundtrack_1_5Stop()
        {
            AudioManager.Instance.StopSound("GameSoundtrack_1_5");
        }
        // Quando agente 47 lancia il sasso e questo colpisce per terra
        public void ThrowsStonePlay()
        {

            if (Sound != null)
            {
                GameManager.GetInstance.Player.ThrowRockEvent += ThrowsStonePlay;
                Sound = ThrowsStonePlay;

                AudioManager.Instance.PlaySound("ThrowsStone");
            }
        }
        // Il suono di quando uno dei nemici sente che è stato lanciato un sasso
        public void InterrogativeSoundPlay()
        {
            if (Sound != null)
            {
                foreach (EnemyController enemy in LevelManger.GetInstance.GetEnemiesArray())
                {
                    enemy.AlertEvent += InterrogativeSoundPlay;
                    enemy.Rotate += EnemyRotationPlay;
                }

                Sound = InterrogativeSoundPlay;

                AudioManager.Instance.PlaySound("InterrogativeSound");
            }
        }
        // quando il giocatore completa uno degli obbiettivi del livello e compare il simbolo rosso che si "stampa" sul foglio di carta (necessario solo nei primi 5 livelli)
        public void StampPlay()
        {
            AudioManager.Instance.PlaySound("Stamp");
        }
        // la musica che vi è in tutti i livelli (escluso il 1-5 che ne ha una propria) 
        public void GameSoundtrackPlay()
        {
            AudioManager.Instance.PlaySound("GameSoundtrack");
        }
        public void GameSoundtrackStop()
        {
            AudioManager.Instance.StopSound("GameSoundtrack");
        }
        // questo è il suono che si sente quando il giocatore arriva alla fine del livello 1-6 e compaiono 3 carte
        public void LevelComplete_ThreeCardsPlay()
        {
            AudioManager.Instance.PlaySound("LevelComplete_ThreeCards");
        }
        // Nel livello 1-6 c'è la possibilità che vengano sconfitti 3 nemici contemporaneamente, quando succede si sente questo suono
        public void ThreeEnemyDefeatedPlay()
        {
            AudioManager.Instance.PlaySound("ThreeEnemyDefeated");
        }
        // Quando un nemico sente un siono e si gira nella direzione di dove è stato lanciato il sasso
        public void EnemyRotationPlay()
        {
            if (Sound != null)
            {
                foreach (EnemyController enemy in LevelManger.GetInstance.GetEnemiesArray())
                {
                    enemy.AlertEvent += InterrogativeSoundPlay;
                    enemy.Rotate += EnemyRotationPlay;
                }

                Sound = EnemyRotationPlay;

                AudioManager.Instance.PlaySound("EnemyRotation");
            }
        }
    }
}
