using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class MOvementChecker : MonoBehaviour
{
    public Transform rayOrigin;
    public float rayLength = 1f;
    public Color rayColor = Color.red;
    private void OnDrawGizmos()
    {
        Ray ray = new Ray(rayOrigin.position, rayOrigin.forward);
        
        Debug.DrawRay(rayOrigin.position, rayOrigin.forward * rayLength, rayColor);
    }
}
