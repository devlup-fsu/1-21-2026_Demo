using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class UFOScript : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    private Vector2 _input;

    public GameObject beam;
    private bool beamOn;
    
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
        //ufo movement
        Vector3 movement = new Vector3(_input.x, 0f, _input.y);
        transform.position += movement * moveSpeed * Time.deltaTime;
        
        //tractor beam raycast
        if (beamOn)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, Vector3.down, out hit, beamRange))
            {
                if (hit.collider.CompareTag(targetTag))
                {
                    //Debug.Log("Tractor beam hit: " + hit.collider.name);
                    hit.collider.GetComponent<LerpCow>().PullTowardUFO();
                }
            }

            // Optional: visualize the ray
            Debug.DrawRay(transform.position, Vector3.down * beamRange, Color.green);
        }
    }
}
