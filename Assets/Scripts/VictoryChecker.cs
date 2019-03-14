using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryChecker : MonoBehaviour
{

    private int pawnAmount = 4;

    [SerializeField]
    private MultiPawnTile[] finalTiles;

    public Action<Team> GameWon;

    private void Awake() {
        foreach (var tile in finalTiles)
        {
            tile.OnNewPawnEnter += (pawn) => NewPawnEnterFinalTile(tile);
        }
    }

    private void NewPawnEnterFinalTile(MultiPawnTile tile){
        if (tile.PawnAmount != pawnAmount)
            return;

        GameWon?.Invoke(tile.Pawn.PawnTeam);
    }

}
