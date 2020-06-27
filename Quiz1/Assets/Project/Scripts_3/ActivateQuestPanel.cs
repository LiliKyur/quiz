using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateQuestPanel : MonoBehaviour {

	public GameObject Question1;
	public GameObject Question2;

	void Start()
	{
		Question1.gameObject.SetActive (true);
		Question2.gameObject.SetActive (false);

	}

	public void ActivateGameObj(){
		Question2.gameObject.SetActive (true);
		Question1.gameObject.SetActive (false);

	}
}
