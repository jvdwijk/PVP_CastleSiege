using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
[SerializeField]private GameObject targetPawn;
[SerializeField]private Vector3 offsetY; 
private float distance;
private Vector3 pawnPrevPos, pawnMoveDir, standardCameraPosition, offset;
private Quaternion standardCameraRotation;
public bool PawnIsMoving = false;

    private void Start()
    {
        standardCameraPosition = transform.position;
        standardCameraRotation = transform.rotation;
        FollowPawn(targetPawn);
    }
    public void FollowPawn (GameObject MovingPawn) 
    {
        targetPawn = MovingPawn;
        transform.position = new Vector3(transform.position.x, 6, transform.position.z);
        offset = transform.position - targetPawn.transform.position;
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
        transform.rotation = standardCameraRotation;
    }
}
