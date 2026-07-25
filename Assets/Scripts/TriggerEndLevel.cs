using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class TriggerEndLevel : MonoBehaviour
{
    public string Tag = "Player"; //Only accepts colliders with the player tag


    //Key interaction
    public InputActionReference Interact;
    public GameObject KeyBindIco;


    //Upon collision with another GameObject, this GameObject will reverse direction
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == Tag)
        {
            KeyBindIco.SetActive(true); //Display the keybind ico
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == Tag)
        {
            KeyBindIco.SetActive(false); //Hide the keybind ico
        }
    }

    //If the player is inside the trigger box and presses the associated key bind
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == Tag)
        {
            if (Interact.action.triggered)
            {
                //Should use a scene manager to switch levels
                print("Level end");
            }
        }
    }
}
