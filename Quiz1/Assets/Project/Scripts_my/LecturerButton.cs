using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LecturerButton : MonoBehaviour {


	[Header ("For Getting Inputed Answers")]
	public InputField Test01;
	public InputField Test02;
	public InputField Test03;


	public string Text1;
	public string Text2;
	public string Text3;

	public void DecodeData(){

		Text1 = Test01.text;
		Text2 = Test02.text;
		Text3 = Test03.text;
		Text1 = Encoder.Base64Decode (Text1);
		Text2 = Encoder.Base64Decode (Text2);
		Text3 = Encoder.Base64Decode (Text3);
		Test01.text = Text1;
		Test02.text = Text2;
		Test03.text = Text3;
	}
		
}
