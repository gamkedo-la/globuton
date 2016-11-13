using UnityEngine;
using System.Collections;

public class MouseOnObject : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnMouseEnter(){
		Debug.Log ("Enter");
	}

	public void OnMouseExit(){
		Debug.Log ("Exit");
	}

	public void OnMouseDown(){
		
		Debug.Log ("You clicked on me!");
	}

	public void OnMouseUp(){
		Debug.Log ("Up");
	}
}
