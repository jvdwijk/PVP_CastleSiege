using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PawnMovement : MonoBehaviour
{
    [SerializeField]
    private float pawnSpeed = 0.3f;

    private int location = 0;
    
    public int Location => location; 
    
    public Map Map {get; set;}
    
    public Action<int> OnChangeLocation;

    [ContextMenu("MoveThatPawn")]
    public void MoveThatPawn(){ //TODO for testing, remove when there is an input system
        MovePawn(3);
    }

    public void MovePawn(int amount){
        StartCoroutine(MovePawnRoutine(amount));
    }

    public void MovePawnTo(int tileLocation){
        transform.position = Map.GetTile(tileLocation).Location;;
        SetLocation(tileLocation);
    }

    private void SetLocation(int tileLocation){
        location = tileLocation;
        OnChangeLocation?.Invoke(location);
    }

    private IEnumerator MovePawnRoutine(int moveAmount){
        var velocity = Vector3.zero;

        for (int i = 0; i < moveAmount; i++){
            Vector3 locationGoal = Map.GetTile(location + i).Location;
                
            while ((transform.position - locationGoal).magnitude > 0.01f){     
                transform.position = Vector3.SmoothDamp(transform.position, locationGoal, ref velocity, pawnSpeed);
                yield return null;
            }
            transform.position = locationGoal;
        }
        SetLocation(location + moveAmount);
    }
}
