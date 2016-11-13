using UnityEngine;
using System.Collections;

public class ClickToMove : MonoBehaviour {
	
	private NavMeshAgent navMeshAgent;
	private int clickMask;
	private bool walking;
	private bool objectClicked;
	private Transform highlightedObject;
	public MouseOnObject mouseOverObject;
	public DisplayText displayText;

	// Use this for initialization
	void Start () 
	{
		clickMask = ~LayerMask.GetMask ("Camera Trigger");
		navMeshAgent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		
		/*if (Input.GetMouseButtonUp(0))
		{
			if (Physics.Raycast (ray, out hit, 100, clickMask))
				
				if (hit.collider.CompareTag ("Object")) 
				{
					highlightedObject = hit.transform;
					objectClicked = true;
					mouseOverObject.OnMouseDown();
				}
				
			else
				{
					walking = true;
					objectClicked = false;
					navMeshAgent.destination = hit.point;
				}*/

		if (Input.GetMouseButtonDown(0))
		{
			if (Physics.Raycast (ray, out hit, 100, clickMask))

				if (hit.collider.CompareTag ("Object")) 
				{
					mouseOverObject.OnMouseDown();
				}

				else
				{
					navMeshAgent.destination = hit.point;
				}
		
		}
		
	}
}
//}