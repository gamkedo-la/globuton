using UnityEngine;
using System.Collections;

public class SneezeAndSlide : MonoBehaviour {
	private bool hasSlidYet = false;
	public Transform slideTo;

	public void sneezeNow(){
		if (hasSlidYet == false) {
			Debug.Log ("Play sneeze sound now");
			transform.position = slideTo.position;
			hasSlidYet = true;
		}
	}
}
