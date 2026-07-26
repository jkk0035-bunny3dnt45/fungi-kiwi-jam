//Using newish InputSystem Example script from : docs.unity3d.com/6000.0/Documentation/ScriptReference/CharacterController.Move.html

using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterControllerType1 : MonoBehaviour
{

    public bool isPlayerImmune = true;

    public float playerSpeed = 5.0f;
    private float jumpHeight = 1.5f;
    private float gravityValue = -9.81f;
    //private float sprintMultiplier = 10f;


    public CharacterController controller;
    public Animator animator;
    private Vector3 playerVelocity;
    private bool groundedPlayer;


    public InputActionReference moveAction; // expects Vector2
    public InputActionReference jumpAction; // expects Button
    //public InputActionReference dashAction; //Shift run / dash



    //Commented cause i forget why these are declared for
    /*
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
    */

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        // Read input
        Vector2 input = moveAction.action.ReadValue<Vector2>();
        animator.SetBool("IsWalking", input.magnitude > 0.01f);
        if (input.x != 0)
        {
            Vector3 scale = animator.transform.localScale;
            scale.x = Mathf.Sign(input.x) * Mathf.Abs(scale.x);
            animator.transform.localScale = scale;
        }
        Vector3 move = new Vector3(input.x, 0, 0);
        move = Vector3.ClampMagnitude(move, 1f);

        //Rotates the Parent object causing child camera object to rotate
        /*
        if (move != Vector3.zero)
        {
            transform.forward = move;
        }
        */        

        // Jump
        if (jumpAction.action.triggered && groundedPlayer)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -2.0f * gravityValue);
        }


        playerVelocity.y += gravityValue * Time.deltaTime; //Gravity

        // Combine horizontal and vertical movement
        Vector3 finalMove = (move * playerSpeed) + (playerVelocity.y * Vector3.up);
        controller.Move(finalMove * Time.deltaTime);
    }
}
