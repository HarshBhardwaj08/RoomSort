using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveAI : MonoBehaviour
{
    public Transform destination;     
    public NavMeshAgent agent;        
    public float checkInterval = 1f;  // Interval to check the path (in seconds)
    public string seatName;
    private bool isPathClear = false;
    public Animator animator;
    public static event Action AiReachedDestination;
    void Start()
    {
        // Start the path-checking coroutine
        StartCoroutine(CheckPath());
    }
    public void SetDestination(Transform destination)
    {
        this.destination = destination;
    }
    private  IEnumerator CheckPath()
    {
        while (!isPathClear)
        {
            yield return new WaitForSeconds(checkInterval);

            // Create a new path object to store the path
            NavMeshPath path = new NavMeshPath();

            // Calculate the path from the agent's position to the destination
            if (agent.CalculatePath(destination.position, path))
            {
                // Check if the path is complete and not blocked
                if (path.status == NavMeshPathStatus.PathComplete)
                {
                    // Path is clear; start moving towards the destination
                    isPathClear = true;
                    agent.SetDestination(destination.position);
                }
                else
                {
                    // Path is blocked; keep checking
                    isPathClear = false;
                    agent.ResetPath(); // Stop any movement
                }
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == seatName)
        {
            // Reposition the AI to the top of the seat it collided with
            animator.SetTrigger("Sit");
            transform.rotation = Quaternion.Euler(0, 0, 0);
            this.gameObject.transform.SetParent(destination.transform);
            Vector3 seatTopPosition = destination.transform.position; // Adjust height as needed
            seatTopPosition = new Vector3(seatTopPosition.x, 0.1f, seatTopPosition.z);
            transform.position = seatTopPosition;
            collision.gameObject.GetComponent<Collider>().isTrigger = true;
            // Update seat tag and remove it from the list
            collision.gameObject.tag = "SittedSeats";
            AiReachedDestination?.Invoke();
            agent.enabled = false;
            this.enabled = false;
        }
    }
}
