using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CubePlacement : MonoBehaviour
{
    public GameObject ObjToMove;
    public LayerMask mask;
    public int LastPosX, LastPosZ;
    public float LastPosY;
    public Vector3 mousepos;
    public bool ismoving;
    private string gameObjName;
   
    public List<Transform> childrenToMove = new List<Transform>();

    public static event Action RebuildNavMesh;
    public Vector3 intitalPostion;
    void Update()
    {
        mousepos = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(mousepos);
        RaycastHit hit;

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, mask))
            {
                if (hit.collider.CompareTag("RedSeats")|| hit.collider.CompareTag("BlueSeats") )
                {
                    intitalPostion = hit.transform.position;
                    ismoving = true;
                    gameObjName = hit.collider.gameObject.name;
                    ObjToMove = hit.collider.gameObject;
                    ObjToMove.name = "Dragger";

                    // Clear the previous list and assign all children
                    childrenToMove.Clear();
                    foreach (Transform child in ObjToMove.transform)
                    {
                        childrenToMove.Add(child);
                    }
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        { 
            if(ObjToMove == null)
            {
                return;
            }
            ObjToMove.name = gameObjName;
            childrenToMove.Clear();
            float distanceMoved = Vector3.Distance(intitalPostion, ObjToMove.transform.position);
            if (distanceMoved > 1.0f)
            {
                RebuildNavMesh?.Invoke();
            }
            ObjToMove = null;
        }

        if (Input.GetMouseButton(0) && ObjToMove != null && ismoving)
        {
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, mask))
            {
                // Round hit point positions
                int PosX = (int)Mathf.Round(hit.point.x);
                int PosZ = (int)Mathf.Round(hit.point.z);

                // Constrain PosX and PosZ within the range of -5 to 5
                PosX = Mathf.Clamp(PosX, -2, 2);
                PosZ = Mathf.Clamp(PosZ, -5, 3);

                // Only update if there is a change in position
                if (PosX != LastPosX || PosZ != LastPosZ)
                {
                    LastPosX = PosX;
                    LastPosZ = PosZ;

                    // Set the new position for ObjToMove
                    Vector3 newPosition = new Vector3(PosX, LastPosY, PosZ);
                    ObjToMove.transform.position = newPosition;

                    // Perform raycast from each child to detect obstacles
                    foreach (Transform child in childrenToMove)
                    {
                        Ray childRay = new Ray(child.position, child.forward);
                        if (Physics.Raycast(childRay, out hit, 0.25f))
                        {
                            if (hit.collider.gameObject.name == "Seat")
                            {
                                ismoving = false; // Stop movement if Cube is hit
                                break;
                            }
                        }
                    }
                }
            }
        }
    }

}
