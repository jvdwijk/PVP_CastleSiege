using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PawnMovement : MonoBehaviour
{
    private int location = 0;
    
    public int Location => location; 
    
    public Map Map {get; set;}
    
    public Action<int> OnChangeLocation;

    public void MovePawn(int amount){
        //TODO animation!
        SetLocation(location + amount);
    }

    public void MovePawnTo(int tileLocation){
        //todo animation?
        SetLocation(tileLocation);
    }

    private void SetLocation(int tileLocation){
        transform.position = Map.GetTile(tileLocation).Location;
        location = tileLocation;
        OnChangeLocation?.Invoke(location);
    }
}
