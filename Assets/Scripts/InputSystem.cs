using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputSystem : MonoBehaviour
{
    private Rigidbody2D player;
    private PlayerInput playerInput;

    private bool isGrounded = true;

    private void Awake()
    {
        player = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();

        PlayerInputActions playerInputActions = new PlayerInputActions();
        playerInputActions.PlayerMovement.Enable();
        playerInputActions.PlayerMovement.Jump.performed += Jump;
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && isGrounded)
        {
            Debug.Log("Jumping!");
            player.AddForce(Vector3.up * 5f, ForceMode2D.Impulse);
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
