using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TurnPhase : MonoBehaviour
{
    protected Turn turn;

    public void SetTurn(Turn turn){
        this.turn = turn;
    }

    public abstract IEnumerator PlayPhase();
    public abstract void ExitPhase();
}
