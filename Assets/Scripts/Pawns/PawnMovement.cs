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
    
    public Tile[] Path {get; set;}
    
    public Action<int> OnChangeLocation;

    [ContextMenu("MoveThatPawn")]
    public void MoveThatPawn(){ //TODO for testing, remove when there is an input system
        MovePawn(25);
    }

    public void MovePawn(int amount){
        StartCoroutine(MovePawnRoutine(amount));
    }

    public void MovePawnTo(int tileLocation){
        transform.position = Path[tileLocation].Location;;
        SetLocation(tileLocation);
    }

    private void SetLocation(int tileLocation){
        location = tileLocation;
        OnChangeLocation?.Invoke(location);
    }

    private IEnumerator MovePawnRoutine(int moveAmount){
        var velocity = Vector3.zero;
        var moved = 0;
        for (int i = 0; i < moveAmount; i++){
            if (location + i >= Path.Length)
                break;

            Vector3 locationGoal = Path[location + i].Location;
                
            while ((transform.position - locationGoal).magnitude > 0.01f){     
                transform.position = Vector3.SmoothDamp(transform.position, locationGoal, ref velocity, pawnSpeed);
                yield return null;
            }
            transform.position = locationGoal;
            moved++;
        }
        SetLocation(location + moved);
    }
}
