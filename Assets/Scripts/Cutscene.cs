using UnityEngine;
using System.Collections;

public class Cutscene : MonoBehaviour {
	private IEnumerator midPlaying = null;
	private Vector3 returnToPos;
	private Quaternion returnToRot;
	public Transform[] cameraSteps;
    public GameObject gameUI;

    void Start()
    {
        midPlaying = playCutscene();
        StartCoroutine(midPlaying);
    }
	// Update is called once per frame
	void Update () {			
		if (Input.GetKeyDown (KeyCode.Space)) {
			EndCutscene();
		}
	}
	private void EndCutscene(){
		if (midPlaying != null) {
			StopCoroutine (midPlaying);
            gameUI.SetActive(true);
            Camera.main.transform.position = returnToPos;
			Camera.main.transform.rotation = returnToRot;
			midPlaying = null;
		}
	}

	private IEnumerator playCutscene(){
        gameUI.SetActive(false);
        returnToPos = Camera.main.transform.position;
		returnToRot = Camera.main.transform.rotation;
		for (int i = 0; i < cameraSteps.Length; i++) {
			Camera.main.transform.position = cameraSteps [i].position;
			Camera.main.transform.rotation = cameraSteps [i].rotation;
			yield return new WaitForSeconds (2.0f);
        
		}
		EndCutscene();
	}
}
