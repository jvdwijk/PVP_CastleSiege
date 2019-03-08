using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    
    [SerializeField]
    private Tile[] tiles;

    [SerializeField]
    private bool drawGizmoz;

    public Action OnTileClicked;

    private void Awake() {
        for (int i = 0; i < tiles.Length; i++)
        {
            tiles[i].SetIndex(i);
        }
    }

    private void OnDrawGizmos() {
        if (!drawGizmoz)
            return;
        for (int i = 1; i < tiles.Length; i++)
        {
            var tile = GetTile(i);

            if (!tile)
                return;
            Gizmos.color = Color.blue;
            Gizmos.DrawSphere(tile.Location, 0.5f);

            var nextTile = GetTile(i+1);
            if (!nextTile)
                return;

            Gizmos.color = Color.red;
            Gizmos.DrawLine(tile.Location, nextTile.Location);
        }
    }

    [ContextMenu("Update Map")]
    private void UpdateMap(){
        tiles = GetComponentsInChildren<Tile>();
    }

    public Tile GetTile(int index){
        if (index >= tiles.Length)
            return null;

        return tiles[index];
    }

}
