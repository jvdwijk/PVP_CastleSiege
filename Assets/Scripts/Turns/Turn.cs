using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn : MonoBehaviour
{
    [SerializeField]
    private Team team;

    [SerializeField]
    private TurnManager turnManager;

    [SerializeField]
    private TeamController teamController;

    [SerializeField]
    private TileInput input;

    [SerializeField]
    private List<TurnPhase> phases;

    private bool skipTurn = false;
    private Dice dice = new Dice();

    public Team Team => team;

    public int MoveAmount { get; private set; }

    public Tile MovedPawnDestination { get; set; }
    
    private void Awake() {
        foreach (var phase in phases)
        {
            phase.SetTurn(this);
        }
    }

    public void StartTurn(){
        if (skipTurn)
        {
            skipTurn = false;
            turnManager.NextTurn();
            return;
        }

        MoveAmount = dice.Roll();
        StartCoroutine(PlayTurn());
    }

    public IEnumerator PlayTurn(){

        foreach (var phase in phases)
        {
            yield return StartCoroutine(phase.PlayPhase());
        }
        turnManager.NextTurn();
    }

    public void StopTurn(){
        MoveAmount = -1;
    }

    public void StipNextTurn(){
        skipTurn = true;
    }
}