using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class UFOScript : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 4.0f;
    [SerializeField] private float smoothTime = 2.0f;
    private Vector3 targetVelocity;
    private Vector3 velocity = Vector3.zero;
    private Vector2 _input;
    public void GetMovement(InputAction.CallbackContext context)
    {
        _input = context.ReadValue<Vector2>();
    }

    private void Update()
    {
        print(_input);
        Vector3 movement = (new Vector3(_input.x, 0f, _input.y))*moveSpeed;
        transform.position = Vector3.SmoothDamp(transform.position, transform.position + movement, ref velocity, smoothTime);
    }
}
