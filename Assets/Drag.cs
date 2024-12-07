using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{
    private Camera mainCamera;       // Reference to the main camera
    private bool isDragging = false; // Check if the object is being dragged
    private Vector3 offset;          // Offset between mouse and object position
    public Transform target;        // Reference to the object being dragged
    public List<Transform> pieces;   // List of positions for snapping
    public int currentPiecesNum;     // Index of the current piece position
    public bool returningToPosition = false; // Check if object is returning
    public float returnSpeed = 5f;   // Speed for smooth return to position
    public List<Vector3> piesesPosition = new List<Vector3>();
    void Start()
    {
        mainCamera = Camera.main;
        for (int i = 0; i < pieces.Count; i++)
        {
            piesesPosition.Add(pieces[i].position);
        }
    }

    void Update()
    {
        // Handle mouse input
        if (Input.GetMouseButtonDown(0))
        {
            StartDragging();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            StopDragging();
        }

        if (isDragging)
        {
            DragObject();
        }

        // Handle smooth return if needed
        if (returningToPosition== true )
        {
            SmoothReturnToOriginalPosition();
        }
    }

    void StartDragging()
    {
        Vector2 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

        if (hit.collider != null && hit.collider.CompareTag("Draggable"))
        {
            target = hit.transform;
            isDragging = true;
            currentPiecesNum = hit.transform.gameObject.GetComponent<Pieses>().piesesNum;
            offset = target.position - mainCamera.ScreenToWorldPoint(Input.mousePosition);
        }
    }

    void StopDragging()
    {
        isDragging = false;
        returningToPosition = true;
    }

    void DragObject()
    {
        if (target == null) return;

        Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        target.position = new Vector3(mousePosition.x + offset.x, mousePosition.y + offset.y, target.position.z);
    }

    void SmoothReturnToOriginalPosition()
    {
        if (target == null) return;

        // Smoothly move the object to its original position
        target.position = Vector3.MoveTowards(target.position, piesesPosition[currentPiecesNum], returnSpeed * Time.deltaTime);

        // Stop moving if the object reaches its target position
        if (Vector3.Distance(target.position, piesesPosition[currentPiecesNum]) < 0.01f)
        {
            returningToPosition = false;
        }
    }
}
