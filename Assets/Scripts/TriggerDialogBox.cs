using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class TriggerDialogBox : MonoBehaviour
{
    public string Tag = "Player"; //Only accepts colliders with the player tag


    //Need to create a Dialog Controller in the UI of the player prefab to display dialog
    private void OnTriggerEnter(Collider other)
    {
        //Need to include
    }

    private void OnTriggerExit(Collider other)
    {
        //Need to include
    }


    private void OnTriggerStay(Collider other)
    {
        //Need to include
    }
}
