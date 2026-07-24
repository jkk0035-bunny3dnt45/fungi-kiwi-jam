using UnityEngine;

public class Trigger : MonoBehaviour
{
    //Upon collision with another GameObject, this GameObject will reverse direction
    private void OnTriggerEnter(Collider other)
    {
        print("Open Door");
    }

    private void OnTriggerExit(Collider other)
    {
        print("Close Door");
    }
}

