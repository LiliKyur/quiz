using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GetInputField : MonoBehaviour {

	public static GetInputField instance;

	public InputField[] Texts;
	private Text txt;
	public static string enText;
	public static string txtSum;

	public static string key_3;
	public static string k3;

	void Awake()
	{
		instance = this;
	}

	public void GetText()
	{
		for (int i = 0; i < Texts.Length; i++) 
		{
			txt.text += Texts [i].text + "_";
		}
		Debug.Log ("hoho  " + txt.text);
		EncodeInputField();

	}

	public void EncodeInputField()
	{
		key_3 = Encoder.Base64Encode (txt.text);
		KeysHolder.instance.SetKey3 (key_3);

	}

}
