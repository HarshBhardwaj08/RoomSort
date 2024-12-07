using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Facebook.Unity;

public class FBinitialize : MonoBehaviour
{
    void Awake()
    {
        if (!FB.IsInitialized)
        {
            // Initialize the Facebook SDK
            FB.Init(OnInitComplete, OnHideUnity);
        }
        else
        {
            // Already initialized, activate the SDK
            FB.ActivateApp();
        }
    }

    private void OnInitComplete()
    {
        Debug.Log("FB Init completed");
        FB.ActivateApp();
    }

    private void OnHideUnity(bool isGameShown)
    {
        if (!isGameShown)
        {
            // Pause the game if Facebook is not visible
            Time.timeScale = 0;
        }
        else
        {
            // Resume the game if Facebook is visible
            Time.timeScale = 1;
        }
    }
}
