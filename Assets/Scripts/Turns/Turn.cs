using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn : MonoBehaviour
{
    [SerializeField]
    private Team _team;

    public Team Team => _team;

    public int MoveAmount { get; private set; }

    public void StartTurn(){
        //TODO implement turn logic
    }

    public void StopTurn(){
    }
    
}
