using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultTile : Tile
{
    private Pawn pawn;

    public int TileIndex{ get; private set; }
    public override Pawn Pawn => pawn;
    
    public event Action<Pawn> OnNewPawn;

    public override void PawnEnter(Pawn pawn)
    {
        if (this.pawn != null)
            this.pawn.GetHit();

        this.pawn = pawn;
        OnNewPawn?.Invoke(pawn);
    }

    public override void PawnLeave(Pawn pawn){
        this.pawn = null;
    }

}
