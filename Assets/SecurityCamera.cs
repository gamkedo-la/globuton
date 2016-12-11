using UnityEngine;
using System.Collections;

public class SecurityCamera : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		transform.rotation =
			Quaternion.AngleAxis(-90, Vector3.up) *
			Quaternion.AngleAxis(-60, Vector3.right) *
			Quaternion.AngleAxis(180+ Mathf.Cos(Time.time)*30.0f, Vector3.forward);
	}
}
