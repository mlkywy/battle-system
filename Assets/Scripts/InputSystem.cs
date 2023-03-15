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
    private float speed = 5f;

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

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && isGrounded)
        {
            Debug.Log("Jumping!");
            player.AddForce(Vector3.up * speed, ForceMode2D.Impulse);
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

    public void Movement()
    {
        Vector2 inputVector = playerInputActions.PlayerMovement.Movement.ReadValue<Vector2>();
        player.AddForce(new Vector3(inputVector.x, 0, inputVector.y), ForceMode2D.Impulse);
    }
}
