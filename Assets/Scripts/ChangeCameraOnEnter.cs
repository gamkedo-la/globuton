using UnityEngine;
using System.Collections;

public class ChangeCameraOnEnter : MonoBehaviour {
	Transform camPos;

	void Start(){
		camPos = transform.GetChild (0);
	}
	void OnTriggerEnter (Collider other){
		Debug.Log("Collision entered");
		Camera.main.transform.position = camPos.position;
		Camera.main.transform.rotation = camPos.rotation;
	}
}
