using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class GamewonEvent : UnityEvent<Team>{}

public class VictoryChecker : MonoBehaviour
{

    [SerializeField]
    private GameStarter gameRules;

    [SerializeField]
    private MultiPawnTile[] finalTiles;
    
    public GamewonEvent OnGameWon;

    private void Awake() {
        foreach (var tile in finalTiles)
        {
            tile.OnNewPawn += (pawn) => NewPawnEnterFinalTile(tile);
        }
    }

    private void NewPawnEnterFinalTile(MultiPawnTile tile){
        if (tile.PawnAmount < gameRules.PawnAmount)
            return;

        OnGameWon?.Invoke(tile.Pawn.PawnTeam);
    }

}
