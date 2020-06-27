using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class KeysHolder : MonoBehaviour {
	public static KeysHolder instance;
	public string Key1;
	public string Key2;
	public string Key3;
	public Text Key1_txt;
	public Text Key2_txt;
	public Text Key3_txt;


	private void Awake() {
		if (instance != null) {
			Destroy(this);
		} else {
			instance = this;
			DontDestroyOnLoad(this);
		}
	}


	public void SetKey1(string s) {
		Key1 = s;
		Key1_txt.text = Key1;
	}

	public void SetKey2(string s) {
		Key2 = s;
		Key2_txt.text = Key2;
	}
	public void SetKey3(string s) {
		Key3 = s;
		Debug.Log (s);
		Key3_txt.text = Key3;
	}
}
