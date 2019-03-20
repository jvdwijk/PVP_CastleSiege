using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice : TileEffect
{
    [SerializeField]
    private TileInput inputHandler;
    [SerializeField]
    private TurnManager turnManager;
    private bool inputReady;
    private Tile newInput;

    public override EffectType Type => EffectType.Ice;

    private void Awake() {
        inputHandler.OnTileClicked += HandleInput; 
    }

    public override IEnumerator Execute(Tile trigger)
    {
        uiHandler.SetPowerupImage(icon);
        yield return StartCoroutine(WaitForValidInput());
        var turn = turnManager.GetTurn(newInput.Pawn.PawnTeam);
        turn.StipNextTurn();
        uiHandler.ResetImage();
    }

    private IEnumerator WaitForValidInput(){
        inputReady = false;
        while (!inputReady || newInput.Pawn == null)
        {
            yield return null;
        }
    }
    

    private void HandleInput(Tile tile){
        inputReady = true;
        newInput = tile;
    }
}
