using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private TurnManager turnManager;
    [SerializeField] private Text timerText;
    public int timerMax;
    [SerializeField] private int currentTimer;

    private void Awake()
    {
        //if(true) //TODO add a check for game settings 
        turnManager.OnTurnChanged += StartTimer;
    }

    public void StartTimer(Turn turn)
    {
        CancelInvoke("Countdown");
        currentTimer = timerMax;
        timerText.text = "0:" + currentTimer.ToString();
        InvokeRepeating("Countdown", 1f, 1f);
    }
    private void Countdown()
    {
        if(currentTimer > 0)
        {
        currentTimer--;
        timerText.text = "0:" + currentTimer.ToString();
        }
        else{
            turnManager.NextTurn();
        }
    }
}
