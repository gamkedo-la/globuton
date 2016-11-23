using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InventorySystem : MonoBehaviour {

	public enum Item{pepperShaker, tissues, food, item1, item2};
	private bool[] hasItem = new bool[5];
	public Image[] UIicons;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < hasItem.Length; i++) {
			hasItem[i] = false;
			UIicons[i].color = Color.clear;
		}
	}

	public void GiveItem(int index){
		//int index = (int)getting;
		hasItem[index] = true;
		UIicons[index].color = Color.white;
	}

	public void UseItem(int index){
		if (hasItem [index]) {
			hasItem [index] = false;
			UIicons [index].color = Color.clear;
			Debug.Log ("Using item" + (Item)index);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
