using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;


public class WorldController2 : MonoBehaviour
{
    private bool inWorld1 = true; //World 1 is the default world

    private Vector3 worldOffset = new Vector3(0f, -29f, 0f); //Vector 3 offset between world 1 and 2


    public GameObject Player;

    public GameObject MarkerWorld1;
    public GameObject MarkerWorld2;

    public InputActionReference WorldSwitch;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (WorldSwitch.action.triggered)
        {
            Vector3 newPosition = Vector3.zero;

            if (inWorld1) //World 1 => World 2
            {
                newPosition = Player.transform.position + worldOffset;
                inWorld1 = false;
            }
            else //World 2 => World 1
            {
                newPosition = Player.transform.position - worldOffset;
                inWorld1 = true;
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
