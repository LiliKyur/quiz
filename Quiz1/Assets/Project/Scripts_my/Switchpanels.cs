using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Switchpanels : MonoBehaviour {


	public GameObject mainMenu;
	public GameObject topicsMenu;
	public GameObject testsMenu;
	public GameObject progTopic;
	//Test Scenes must switch for animations

	void Start(){

		mainMenu.gameObject.SetActive (true);
		topicsMenu.gameObject.SetActive (false);
		testsMenu.gameObject.SetActive (false);
		progTopic.gameObject.SetActive (false);
	}

	public void toMainMenu()
	{
		mainMenu.gameObject.SetActive (true);
		topicsMenu.gameObject.SetActive (false);
		testsMenu.gameObject.SetActive (false);
		progTopic.gameObject.SetActive (false);
	}

	public void toTopicsMenu()
	{
		topicsMenu.gameObject.SetActive (true);
		testsMenu.gameObject.SetActive (false);
		progTopic.gameObject.SetActive (false);
		mainMenu.gameObject.SetActive (false);
	}

	public void toTestsMenu()
	{
		testsMenu.gameObject.SetActive (true);
		progTopic.gameObject.SetActive (false);
		mainMenu.gameObject.SetActive (false);
		topicsMenu.gameObject.SetActive (false);
	}

	public void toProgTopic()
	{
		progTopic.gameObject.SetActive (true);
		topicsMenu.gameObject.SetActive (false);
		testsMenu.gameObject.SetActive (false);
		mainMenu.gameObject.SetActive (false);

	}


}
