using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ClickToMove : MonoBehaviour {
	
	private NavMeshAgent navMeshAgent;
	private int clickMask;

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


		if (Input.GetMouseButtonUp (0)) 
		{
			if (Physics.Raycast (ray, out hit, 100, clickMask)) 
			{	
				navMeshAgent.SetDestination(hit.point);
			}
		}
	}
}
