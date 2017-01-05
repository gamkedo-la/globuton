using UnityEngine;
using System.Collections;

public class SecurityCamera : MonoBehaviour {
    private bool isOn = true;
    public Light redLight;
    public GameObject blockingWall;

	// Update is called once per frame
	void Update () {
        if (isOn) {
           transform.rotation =
           Quaternion.AngleAxis(-90, Vector3.up) *
           Quaternion.AngleAxis(-60, Vector3.right) *
           Quaternion.AngleAxis(180 + Mathf.Cos(Time.time) * 30.0f, Vector3.forward);
        }
    }

    public void shutOffCam() {
        if (isOn) {
            redLight.enabled = false;
            Destroy(blockingWall);
            isOn = false;
            Renderer rend = GetComponent<Renderer>();
            rend.material.SetColor("_EmissionColor",Color.black);
        }
    }
}
