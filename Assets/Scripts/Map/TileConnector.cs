using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class TileConnector : MonoBehaviour
{
    [ContextMenu("Connect Tiles")]
    public void Connect(){
        Tile firstTile = null;
        Tile lastTile = null;
        Tile tile = null;
        for (int i = 0; i < transform.childCount; i++)
        {
            var newTile = transform.GetChild(i).GetComponent<Tile>();

            if (!newTile)
                continue;

            newTile.RemoveAllTiles();
            lastTile = newTile;

            if (!tile)
            {
                tile = newTile;
                firstTile = newTile;
                continue;
            }

            tile.AddConnection(newTile);
            tile = newTile;

            EditorUtility.SetDirty(newTile);
        }
        lastTile.AddConnection(firstTile);
        EditorUtility.SetDirty(lastTile);

        EditorSceneManager.MarkSceneDirty(lastTile.gameObject.scene);
    }

    [ContextMenu("Reset Tiles")]  
    public void ResetTiles(){
        for (int i = 0; i < transform.childCount; i++)
        {
            var tile = transform.GetChild(i).GetComponent<Tile>();

            if (!tile)
                continue;

            tile.RemoveAllTiles();
        }
    }
}
