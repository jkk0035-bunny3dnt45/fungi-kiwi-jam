using Unity.VisualScripting;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    private Vector3 World1Postion = new Vector3(15.8816f, 1.33f, 0f);
    private Vector3 World2Postion = new Vector3(15.8816f, -27.8f, 0f);
    public Vector3 World2Offset = Vector3.zero;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Update()
    {
        World2Offset = CalcOffsetVector3();
    }


    Vector3 CalcOffsetVector3()
    {
        return World2Postion - World1Postion;
    }
}
