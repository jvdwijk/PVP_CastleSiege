using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn : MonoBehaviour
{
    [SerializeField]
    private Team team;

    public Team Team => team;

    public int MoveAmount { get; private set; }

    private Dice dice = new Dice();

    public void StartTurn(){
        MoveAmount = dice.Roll();

        //TODO implement turn logic
        
    }

    public void StopTurn(){
        MoveAmount = -1;
    }
    
}
