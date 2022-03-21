using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathway : MonoBehaviour
{
    public Waypoint[] pathway;

    private void Awake()
    {
        Initialize();
    }

    [ContextMenu("Initialize")]
    private void Initialize()
    {
        // get waypoints
        pathway = gameObject.GetComponentsInChildren<Waypoint>();
    }
}
