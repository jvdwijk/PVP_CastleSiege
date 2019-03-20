using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceRollPhase : TurnPhase
{

    [SerializeField]
    private int diceSideChangeAmount;
    
    [SerializeField]
    private float timePerDiceSide;

    [SerializeField]
    private Sprite[] diceSides;

    [SerializeField]
    private Button diceButton;
    [SerializeField]
    private Image diceImage;
    [SerializeField]
    private Timer timer;
    private bool hasRolled;
    
    private Dice dice = new Dice();

    public override IEnumerator PlayPhase()
    {
        diceButton.onClick.AddListener(RollDice);
        while (!hasRolled)
            yield return null;
        yield return StartCoroutine(DiceAnimation());
        
    }

    public override void ExitPhase(){
        diceButton.onClick.RemoveListener(RollDice);
        hasRolled = false;
    }

    private IEnumerator DiceAnimation(){
        for (int i = 0; i < diceSideChangeAmount; i++)
        {
            diceImage.sprite = diceSides[Random.Range(0, diceSides.Length)];
            yield return new WaitForSeconds(timePerDiceSide);
        }
        
        if (turn.MoveAmount < 0)
            yield break;
            diceImage.sprite = diceSides[turn.MoveAmount-1];
            timer.StartTimer();        
    }

    private void RollDice(){
        turn.MoveAmount = dice.Roll();
        hasRolled = true;
        diceButton.onClick.RemoveListener(RollDice);
    }
}
