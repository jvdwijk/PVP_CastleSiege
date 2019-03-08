using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public Vector3 Location => transform.position;
    public int TileIndex{ get; private set; }
    public Pawn Pawn { get; private set; }

    public event Action<Pawn> OnNewPawn;

    public void SetIndex(int index){
        TileIndex = index;
    }

    public void SetPawn(Pawn pawn){
        Pawn = pawn;
        OnNewPawn?.Invoke(pawn);
    }

}
