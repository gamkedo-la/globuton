using UnityEngine;
using System.Collections;

public class UseItemOnThis : MonoBehaviour {
	public InventorySystem.Item needsItem;
	public GameObject callsFunctionOnGO;
	public string functionNameToCall;

	bool hasAlreadyActed = false;

	public bool MatchesItemNeeded( int selectedItemUsed ) {
		if(hasAlreadyActed == false) {
			if((int)needsItem == selectedItemUsed) {
				callsFunctionOnGO.SendMessage(functionNameToCall);
				hasAlreadyActed = true;
				return true;
			} else {
				Debug.Log("Incorrect item selected. Expecting " + needsItem + " got " + (InventorySystem.Item)selectedItemUsed);
			}
		}
		return false;
	}

	public void ExampleFunctionWhenItemUsedOn() {
		transform.Rotate(45.0f, 45.0f, 45.0f);
		Debug.Log("can name any function in Inspector on any component of the assigned callsFunctoinOnGO");
	}
}
