using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ClickToMove : MonoBehaviour {

	private NavMeshAgent navMeshAgent;
	private int clickMask;
	private ObjectHighlight mousedOverCurrently = null;
	private InventorySystem inventory;

    // Use this for initialization
    void Start () {
		clickMask = ~LayerMask.GetMask ("Camera Trigger");
		navMeshAgent = GetComponent<NavMeshAgent>();
		inventory = GetComponent<InventorySystem>();

    }

	void OnGUI() {
		if(mousedOverCurrently != null) {
			GUI.Box(new Rect(Event.current.mousePosition.x - 155, Event.current.mousePosition.y, 150, 25),
				mousedOverCurrently.objectName);
		}
        
	}

	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
        

		if (Physics.Raycast (ray, out hit, 100, clickMask)) {	
			if (Input.GetMouseButtonUp (0)) {
				GiveObject goScript = hit.collider.GetComponent<GiveObject>();
				if (goScript != null) {
					inventory.GiveItem((int)goScript.whichItem);
					Destroy (goScript.gameObject);
				} else if (hit.collider.tag == "Object") {
					Debug.Log("You clicked on it");

                    //Object is clicked, check if it has a dialogue spawner, if so, call it's OnClick
                    DialogueSpawner showNarrative = hit.collider.GetComponent<DialogueSpawner>();
                    if(showNarrative != null)
                    {
                        //has a dialogue spawner
                        showNarrative.OnClick();
                    }

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

	