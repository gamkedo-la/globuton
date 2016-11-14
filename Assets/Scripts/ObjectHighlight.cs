using UnityEngine;
using System.Collections;

public class ObjectHighlight : MonoBehaviour {

	public string objectName;

	private Color startColor;
	private bool displayObjectName = false;

	void OnGUI() {

		DisplayName();
	
	}

	void OnMouseEnter() {
		startColor = GetComponent<Renderer>().material.color;
		GetComponent<Renderer>().material.color = Color.white;
		displayObjectName = true;
		Debug.Log ("Mouse Over " + name);
	}

	void OnMouseExit(){
	
		GetComponent<Renderer>().material.color = startColor;
		displayObjectName = false;
	}

	public void DisplayName(){
	
		if (displayObjectName) {
		
			GUI.Box (new Rect (Event.current.mousePosition.x -155, Event.current.mousePosition.y, 150, 25), objectName);
		}
	}

}
