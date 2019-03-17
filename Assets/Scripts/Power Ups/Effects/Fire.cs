using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : TileEffect
{
    [SerializeField]
    private TileInput inputHandler;
    private bool inputReady;
    private Tile newInput;

    public override EffectType Type => EffectType.Fire;

    private void Awake() {
        inputHandler.OnTileClicked += HandleInput; 
    }

    public override IEnumerator Execute(Tile trigger)
    {
        yield return StartCoroutine(WaitForValidInput());
        newInput.Pawn.SetToSpawn();
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
