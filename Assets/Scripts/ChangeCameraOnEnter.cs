using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChangeCameraOnEnter : MonoBehaviour
{

    private static List<Transform> triggeredCameraAreas = new List<Transform>();
    Transform camPos;

    void Start()
    {
        camPos = transform.GetChild(0);
    }
    void OnTriggerEnter(Collider other)
    {
        triggeredCameraAreas.Add(camPos);
        //Debug.Log("Collision entered" + gameObject.name.ToString());
        Camera.main.transform.position = camPos.position;
        Camera.main.transform.rotation = camPos.rotation;
    }
    void OnTriggerExit(Collider other)
    {
        triggeredCameraAreas.Remove(camPos);
        if (triggeredCameraAreas.Count > 0)
        {
            Camera.main.transform.position = triggeredCameraAreas[triggeredCameraAreas.Count - 1].position;
            Camera.main.transform.rotation = triggeredCameraAreas[triggeredCameraAreas.Count - 1].rotation;
        }
        //Debug.Log("Collision exit" + gameObject.name.ToString() + " cams left: " + triggeredCameraAreas.Count.ToString());
    }

}
