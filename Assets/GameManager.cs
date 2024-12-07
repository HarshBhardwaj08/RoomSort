using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<Transform> pieces;
    public static event Action GameVictory;
    private int currentCompletedPieces = 0;
    public int totalPieces;
    private void OnEnable()
    {
        Pieses.PiesesAttached += PiesesAattachedSuccessfully;  
    }

    private void PiesesAattachedSuccessfully()
    {
      currentCompletedPieces++;
        if(currentCompletedPieces >= totalPieces)
        {
            GameVictory?.Invoke();
        }
    }

    private void OnDisable()
    {
        Pieses.PiesesAttached -= PiesesAattachedSuccessfully;
    }
}
