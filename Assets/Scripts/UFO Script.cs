using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class UFOScript : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    private Vector2 _input;
    public void GetMovement(InputAction.CallbackContext context)
    {
        _input = context.ReadValue<Vector2>();
    }

    private void Update()
    {
        print(_input);
        Vector3 movement = new Vector3(_input.x, 0f, _input.y);
        transform.position += movement * moveSpeed * Time.deltaTime;
    }
}
