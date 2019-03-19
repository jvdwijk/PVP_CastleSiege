using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnFacing : MonoBehaviour
{

    private Vector2 focusPoint;

    private void Update()
    {
        transform.LookAt(new Vector3(focusPoint.x, transform.position.y, focusPoint.y));
    }
}
