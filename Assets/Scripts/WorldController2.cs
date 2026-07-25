using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;


public class WorldController2 : MonoBehaviour
{
    //private bool inWorld1 = true; //World 1 is the default world, also move to a globals script

    public Vector3 worldOffset = new Vector3(0f, -29.5f, 0f); //Vector 3 offset between world 1 and 2
    //public float spawnTolerance = 0.5f;

    public GameObject Player;

    public InputActionReference WorldSwitch;


    // Update is called once per frame
    void Update()
    {
        if (WorldSwitch.action.triggered)
        {
            Vector3 newPosition = Vector3.zero;

            if (Globals.inWorld1) //World 1 => World 2
            {
                newPosition = Player.transform.position + worldOffset;
                Globals.inWorld1 = false;
            }
            else //World 2 => World 1
            {
                newPosition = Player.transform.position - worldOffset;
                Globals.inWorld1 = true;
            }

            Swap(newPosition);
        }
    }

    void Swap(Vector3 position)
    {
        CharacterController controller = Player.GetComponent<CharacterController>();
        controller.enabled = false;
        Player.transform.position = position;
        controller.enabled = true;
    }
}
