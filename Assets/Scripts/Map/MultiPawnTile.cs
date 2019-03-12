using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiPawnTile : Tile
{
    private List<Pawn> pawns = new List<Pawn>();
    public override Pawn Pawn => pawns[0];

    public override void PawnEnter(Pawn pawn)
    {
        if (pawns.Contains(pawn))
            return;

        pawns.Add(pawn);
    }

    public override void PawnLeave(Pawn pawn){
        if (!pawns.Contains(pawn))
            return;

        pawns.Remove(pawn);
    }
}
