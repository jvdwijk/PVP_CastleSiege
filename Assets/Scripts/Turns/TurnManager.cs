using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    [SerializeField]
    private Turn[] startTurns;

    private Dictionary<Team, Turn> turns = new Dictionary<Team, Turn>();
    
    public Turn CurrentTurn { get; private set;}

    public event Action<Turn> OnTurnChanged;

    private void Awake() {
        foreach (var turn in startTurns){
            if (turn)
                AddTeam(turn);
        }
        NextTurn();
    }

    public void AddTeam(Turn turn){
        var team = turn.Team;
        if (turns.ContainsKey(team))
            return;

        turns.Add(team, turn);
    }

    public void RemoveTeam(Team team){
        if (turns.ContainsKey(team))
            return;

        turns.Remove(team);
    }

    public Turn GetTurn(Team team){
        if(!turns.ContainsKey(team))
            return null;

        return turns[team];
    }

    public void SetTurn(Team team){

        if (!turns.ContainsKey(team))
            return;

        CurrentTurn?.StopTurn();

        CurrentTurn = turns[team];

        CurrentTurn?.StartTurn();

        OnTurnChanged?.Invoke(CurrentTurn);
    }

    public void NextTurn(){
        
        Team nextTurn;
        if (GetNextAvailibleTeam(out nextTurn)) {
            SetTurn(nextTurn);
            return;
        }

        Debug.LogError("No other team available!");
    }

    private bool GetNextAvailibleTeam(out Team nexTeam){
        var values = Enum.GetValues(typeof(Team));
        var currentTeamNumber = CurrentTurn ? (int)CurrentTurn.Team : -1;

        for (int i = 0; i < values.Length; i++)
        {
            currentTeamNumber++;
            currentTeamNumber = (int)Mathf.Repeat(currentTeamNumber, values.Length);

            var newTeam = (Team)currentTeamNumber;

            if (!turns.ContainsKey(newTeam))
                continue;

            nexTeam = newTeam;
            return true;
        }
        nexTeam = 0;
        return false;
    }
}


