using System;
using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;

public class DynamicNavmesh : MonoBehaviour
{
    public NavMeshSurface navMeshSurface; // Reference to the NavMeshSurface component
    void Start()
    {
        // Initial bake
        navMeshSurface.BuildNavMesh();
    }
    private void OnEnable()
    {
        CubePlacement.RebuildNavMesh += UpdateNavMesh;
    }
    private void OnDisable()
    {
        CubePlacement.RebuildNavMesh -= UpdateNavMesh;
    }
    // Call this method when you want to update the NavMesh
    public void UpdateNavMesh()
    {
        navMeshSurface.BuildNavMesh();
    }
}
