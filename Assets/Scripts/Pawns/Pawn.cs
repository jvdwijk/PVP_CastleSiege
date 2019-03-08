using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : MonoBehaviour
{
    [SerializeField]
    private PawnMovement movement;
    private Team pawnTeam = 0;
    private TeamController teamController;


    public void Init(TeamController team){
        teamController = team;
        pawnTeam = teamController.CurrentTeam;
    }

    public void GetHit(){
        SetToSpawn(teamController.SpawnLocation);
    }

    public void SetToSpawn(int spawnPoint){
        movement.MovePawnTo(spawnPoint);
    }
}
