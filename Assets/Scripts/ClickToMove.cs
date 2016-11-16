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
        string dialogueText = "Test";

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
        string dialogueText = "Test";

			if (Physics.Raycast (ray, out hit, 100, clickMask)) {	
				if (Input.GetMouseButtonUp (0)) {
					if (hit.collider.tag == "Object") {
                    GUI.TextField(new Rect(navMeshAgent.transform.position.x -155, navMeshAgent.transform.position.y + 155, 150, 25), dialogueText);
						//Debug.Log (hit.collider.name);
					} else {
						navMeshAgent.SetDestination (hit.point);
					} 
				} // end GetMouseButtonUp

				ObjectHighlight ohNow = hit.collider.GetComponent<ObjectHighlight>();
				if(ohNow != mousedOverCurrently) {
					if(mousedOverCurrently != null) {
						mousedOverCurrently.mouseHoverRemoveTint();
					}

					mousedOverCurrently = ohNow;

					if(mousedOverCurrently != null) {
						mousedOverCurrently.mouseHoverTint();
					}
				} // end ohNow != mousedOverCurrently 
			} // end Pyhsics.Raycast check
		}// end Update
	} // end of file

	