using UnityEngine;
using UnityEngine.UIElements;

public class TriggerTeleport : MonoBehaviour
{
    public Transform Exit;
    public string Tag = "Player";

    /*
    //Moves this GameObject 2 units a second in the forward direction
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
    */

    void Start()
    {
        if (Exit == null)
        {
            Debug.LogError("Missng gameobject of Exit");
        }
    }

    //Upon collision with another GameObject, this GameObject will reverse direction
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == Tag)
        {
            CharacterController controller = other.GetComponent<CharacterController>();
            controller.enabled = false;
            other.transform.position = Exit.transform.position;
            controller.enabled = true;
        }
    }
}