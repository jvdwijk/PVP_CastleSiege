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
    private Coroutine phaseRoutine;
    
    public TurnPhase Phase { get; private set; }

    public Team Team => team;

    public int MoveAmount { get; set; }

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

        StartCoroutine(PlayTurn());
    }

    public IEnumerator PlayTurn(){

        foreach (var phase in phases)
        {
            Phase = phase;
            phaseRoutine = StartCoroutine(phase.PlayPhase());
            yield return phaseRoutine;
            Phase.ExitPhase();
        }
        turnManager.NextTurn();
    }

    public void StopTurn(){
        MoveAmount = -1;
        Phase.ExitPhase();
        StopCoroutine(phaseRoutine);
    }

    public void StipNextTurn(){
        skipTurn = true;
    }
}