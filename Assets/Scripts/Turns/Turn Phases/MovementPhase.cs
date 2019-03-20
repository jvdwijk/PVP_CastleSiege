using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPhase : TurnPhase
{

    [SerializeField]
    private TileInput input;

    private Pawn selectedPawn;

    public override IEnumerator PlayPhase()
    {
        input.OnTileClicked += TileClicked;
        selectedPawn = null;
        while(selectedPawn == null){
            yield return null;
        }
        input.OnTileClicked -= TileClicked;
        yield return selectedPawn.Movement.MovePawn(turn.MoveAmount);
        turn.MovedPawnDestination = selectedPawn.Movement.CurrentTile;
    }

    private void TileClicked(Tile selectedTile){
        Pawn currentPawn = selectedTile?.Pawn;
        if(currentPawn == null)
            return;
        
        if(currentPawn.PawnTeam != turn.Team)
            return;

        selectedPawn = currentPawn;
    }

    public override void ExitPhase(){
        input.OnTileClicked -= TileClicked;
    }


}
