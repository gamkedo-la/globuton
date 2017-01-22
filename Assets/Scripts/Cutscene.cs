using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class Cutscene : MonoBehaviour {
	private IEnumerator midPlaying = null;
	private Vector3 returnToPos;
	private Quaternion returnToRot;
	public Transform[] cameraSteps;
    public GameObject gameUI;

	private static GameObject cutsceneBars;

	public Transform[] boxiiSteps;

	public Transform boxiiHookupIfEndCutscene;
	public float waitTime = 4.0f;

	private bool acceptGameEndSpacebar = false;

	public bool isPlaying() {
		return (midPlaying != null);
	}
    void Awake()
	{
		if(cutsceneBars == null) {
			cutsceneBars = GameObject.Find("CutsceneBars");
			cutsceneBars.SetActive(false);
		}
	}

	void Start()
	{
        midPlaying = playCutscene();
        StartCoroutine(midPlaying);
    }
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			if(boxiiHookupIfEndCutscene == null) {
				EndCutscene();
			} else if(acceptGameEndSpacebar) {
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
			}
		}
	}
	private void EndCutscene(){
		if (midPlaying != null) {
			Text endText = cutsceneBars.GetComponentInChildren<Text>();
			endText.text = "";
			StopCoroutine (midPlaying);
			cutsceneBars.SetActive(false);
            gameUI.SetActive(true);
            Camera.main.transform.position = returnToPos;
			Camera.main.transform.rotation = returnToRot;
			midPlaying = null;
            SoundManager.instance.StartMusic();
		}
	}

	private IEnumerator playCutscene(){
		cutsceneBars.SetActive(true);
        gameUI.SetActive(false);
        returnToPos = Camera.main.transform.position;
		returnToRot = Camera.main.transform.rotation;
		for (int i = 0; i < cameraSteps.Length; i++) {
			Camera.main.transform.position = cameraSteps [i].position;
			Camera.main.transform.rotation = cameraSteps [i].rotation;

			if(i < boxiiSteps.Length) {
				NavMeshAgent NMA = boxiiHookupIfEndCutscene.GetComponent<NavMeshAgent>();
				if(NMA) {
					NMA.enabled = false;
				}
				boxiiHookupIfEndCutscene.transform.position = boxiiSteps [i].position;
				boxiiHookupIfEndCutscene.transform.rotation = boxiiSteps [i].rotation;
			}

			yield return new WaitForSeconds (waitTime);
        
		}

		if(boxiiHookupIfEndCutscene == null) {
			EndCutscene();
		} else {
			Text endText = cutsceneBars.GetComponentInChildren<Text>();
			endText.text = "End of Episode 1 – Press Space to Reset";

			acceptGameEndSpacebar = true;
		}
	}
}
