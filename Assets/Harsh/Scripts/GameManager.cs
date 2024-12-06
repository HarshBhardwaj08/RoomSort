using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int totalSeats;
    public int currentSeats;
    public static event Action ActivateWinPanel;
    private void OnEnable()
    {
        MoveAI.AiReachedDestination += IncreaseCurrentSeats;
    }

    private void IncreaseCurrentSeats()
    {
        currentSeats++;
        if(currentSeats >= totalSeats)
        {
            ActivateWinPanel?.Invoke();
        }
    }

    private void OnDisable()
    {
        MoveAI.AiReachedDestination -= IncreaseCurrentSeats;
    }
}
