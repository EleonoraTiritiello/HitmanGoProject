using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{

    private enum GameplayState
    {
        Setup,
        Waiting,
        CalculationPlayerAction,
        CalculationEnemyAction,
        PlayerAction,
        EnemyAction,
        LevelEnd
    }

    private GameplayState requestedGameplayState = GameplayState.Setup;
    private GameplayState currentGameplayState = GameplayState.Setup;

    private void Start()
    {
        requestedGameplayState = GameplayState.Waiting;
    }

    private void Update()
    {
        //UpdateCurrentState();

        //CaptureSetup();
    }

   /* private void FixedUpdate()
    {
        switch (requestedGameplayState)
        {
            case GameplayState.Waiting:
                if (currentGameplayState == GameplayState.Waiting)
                    break;

            case GameplayState.CalculationPlayerAction:
                if (currentGameplayState == GameplayState || currentGameplayState == GameplayState.CalculationEnemyAction)
                    break;

        }
    }*/

    static GameplayManager singleton;

    Animator GameplaySM;

    private void Awake()
    {
        if (singleton == null)
        {
            singleton = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            DestroyImmediate(gameObject);
        }
        Setup();
    }

    #region GameSm Trigger Delegate
    /// <summary>
    /// Delegato che gestisce gli eventi lanciati dall'esterno per triggerare il cambio di stato della GameStateMachine
    /// </summary>
    public delegate void GameplaySMTriggerDelegate();

    //public static GameSMTriggerDelegate Setup;

    public static GameplaySMTriggerDelegate GoToSetup;

    public static GameplaySMTriggerDelegate GoToWaiting;

    public static GameplaySMTriggerDelegate GoToOnCalculatingPlayerAction;

    public static GameplaySMTriggerDelegate GoToOnCalculatingEnemyAction;

    public static GameplaySMTriggerDelegate GoToPlayerAction;

    public static GameplaySMTriggerDelegate GoToEnemyAction;

    public static GameplaySMTriggerDelegate GoToLevelEnd;
    #endregion

    #region GamePlay Trigger Delegate
    public delegate void GamePlayTriggerDelegate();

    public static GamePlayTriggerDelegate Waiting;
    public static GamePlayTriggerDelegate CalculationAction;

    #endregion

    public static void Setup()
    {
        singleton.GameplaySM = singleton.GetComponent<Animator>();
    }
    private void OnEnable()
    {
        EventSetup();
    }
    /// <summary>
    /// Funzione che si occupa di iscriversi a N eventi in base alla tipologia di struttura.
    /// </summary>
    public static void EventSetup()
    {
        GoToSetup += singleton.HandleGoToSetup;
        GoToWaiting += singleton.HandeleGoToWaiting;
    }

    /// <summary>
    /// Funzione che gestisce l'evento GoToMainMenu
    /// </summary>
    void HandleGoToSetup()
    {
        if (!singleton.GameplaySM.GetCurrentAnimatorStateInfo(0).IsName("Setup"))
        {
            singleton.GameplaySM.SetTrigger("GoToSetup");
        }
    }

    void HandeleGoToWaiting()
    {

        if (!singleton.GameplaySM.GetCurrentAnimatorStateInfo(0).IsName("Waiting"))
        {
            singleton.GameplaySM.SetTrigger("GoToWaiting");
        }
    }

    private void OnDisable()
    {
        GoToSetup -= singleton.HandleGoToSetup;
        GoToWaiting -= singleton.HandeleGoToWaiting;
    }
}
