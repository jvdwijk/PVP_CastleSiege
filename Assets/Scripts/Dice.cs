using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Dice
{
    private Random random;

    public int Sides { get; private set; }

    public Dice(int sides = 6)
    {
        if(sides < 0)
            sides = 6;

        Sides = sides;
    }

    public int Roll() {
        return Random.Range(1, Sides+1);;
    }

    public int[] Roll(int amount){
        List<int> results = new List<int>();
        for (int i = 0; i < amount; i++)
        {
            results.Add(Roll());
        }
        return results.ToArray();
    }

}
