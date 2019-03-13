using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CLickInput : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out hit)){
                Tile tile = hit.collider.GetComponent<Tile>();
                
            }
        }
    }
}
