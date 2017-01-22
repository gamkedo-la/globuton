using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChangeCameraOnEnter : MonoBehaviour
{

    private static List<Transform> triggeredCameraAreas;
    Transform camPos;

    //Not used, commented out to remove caution message in console - OR
	//float interpolate = 0.0f;

	void RefreshCameraHook() {
		if(Camera.main.GetComponent<CameraGoalChaser>() == null) {
			Camera.main.gameObject.AddComponent<CameraGoalChaser>();
		}
	}

	void Awake() {
		RefreshCameraHook();
	}

    void Start()
    {
		RefreshCameraHook();
		triggeredCameraAreas = new List<Transform>();
        camPos = transform.GetChild(0);
    }
	void Update() {
	}
    void OnTriggerEnter(Collider other)
    {
        triggeredCameraAreas.Add(camPos);
		CameraGoalChaser.goalSet(camPos.position, camPos.rotation);
    }
    void OnTriggerExit(Collider other)
    {
        triggeredCameraAreas.Remove(camPos);
        if (triggeredCameraAreas.Count > 0)
        {
			CameraGoalChaser.goalSet(
				triggeredCameraAreas[triggeredCameraAreas.Count - 1].position, 
				triggeredCameraAreas[triggeredCameraAreas.Count - 1].rotation);
        }
    }

}
