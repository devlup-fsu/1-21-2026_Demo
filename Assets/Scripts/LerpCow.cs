using UnityEngine;

public class LerpCow : MonoBehaviour
{
    public Transform ufo;          // Assign your UFO transform
    public float pullSpeed = 3f;   // How fast the cow moves toward the UFO
    

    public void PullTowardUFO()
    {
        if (ufo == null) return;

        // Distance check so it doesn't jitter when very close
        float dist = Vector3.Distance(transform.position, ufo.position);

        // Smooth movement toward UFO
        transform.position = Vector3.Lerp(
            transform.position,
            ufo.position,
            pullSpeed * Time.deltaTime
        );
    }
}


