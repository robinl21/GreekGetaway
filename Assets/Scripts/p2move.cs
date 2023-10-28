using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class p2move : MonoBehaviour
{
    private PlayerControls input = null; // set from PlayerControls InputMap in scripts
    private Vector2 moveVector = Vector2.zero;
    private Rigidbody2D rb = null; // attach velocity to move
    private float moveSpeed = 10f;

    private void Awake()
    {
        input = new PlayerControls();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        input.Enable();
        // attaches these functions to callback when movement is performed/cancelled
        input.P2.Movement.performed += OnMovementPerformed;
        input.P2.Movement.canceled += OnMovementCancelled;
    }

    private void OnDisable()
    {
        // just to make it clean so that when object is not loaded we don't accidentally trigger movement
        input.Disable();
        // p1's inputs are w,a,s,d as set in PlayerControls input map, so when w,a,s,d hit: we trigger these functions!
        input.P2.Movement.performed -= OnMovementPerformed;
        input.P2.Movement.canceled -= OnMovementPerformed;
    }
    
    private void FixedUpdate()
    {
        rb.velocity = moveVector * moveSpeed;
    }

    //meat of the movement code: 
    private void OnMovementPerformed(InputAction.CallbackContext value) 
    {
        // InputAction.CallbackContext value gives Vector2 based on direction, set by PlayerControls InputMap
        // left is [-1, 0] for ex
        moveVector = value.ReadValue<Vector2>();
    }

    private void OnMovementCancelled(InputAction.CallbackContext value)
    {   // stops player
        moveVector = Vector2.zero;
    }
}
