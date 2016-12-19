using UnityEngine;
using System.Collections;

public class DoorTeleport : MonoBehaviour {
	public Transform teleportTo;

	void OnClickEnter(Collider col){
		if(col.GetComponent<Collider>().gameObject.tag == "Teleporter"){
			transform.position = teleportTo.position;
			transform.rotation = teleportTo.rotation;
		}		
	}
}
