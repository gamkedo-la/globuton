using UnityEngine;
using System.Collections;

public class CameraGoalChaser : MonoBehaviour {
	public static Vector3 wasPos;
	public static Quaternion wasRot;
	public static Vector3 goalPos;
	public static Quaternion goalRot;
	public static float timeWhen;

	public static Cutscene cutsceneMain;

	void RefreshCameraHook() {
		GameObject globalGO = GameObject.Find("Global");
		cutsceneMain = globalGO.GetComponent<Cutscene>();
	}

	void Awake() {
		RefreshCameraHook();
	}

	// Use this for initialization
	void Start () {
		EndingTakeoverCamera.isPlaying = false;

		RefreshCameraHook();

		timeWhen = Time.time;

		wasPos = goalPos = Camera.main.transform.position;

		wasRot = goalRot = Camera.main.transform.rotation;	
	}

	public static void goalSet(Vector3 pos, Quaternion rot) {
		wasPos = Camera.main.transform.position;

		wasRot = Camera.main.transform.rotation;	

		timeWhen = Time.time;
		goalPos = pos;
		goalRot = rot;
	}
	
	// Update is called once per frame
	void Update () {
		if(cutsceneMain.isActiveAndEnabled && cutsceneMain.isPlaying()) {
			return;
		}
		if(EndingTakeoverCamera.isPlaying) {
			return;
		}
		float interpolate = Time.time - timeWhen;
		if(interpolate > 1.0f) {
			interpolate = 1.0f;
		}

		Camera.main.transform.position = Vector3.Lerp(wasPos,
			goalPos,interpolate);

		Camera.main.transform.rotation = Quaternion.Slerp(wasRot,
			goalRot,interpolate);	
	}
}
