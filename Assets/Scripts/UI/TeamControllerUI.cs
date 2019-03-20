using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeamControllerUI : MonoBehaviour
{
    [SerializeField]
    private Image[] pawns;

    [SerializeField]
    private Sprite defaultPawn, goalPawn;

    private int pawnAmount, pawnpoints;

    public void Init(TeamController teamController){
        pawnAmount = teamController.Pawns.Length;
        //teamController.FinalTile.OnNewPawn += AddPawnPoint; TODO put this action in Tile
    }

    private void UpdateUI(){
        for (int i = 0; i < pawns.Length; i++)
        {
            if(i > pawnAmount){
                pawns[i].enabled = false;
                continue;
            }
            pawns[i].sprite = i > pawnpoints ? defaultPawn : goalPawn;
        }
    }

    private void AddPawnPoint(){
        pawnpoints += 1;
    }
}
