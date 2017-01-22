using UnityEngine;
using System.Collections;

public class UseItemOnThis : MonoBehaviour {
	public InventorySystem.Item needsItem;
	public GameObject callsFunctionOnGO;
	public string functionNameToCall;
    
	public bool alsoDestroySelf = false;

	public UseItemOnThis unlock;
    public bool locked = false;
	public bool hasAlreadyActed = false;

	public bool MatchesItemNeeded( int selectedItemUsed ) {
        if (locked)
        {
            return false;
        }
		if(hasAlreadyActed == false) {
			if((int)needsItem == selectedItemUsed) {
				callsFunctionOnGO.SendMessage(functionNameToCall);
				if(alsoDestroySelf) {
					GameObject.Destroy(gameObject);
				}
                if(unlock != null)
                {
                    unlock.locked = false;
                }
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
