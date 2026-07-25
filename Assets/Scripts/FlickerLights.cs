using UnityEngine;

public class FlickerLights : MonoBehaviour
{
    float timeOn = 0.1f;
    float timeOff = 0.5f;
    private float changeTime = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Update()
    {
        if (Time.time > changeTime) {
        GetComponent<Light>().enabled = !GetComponent<Light>().enabled;

        if (GetComponent<Light>().enabled) {
            changeTime = Time.time + timeOn;
        } else {
            changeTime = Time.time + timeOff;
        }
    }
    }
}
