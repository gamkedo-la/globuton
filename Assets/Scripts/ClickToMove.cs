using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ClickToMove : MonoBehaviour {

	private NavMeshAgent navMeshAgent;
	private int clickMask;
	private ObjectHighlight mousedOverCurrently = null;
	private InventorySystem inventory;
    private RaycastHit interactHit; //raycast info for object clicked on, but out of range
    private bool moveToInteract = false; //flag to know if we are moving to interact with something
    public float interactRange = 4.5f; //Range at which this object can interact with clicked objects, if out of range, move to it then interact

    // Use this for initialization
    void Start () {
		clickMask = ~LayerMask.GetMask ("Camera Trigger");
		navMeshAgent = GetComponent<NavMeshAgent>();
		inventory = GetComponent<InventorySystem>();
        moveToInteract = false;
    }

	void OnGUI() {
		if(mousedOverCurrently != null) {
			GUI.Box(new Rect(Event.current.mousePosition.x - 155, Event.current.mousePosition.y, 150, 25),
				mousedOverCurrently.objectName);
		}
        
	}

    bool IsInInteractRange(Vector3 a, Vector3 b)
    {
        a.y = 0; //ignoring height distance of objects, remove this if you want to require 3d distance
        b.y = 0; //ignoring height distance of objects, remove this if you want to require 3d distance
        //Debug.Log(Vector3.Distance(a, b).ToString());
        return Vector3.Distance(a, b) < interactRange;
    }

    //Will do an interaction based on if it can be picked up (GiveObject script) or if it has dialogueSpawner script
    void DoInteract(GameObject interactObject)
    {
       
        if (interactObject != null)
        {
            GiveObject goScript = interactObject.GetComponent<GiveObject>();
            if (goScript != null)
            {
                inventory.GiveItem((int)goScript.whichItem);
                Destroy(goScript.gameObject);
            }
            else if (interactObject.tag == "Object")
            {
                Debug.Log("You clicked on it");
                //check if it has a dialogue spawner, if so, call it's OnClick
                DialogueSpawner showNarrative = interactObject.GetComponent<DialogueSpawner>();
                if (showNarrative != null)
                {
                    //has a dialogue spawner
                    showNarrative.OnClick();
                }
            }   
        }
    }

    IEnumerator PollInteractDistance()
    {
        do
        {
            yield return new WaitForSeconds(1.0f); //every second poll the distance, if in range, interact and get out
            
            if (interactHit.transform != null && IsInInteractRange(transform.position, interactHit.transform.position))
            {
                navMeshAgent.SetDestination(transform.position);
                DoInteract(interactHit.collider.gameObject);
                moveToInteract = false;
                break;
            }
        } while (moveToInteract);
        yield return null;
    }

	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
        
		if (Physics.Raycast (ray, out hit, 100, clickMask)) {	
			if (Input.GetMouseButtonUp (0)) {

                //If currently doing move to interact, interupt it early, and stop the coroutine that is polling distance
                if (moveToInteract)
                {
                    moveToInteract = false;
                    StopCoroutine(PollInteractDistance());
                }

                GiveObject goScript = hit.collider.GetComponent<GiveObject>();
                if (goScript != null || hit.collider.tag == "Object")
                {
                    //We have clicked on object that has dialogue or can be picked up, check if it is in range
                    if (IsInInteractRange(transform.position, hit.transform.position))
                    {
                        //In range, call the DoInteract function
                        DoInteract(hit.collider.gameObject);
                    }
                    else   //not in range, start moving towards it, try picking it up again after a short delay
                    {
                        //Set move to destination, Start co routine to check again soon
                        interactHit = hit; //store what we clicked on, so we can check it again later
                        moveToInteract = true;
                        StartCoroutine(PollInteractDistance()); //start polling distance
                        navMeshAgent.SetDestination(hit.point);
                    }
                }
                else   
                { 
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

	