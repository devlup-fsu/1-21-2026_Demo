using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UFOScript : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 4.0f;
    [SerializeField] private float smoothTime = 2.0f;
    [SerializeField] private float beamDist = 1.75f;
    private Vector3 targetVelocity;
    private Vector3 velocity = Vector3.zero;
    private Vector2 _input;
    public GameObject beam;
    private bool beamOn;
    private List<Rigidbody> cows = new List<Rigidbody>();
    //raycast variables
    private float beamRange = 10f;
    private string targetTag = "cow";
    
    //input function
    public void GetMovement(InputAction.CallbackContext context)
    {
        _input = context.ReadValue<Vector2>();
    }

    public void TractorBeam(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            beam.SetActive(true);
            beamOn = true;
        }
        else if (context.canceled)
        {
            beam.SetActive(false);
            beamOn = false;
        }
    }

   

    private void Update()
    {
        //give gravity back to cows outside the beam
        for (int i=cows.Count-1; i>=0; i--)
        {
            Rigidbody cow = cows[i];
            if (Vector3.Distance(transform.position, cow.transform.position)>beamDist||!beamOn)
            {
                cow.useGravity = true;
                cows.RemoveAt(i);
            }
        }
        if (beamOn)
        {
            //anti-gravity for cows inside the beam
            foreach (var cow in cows) cow.useGravity = false;
            //tractor beam raycast
            RaycastHit hit;
            if (Physics.Raycast(transform.position, Vector3.down, out hit, beamRange))
            {
                if (hit.collider.CompareTag(targetTag))
                {
                    //Debug.Log("Tractor beam hit: " + hit.collider.name);
                    hit.collider.GetComponent<LerpCow>().PullTowardUFO();
                    cows.Add(hit.collider.GetComponent<Rigidbody>());
                }
            }

            // Optional: visualize the ray
            Debug.DrawRay(transform.position, Vector3.down * beamRange, Color.green);
        }

        //movement
        Vector3 movement = (new Vector3(_input.x, 0f, _input.y))*moveSpeed;
        transform.position = Vector3.SmoothDamp(transform.position, transform.position + movement, ref velocity, smoothTime);

    }
}
