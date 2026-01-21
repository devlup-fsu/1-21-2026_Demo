using System;
using UnityEngine;

public class LerpCow : MonoBehaviour
{
    public Transform ufo;          // Assign your UFO transform
    [HideInInspector] public Rigidbody rb;
    public float pullSpeed = 3f;   // How fast the cow moves toward the UFO

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void PullTowardUFO()
    {
        if (ufo == null) return;

       // if (rb != null)
            //rb.useGravity = false;

        // Distance check so it doesn't jitter when very close
      //  float dist = Vector3.Distance(transform.position, ufo.position);

        // Smooth movement toward UFO
        transform.position = Vector3.Lerp(
            transform.position,
            ufo.position,
            pullSpeed * Time.deltaTime
        );
    }
}


