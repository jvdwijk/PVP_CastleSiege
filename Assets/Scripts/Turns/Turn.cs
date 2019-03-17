using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn : MonoBehaviour
{
    [SerializeField]
    private Team team;

    [SerializeField]
    private TurnManager turnManager;

    [SerializeField]
    private TeamController teamController;

    [SerializeField]
    private TileInput input;

    private bool skipTurn = false;

    public Team Team => team;

    public int MoveAmount { get; private set; }

    private Dice dice = new Dice();

    public void StartTurn(){
        if (skipTurn)
        {
            skipTurn = false;
            turnManager.NextTurn();
            return;
        }

        MoveAmount = dice.Roll();
        input.OnTileClicked += SelectTile;
    }

    public void StopTurn(){
        MoveAmount = -1;
        input.OnTileClicked -= SelectTile;
    }
    
    private void SelectTile(Tile selectedTile){
        Pawn currentPawn = selectedTile?.Pawn;
        if(currentPawn == null)
            return;
        
        if(currentPawn.PawnTeam != team)
            return;

        currentPawn.Movement.MovePawn(MoveAmount);
        turnManager.NextTurn();
    }

    public void StipNextTurn(){
        skipTurn = true;
    }
}