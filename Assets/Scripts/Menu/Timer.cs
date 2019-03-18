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
        turnManager.OnTurnChanged += StartTimer;
    }

    public void StartTimer(Turn turn)
    {
        CancelInvoke("Countdown");
        currentTimer = timerMax;
        timerText.text = currentTimer.ToString();
        InvokeRepeating("Countdown", 1f, 1f);
    }
    private void Countdown()
    {
        if(currentTimer > 0)
        {
            currentTimer--;
            timerText.text = currentTimer.ToString();
        }
        else{
            turnManager.NextTurn();
        }
    }
}
