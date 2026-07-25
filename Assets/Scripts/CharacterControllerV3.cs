using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterControllerV3 : MonoBehaviour
{
    public CharacterController controller;

    public float playerSpeed = 5.0f;
    private float jumpHeight = 1.5f;
    private float gravityValue = -9.81f;

    public InputActionReference moveAction; // Expects Vector2 or 1D Axis (float)
    public InputActionReference jumpAction; // Expects Button

    private Vector3 playerVelocity;
    private bool groundedPlayer;

    private void OnEnable()
    {
        moveAction.action.Enable();
        jumpAction.action.Enable();
    }

    private void OnDisable()
    {
        moveAction.action.Disable();
        jumpAction.action.Disable();
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;

        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = -2.0f;
        }

        // Read horizontal input
        float moveInput = moveAction.action.ReadValue<float>();
        Vector3 move = new Vector3(moveInput, 0, 0);

        move = Vector3.ClampMagnitude(move, 1f);

        // Move horizontally
        controller.Move(move * playerSpeed * Time.deltaTime);

        // Jump
        if (jumpAction.action.triggered && groundedPlayer)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        
        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}