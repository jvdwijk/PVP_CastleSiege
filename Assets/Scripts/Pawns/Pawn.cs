using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : MonoBehaviour
{
    
    private Team pawnTeam = Team.Elf;

    public void Init(Team team){
        pawnTeam = team;
    }

    public void GetHit(){
        SetToSpawn(0); //TODO work with teammanager
    }

    public void SetToSpawn(int spawnPoint){
        
    }
}
