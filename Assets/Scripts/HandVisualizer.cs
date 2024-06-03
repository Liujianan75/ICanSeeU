using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class HandVisualizer : MonoBehaviour
{
    private void Start()
    {
       UnityEngine.Debug.Log("hand spawned");
    }
    private void Update()
    {
        UnityEngine.Debug.Log($"hand position: {transform.position}");
    }
}
