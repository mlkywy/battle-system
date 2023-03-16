using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputSystem : MonoBehaviour
{
    private Rigidbody2D player;
    private PlayerInput playerInput;
    private PlayerInputActions playerInputActions;

    private bool isGrounded = true;

    private float jumpSpeed = 10f;
    private float walkSpeed = 300f;

    private void Awake()
    {
        player = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();
        playerInputActions = new PlayerInputActions();

        playerInputActions.PlayerMovement.Enable();
        playerInputActions.PlayerMovement.Jump.performed += Jump;
    }

    private void FixedUpdate() 
    {
        Movement();
    }

    /// <summary>
    /// Handles player walking movement.
    /// </summary>
    private void Movement()
    {
        Vector2 inputVector = playerInputActions.PlayerMovement.Movement.ReadValue<Vector2>();
        player.velocity = new Vector2(inputVector.x * walkSpeed * Time.deltaTime, player.velocity.y);
    }

    /// <summary>
    /// Handles player jumping movement.
    /// </summary>
    private void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && isGrounded)
        {
            player.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D ground) 
    {
        isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D ground) 
    {
        isGrounded = false;
    }
}
