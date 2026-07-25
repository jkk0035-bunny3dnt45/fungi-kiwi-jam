using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera World1Camera;
    public Camera World2Camera;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        World1Camera.enabled = true;
        World2Camera.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 cameraPostion = CameraTarget.transform.position;

        //gameObject.transform.position = new Vector3(cameraPostion.x, cameraPostion.y, -10f);
    }

    public void SwitchCamera()
    {
        //Swap Cameras
        World2Camera.enabled = !World2Camera.enabled;
        World2Camera.enabled = !World2Camera.enabled;
    }
}
