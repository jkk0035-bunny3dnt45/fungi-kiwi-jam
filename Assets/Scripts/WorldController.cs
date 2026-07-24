using UnityEngine;
using UnityEngine.InputSystem;

public class WorldController : MonoBehaviour
{

    public GameObject PlayerWorld1;
    public GameObject PlayerWorld2;
    public InputActionReference WorldSwitch;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayerWorld1.SetActive(true);
        PlayerWorld2.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        if (WorldSwitch.action.triggered)
        {
            print("Swap");
            SwapWorlds();
        }
    }


    void SwapWorlds()
    {
        if (PlayerWorld1.activeSelf == false)
        {
            PlayerWorld1.SetActive(true);
            PlayerWorld2.SetActive(false);
        }
        else
        {
            PlayerWorld1.SetActive(false);
            PlayerWorld2.SetActive(true);
        }
    }


}
