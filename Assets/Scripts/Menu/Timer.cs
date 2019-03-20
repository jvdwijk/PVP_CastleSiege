using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private TurnManager turnManager;
    [SerializeField] 
    private Text timerText;
    private int currentTimer;
    public int timerMax;

    private void Awake()
    {
        turnManager.OnTurnChanged += (turn) => StopTimer();
    }

    public void StartTimer()
    {
        StopTimer();
        InvokeRepeating(nameof(Countdown), 1f, 1f);
    }

    public void StopTimer(){
        CancelInvoke(nameof(Countdown));
        currentTimer = timerMax;
        timerText.text = currentTimer.ToString();
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
