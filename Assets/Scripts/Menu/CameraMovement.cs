using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
[SerializeField]private GameObject targetPawn;
private Vector3 offset;
private float distance;
private Vector3 pawnPrevPos, pawnMoveDir, standardCameraPosition;
public bool PawnIsMoving = false;

    private void Start()
    {
        standardCameraPosition = transform.position;
        FollowPawn(targetPawn);
    }
    public void FollowPawn (GameObject MovingPawn) 
    {
        targetPawn = MovingPawn;
        offset = (transform.position - new Vector3(0,30,0)) - targetPawn.transform.position;
        distance = offset.magnitude;
        pawnPrevPos = targetPawn.transform.position;
    }

    private void LateUpdate () 
    {
        if(PawnIsMoving)
        {
            pawnMoveDir = targetPawn.transform.position - pawnPrevPos;
            if (pawnMoveDir != Vector3.zero)
            {
                pawnMoveDir.Normalize();
                transform.position = targetPawn.transform.position - pawnMoveDir * distance;
                transform.position = transform.position + new Vector3(0,5,0);
                transform.LookAt(targetPawn.transform.position);
                pawnPrevPos = targetPawn.transform.position;
            }
        }
        else
        {
            ResetCamera();
        }
    }
    
    private void ResetCamera()
    {
        transform.position = standardCameraPosition;
    }
}
