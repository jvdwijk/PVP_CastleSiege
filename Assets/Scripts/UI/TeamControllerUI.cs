using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeamControllerUI : MonoBehaviour
{
    [SerializeField]
    private Text teamTitle;

    [SerializeField]
    private Image[] pawns;

    [SerializeField]
    private Sprite defaultPawn, goalPawn;

    private int pawnAmount, pawnPoints;

    public void Init(TeamController teamController){
        pawnAmount = teamController.Pawns.Length;
        teamController.FinalTile.OnNewPawn += AddPawnPoint;

        teamTitle.text = teamController.CurrentTeam.ToString();
        UpdateUI();
    }

    private void UpdateUI(){
        for (int i = 0; i < pawns.Length; i++)
        {
            if(i > pawnAmount - 1){
                pawns[i].gameObject.SetActive(false);
                continue;
            }
            pawns[i].sprite = i > pawnPoints - 1 ? defaultPawn : goalPawn;
        }
    }

    private void AddPawnPoint(Pawn pawn){
        pawnPoints += 1;

        UpdateUI();
    }
}
