//Using newish InputSystem Example script from : docs.unity3d.com/6000.0/Documentation/ScriptReference/CharacterController.Move.html

using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    public CharacterController controller;
    private Vector3 playerVelocity;


    public InputActionReference moveAction; // expects Vector2
    public InputActionReference jumpAction; // expects Button
    public InputActionReference dashAction; //Shift run / dash

    void Update()
    {
        Vector2 input = moveAction.action.ReadValue<Vector2>();
        Vector3 move = new Vector3(input.x, 0, 0);
        move = Vector3.ClampMagnitude(move, 1f);
    }
}
