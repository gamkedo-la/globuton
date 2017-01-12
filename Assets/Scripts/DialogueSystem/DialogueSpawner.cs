using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class DialogueSpawner : MonoBehaviour {
    //Expose functions to spawn the chain of dialogues. 
    //First function will be click spawn

    [Tooltip("The chain of dialogues to spawn, when spawn event occurs. Order matters.")]
    public List<GameObject> dialogueChain;

    [Tooltip("The parent all the dialogues should belong to when instantiated. Parent should be a UI element or canvas.")]
    public RectTransform parent;

    [Tooltip("The time required to have passed before this object can spawn more dialogues.")]
    public float reclickTime = 0.0f;

    [Tooltip("Duration to wait before cleaning up remnant prefabs. Check the duration the dialogue should be displayed, so you don't destroy it too early. 0 = don't cleanup.")]
    public float cleanupTime = 0.0f;

    bool canSpawn = true;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}

    public void OnClick()
    {
        //This object has been clicked
        SpawnChain();
    }

    void SpawnChain()
    {
        if (canSpawn)
        {
            if(parent == null)
            {
                GameObject parentObject = GameObject.FindGameObjectWithTag("DialogueParentObject");
                parent = parentObject.GetComponent<RectTransform>();
            }
            for (int i = 0; i < dialogueChain.Count; i++)
            {
                GameObject nextDialogue = Instantiate(dialogueChain[i]) as GameObject;
                nextDialogue.transform.SetParent(parent, false);

                //Dialogue objects that are children auto destroy themselves when the display timer has passed. This leaves the prefab itself as a broken link, empty and cluttering the game until game close. Cleanup? 
                //if (cleanupTime != 0.0f)
                    //Destroy(nextDialogue, cleanupTime);
            }
            canSpawn = false;
            StartCoroutine(ClickWaitTime());
        }
    }

    IEnumerator ClickWaitTime()
    {
        yield return new WaitForSeconds(reclickTime);
        canSpawn = true;
    }
}
