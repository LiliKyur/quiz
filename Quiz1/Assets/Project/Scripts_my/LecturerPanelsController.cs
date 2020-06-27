using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LecturerPanelsController : MonoBehaviour {

	public GameObject menuPanel;
	public GameObject resPanel;

	void Start()
	{
		Disable ();
		menuPanel.gameObject.SetActive (true);
	}

	void Disable()
	{
		menuPanel.gameObject.SetActive (false);
		resPanel.gameObject.SetActive (false);
	}

	public void ButtonFunction()
	{
		menuPanel.gameObject.SetActive (false);
		resPanel.gameObject.SetActive (true);
	}
	public void BackButtonFunction()
	{
		menuPanel.gameObject.SetActive (true);
		resPanel.gameObject.SetActive (false);
	}
}
