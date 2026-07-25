using UnityEngine;
using UnityEngine.InputSystem;

public class TriggerTeleport : MonoBehaviour
{
    public Transform TerminationPoint; //Termination position of the dimesntion teleport
    public string Tag = "Player"; //Only accepts colliders with the player tag
    public bool isBiDirectional = true; //The Teleport can be used in both directions


    //Key interaction
    public InputActionReference Interact;
    public GameObject KeyBindIco;

    private bool playerInTrigger = false;
    private Collider currentCollider;

    //Upon collision with another GameObject, this GameObject will reverse direction
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == Tag && isBiDirectional)
        {
            KeyBindIco.SetActive(true); //Display the keybind ico
            playerInTrigger = true;
            currentCollider = other;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == Tag && isBiDirectional)
        {
            KeyBindIco.SetActive(false); //Hide the keybind ico
            playerInTrigger = false;
            currentCollider = null;
        }
    }

    private void OnEnable()
    {
        if (Interact != null)
            Interact.action.performed += OnInteractPerformed;
    }

    private void OnDisable()
    {
        if (Interact != null)
            Interact.action.performed -= OnInteractPerformed;
    }

    //If the player is inside the trigger box and presses the associated key bind
    private void OnInteractPerformed(InputAction.CallbackContext ctx)
    {
        if (!playerInTrigger) return;
        if (currentCollider == null) return;

        GameData.inOverWorld = !GameData.inOverWorld;

        //print("Interact.action.triggered");
        CharacterController controller = currentCollider.GetComponent<CharacterController>();
        controller.enabled = false;
        currentCollider.transform.position = TerminationPoint.transform.position;
        controller.enabled = true;

        playerInTrigger = false;
        currentCollider = null;
    }
}