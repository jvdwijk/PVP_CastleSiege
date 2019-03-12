using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : MonoBehaviour
{
    [SerializeField]
    private PawnMovement movement;
    private Team pawnTeam = 0;
    private TeamController teamController;

    public PawnMovement Movement => movement;

    public void Init(TeamController team){
        teamController = team;
        pawnTeam = teamController.CurrentTeam;
        movement.OnChangeLocation += ChangeTile;
    }

    public void GetHit(){
        SetToSpawn();
    }

    public void SetToSpawn(){
        movement.MovePawnTo(0);
    }

    private void ChangeTile(int newTileIndex, int oldTileIndex){
        var newTile = movement.Path[newTileIndex];
        var oldTile = movement.Path[oldTileIndex];

        oldTile.PawnLeave(this);
        newTile.PawnEnter(this);
    }
}
