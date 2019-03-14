using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TileInput : MonoBehaviour
{
    [SerializeField]
    private LayerMask layerMask;

    public Action<Tile> OnTileClicked;

    private void Update()
    {
        InputUpdate();
    }

    private void InputUpdate(){
        if(Input.GetMouseButtonDown(0)){
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask)){
                Tile tile = hit.collider.GetComponent<Tile>();
                OnTileClicked?.Invoke(tile);
            }
        }
    }
}
