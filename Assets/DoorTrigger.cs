using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public string Tag = "Player";

    public DoorController doorController;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == Tag)
        {
            doorController.Open();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == Tag)
        {
            doorController.Close();
        }
    }
}
