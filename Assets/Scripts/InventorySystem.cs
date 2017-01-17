﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InventorySystem : MonoBehaviour {

	public enum Item{tissues, food, toyBlock, keyCode, pepperShaker};
	private bool[] hasItem = new bool[5];
	public Image[] UIicons;

	int selectedNow = -1;
	public Image[] selectors;

	// Use this for initialization
	void Start () {
		GameObject inventoryRoot = UIicons[0].transform.parent.gameObject;
		GameObject copiedGOSet = GameObject.Instantiate(inventoryRoot);
		copiedGOSet.transform.SetParent(UIicons[0].transform.parent.parent);
		copiedGOSet.name = "Highlight Selectors";

		selectors = new Image[5];

		for (int i = 0; i < hasItem.Length; i++) {
			hasItem[i] = false;

			UIicons[i].color = Color.clear;
			Button eachButton = UIicons[i].GetComponent<Button>();
			ColorBlock cbSet = eachButton.colors;
			cbSet.highlightedColor = Color.yellow;
			eachButton.colors = cbSet;
		}

		Image bgLayer = copiedGOSet.GetComponent<Image>();
		bgLayer.enabled = false;
		copiedGOSet.transform.localPosition =
			inventoryRoot.transform.localPosition;
		for (int i = 0; i < hasItem.Length; i++) {
			selectors[i] = copiedGOSet.transform.GetChild(i).GetComponent<Image>();
			selectors[i].preserveAspect = false;
			selectors[i].sprite = Resources.Load<Sprite>("itemHighlight");
		}
		ClearSelection();
	}

	public void SetSelection(int index) {
		selectedNow = index;
		for (int i = 0; i < hasItem.Length; i++) {
			selectors[i].color = (index == i ? Color.white : Color.clear);
		}
	}

	public void GiveItem(int index){
		//int index = (int)getting;
		hasItem[index] = true;
		UIicons[index].color = Color.white;
	}

	public void UseItem(int index){
		if(hasItem[index]) {
			SetSelection(index);
		} else {
			ClearSelection(); 
		}
	}

	public void ClearSelection() {
		SetSelection(-1);
	}

	public bool ItemIsSelected() {
		return (selectedNow != -1);
	}

	// returns true only if item got used, but clears selection regardless
	public bool UseCurrentItemIfAble(UseItemOnThis uiotScript) {
		if(selectedNow == -1 || uiotScript == null) {
			return false;
		}

		if (hasItem [selectedNow] && uiotScript.MatchesItemNeeded(selectedNow)) {
			hasItem [selectedNow] = false;
			UIicons [selectedNow].color = Color.clear;
			Debug.Log ("Using item " + (Item)selectedNow);
			ClearSelection();
            SoundManager.instance.PlaySingle(SoundManager.instance.m_stingPuzzle);
			return true;
		}
		ClearSelection();
		return false;
	}
}
