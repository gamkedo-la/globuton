using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TitleScreen : MonoBehaviour 
{
	public GameObject m_titleScreenImage;
    private Cutscene m_cutscene;

	// Use this for initialization
	void Start () 
	{
        m_cutscene = GetComponent<Cutscene>();
		m_titleScreenImage.SetActive (true);
	}
	
	public void StartButtonClick()
	{
        m_cutscene.enabled = true;
		m_titleScreenImage.SetActive (false);
	}
}
