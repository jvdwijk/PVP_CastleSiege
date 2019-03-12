﻿using System.Collections;
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
    private Map map;

    private Pawn[] pawns;

    public Tile SpawnLocation { get{ return spawnLocation; }}
    public Team CurrentTeam { get{ return currentTeam; }}
    
    void Start(){
        Init(3);
    }
    public void Init(int pawnAmount = 4){
        SpawnPawns(pawnAmount);
    }

    public void SpawnPawns(int pawnAmount){
        pawns = new Pawn[pawnAmount];
        
        for (int i = 0; i < pawnAmount; i++)
        {
            pawns[i] = Instantiate(pawnPrefab);
            pawns[i].transform.SetParent(transform);
            pawns[i].Init(this);
            pawns[i].Movement.Map = map;
//            pawns[i].SetToSpawn(spawnLocation.TileIndex);
        }
    }
}
