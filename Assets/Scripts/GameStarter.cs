using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStarter : MonoBehaviour
{
    [SerializeField]
    private TeamController[] teamsControllers;

    [SerializeField]
    private Turn[] turns;

    [SerializeField]
    private TurnManager turnManager;

    public int PlayerAmount {get; private set;} = 4;
    public int PawnAmount {get; private set;} = 4;
    public bool UseTimer {get; private set;} = false;

    public void StartGame() {
        if (PlayerAmount > turns.Length || PlayerAmount > teamsControllers.Length)
            throw new System.Exception("Too many players :(");

        for (int i = 0; i < PlayerAmount; i++)
        {
            teamsControllers[i].Init(PawnAmount);
            turnManager.AddTeam(turns[i]);
        }

        turnManager.NextTurn();
    }

    public void QuickStartGame(){
        PlayerAmount = 4;
        PawnAmount = 4;
        UseTimer = false;

        StartGame();
    }

    public void SetPawnAmount(float amount){
        PawnAmount = (int)amount;
    }

    public void SetPlayerAmount(float amount){
        PlayerAmount = (int)amount;
    }
    
    public void SetUseTimer(bool value){
        UseTimer = value;
    }
    

}
