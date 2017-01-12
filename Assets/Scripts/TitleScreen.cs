using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TitleScreen : MonoBehaviour 
{
	public GameObject m_titleScreenImage;
	public Button m_startGameButton;
    private Cutscene m_cutscene;

	// Use this for initialization
	void Start () 
	{
        m_cutscene = GetComponent<Cutscene>();
		m_titleScreenImage.SetActive (true);
		m_startGameButton.onClick.AddListener (StartButtonClick);
	}
	
	void StartButtonClick()
	{
        m_cutscene.enabled = true;
		m_titleScreenImage.SetActive (false);
	}
}
