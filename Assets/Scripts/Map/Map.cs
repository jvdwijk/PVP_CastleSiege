using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    private List<Tile> testedTiles = new List<Tile>();

    public Action<Tile> OnTileClicked;

    public Tile[] GetPath(Tile from, Tile to){
        testedTiles.Clear();
        var path = CalculatePath(from, to);
        if(path != null)
            path.Reverse();
        return path.ToArray();
    }

    private List<Tile> CalculatePath(Tile from, Tile to){

        List<Tile> path = null;
        foreach (var tile in from.ConnectedTiles)
        {
            if (testedTiles.Contains(tile))
                continue;

            testedTiles.Add(tile);
            if (tile == to)
            {
                path = new List<Tile>();
                path.Add(to);
                break;
            }
            
            
            var newPath = CalculatePath(tile, to);
            if (path == null || newPath != null && newPath.Count < path.Count)
                path = newPath;

        }

        if (path != null)
            path.Add(from);

        return path;
    }

}
