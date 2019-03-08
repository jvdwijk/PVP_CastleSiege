using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    [SerializeField]
    private Turn[] _startTurns;

    private Dictionary<Team, Turn> _turns = new Dictionary<Team, Turn>();
    
    public Turn CurrentTurn { get; private set;}

    public event Action<Turn> OnTurnChanged;

    private void Awake() {
        foreach (var turn in _startTurns){
            if (turn)
                AddTeam(turn);
        }
    }

    public void AddTeam(Turn turn){
        var team = turn.Team;
        if (_turns.ContainsKey(team))
            return;

        _turns.Add(team, turn);
    }

    public void RemoveTeam(Team team){
        if (_turns.ContainsKey(team))
            return;

        _turns.Remove(team);
    }

    public Turn GetTurn(Team team){
        if(!_turns.ContainsKey(team))
            return null;

        return _turns[team];
    }

    public void SetTurn(Team team){

        if (!_turns.ContainsKey(team))
            return;

        CurrentTurn?.StopTurn();

        CurrentTurn = _turns[team];

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

            if (!_turns.ContainsKey(newTeam))
                continue;

            nexTeam = newTeam;
            return true;
        }
        nexTeam = 0;
        return false;
    }
}


