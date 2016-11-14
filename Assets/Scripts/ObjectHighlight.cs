using UnityEngine;
using System.Collections;

public class ObjectHighlight : MonoBehaviour {
	public string objectName;
	private Color startColor;

	public void mouseHoverTint() {
		Renderer rend = GetComponent<Renderer>();
		startColor = rend.material.color;
		rend.material.color = Color.white;
	}

	public void mouseHoverRemoveTint(){
		GetComponent<Renderer>().material.color = startColor;
	}
}
