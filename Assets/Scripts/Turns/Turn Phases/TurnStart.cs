using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnStart : TurnPhase
{

    [SerializeField]
    private Animator startTurnAnimator;
    
    [SerializeField]
    private AnimationClip turnUIAnimation;

    [SerializeField]
    private Text turnText;

    [SerializeField]
    private float screenTime;

    private string suffix = "'s Turn";
    private const string inScreen = "InScreen";

    public override IEnumerator PlayPhase()
    {
        var team = turn.Team.ToString();
        turnText.text = $"{team}{suffix}";
        startTurnAnimator.SetBool(inScreen, true);
        yield return new WaitForSeconds(screenTime);
        startTurnAnimator.SetBool(inScreen, false);
        yield return new WaitForSeconds(turnUIAnimation.length);
    }

    public override void ExitPhase(){}
}
