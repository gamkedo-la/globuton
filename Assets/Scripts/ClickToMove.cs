using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ClickToMove : MonoBehaviour {

	private NavMeshAgent navMeshAgent;
	private int clickMask;
	private ObjectHighlight mousedOverCurrently = null;

	// Use this for initialization
	void Start () 
	{
		clickMask = ~LayerMask.GetMask ("Camera Trigger");
		navMeshAgent = GetComponent<NavMeshAgent>();
	}

	void OnGUI() {
		if(mousedOverCurrently != null) {
			GUI.Box(new Rect(Event.current.mousePosition.x - 155, Event.current.mousePosition.y, 150, 25),
				mousedOverCurrently.objectName);
		}
	}

	// Update is called once per frame
	void Update () 
	{
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);


		if(Physics.Raycast(ray, out hit, 100, clickMask)) {	
			if(Input.GetMouseButtonUp(0)) {
				navMeshAgent.SetDestination(hit.point);
			} else {
				ObjectHighlight ohNow = hit.collider.GetComponent<ObjectHighlight>();
				if(ohNow != mousedOverCurrently) {
					if(mousedOverCurrently != null) {
						mousedOverCurrently.mouseHoverRemoveTint();
					}

					mousedOverCurrently = ohNow;

					if(mousedOverCurrently != null) {
						mousedOverCurrently.mouseHoverTint();
					}
				}
			}
		}
	}
}
