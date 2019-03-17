using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectPhase : TurnPhase
{
    public override IEnumerator PlayPhase()
    {
        yield return StartCoroutine(turn.MovedPawnDestination.RunEffects());
    }
}
