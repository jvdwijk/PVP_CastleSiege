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

    public Tile CurrentTile => Path[location];
    
    public Action<int, int> OnChangeLocation;

    public Coroutine MovePawn(int amount, Action destinationReached = null){
        return StartCoroutine(MovePawnRoutine(amount, destinationReached));
    }

    public void MovePawnTo(int tileLocation){
        transform.position = Path[tileLocation].Location;;
        SetLocation(tileLocation);
    }

    private void SetLocation(int tileLocation){
        
        var oldLocation = location;
        location = tileLocation;
        
        OnChangeLocation?.Invoke(location, oldLocation);
    }

    private IEnumerator MovePawnRoutine(int moveAmount, Action destinationReached = null){
        var velocity = Vector3.zero;
        var moved = 0;
        for (int i = 1; i < moveAmount+1; i++){
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
        destinationReached?.Invoke();
    }
}
