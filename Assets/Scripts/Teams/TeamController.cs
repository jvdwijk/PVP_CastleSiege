using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamController : MonoBehaviour
{
    [SerializeField]
    private Pawn pawnPrefab;
    [SerializeField]
    private Team currentTeam;
    [SerializeField]
    private Tile spawnLocation;
    [SerializeField]
    private Tile finalTile;
    [SerializeField]
    private Map map;
    private Pawn[] pawns;
    private Tile[] path;
    
    public Tile SpawnLocation { get{ return spawnLocation; }}
    public Team CurrentTeam { get{ return currentTeam; }}
    
    public void Init(int pawnAmount = 4){
        path = map.GetPath(spawnLocation, finalTile);
        SpawnPawns(pawnAmount);
    }

    public void SpawnPawns(int pawnAmount){
        pawns = new Pawn[pawnAmount];
        
        for (int i = 0; i < pawnAmount; i++)
        {
            pawns[i] = Instantiate(pawnPrefab);
            pawns[i].transform.SetParent(transform);
            pawns[i].Init(this);
            pawns[i].Movement.Path = path;
            pawns[i].SetToSpawn();
        }
    }

    public void SendAllBack(){
        for (int i = 0; i < pawns.Length; i++)
        {
            pawns[i].SetToSpawn();
        }
    }
}
