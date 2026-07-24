using UnityEngine;
using UnityEngine.InputSystem;

public class Door : MonoBehaviour
{

    public Animator animator;
    public InputActionReference OpenSwitch;
    public InputActionReference CloseSwitch;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (OpenSwitch.action.triggered)
        {
            animator.SetTrigger("Open");
        }

        if (CloseSwitch.action.triggered)
        {
            animator.SetTrigger("Close");
        }
    }
}
