using System;
using UnityEngine;

public class LerpCow : MonoBehaviour
{
    public Transform ufo;          // Assign your UFO transform
    public float pullSpeed = 3f;   // How fast the cow moves toward the UFO
    
    public void PullTowardUFO()
    {
        if (ufo == null) return;
        // Smooth movement toward UFO
        transform.position = Vector3.Lerp(
            transform.position,
            ufo.position,
            pullSpeed * Time.deltaTime
        );
    }
}


