using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI_Core : MonoBehaviour {
	public static UI_Core instance;
	private void Awake() {
		instance = this;
	}

	public Text QuestionText;
	public List<Text> AnswerTexts = new List<Text>();
	public Button NextQuestionButton;

	private _quest currentQuestion;

	private string key_2;
	public string k1;

	public void SetupQuestion(_quest q) {
		SetNextButtonState(false);
		SetOptionsState(true);
		currentQuestion = q;
		Debug.Log (q);
		RenderQuestion();
	}

	public void OptionSelected(int o) {
		SetOptionsState(false);
		bool status = CheckAnswer(o);
		GM_Core.instance.SetAnswerState(status);
		QuestionText.text = status ? "You are Correct!" : "This was a wrong answer";
		SetNextButtonState(true);
	}

	public void MoveToNextQuestion() {
		GM_Core.instance.Iterate();
	}

	public void FinishQuestion(List<bool> statuses) {
		SetOptionsState(false);
		SetNextButtonState(false);
		string ans = "";
		foreach(bool b in statuses) {
			ans += b + " : ";
			Debug.Log (ans);
			ans = ans.ToString ();

		}
		Debug.Log (Encoder.Base64Encode (ans));
		key_2 = Encoder.Base64Encode (ans);
		KeysHolder.instance.SetKey2(key_2);

		QuestionText.text = "  & 2nd key: " + key_2;
		GameManager.GettingEncodeData (k1);
	}

	private bool CheckAnswer(int o) {
		bool isCorrect = false;
		for(int i = 0; i < currentQuestion.correct_indexes.Count; i++) {
			if (o == currentQuestion.correct_indexes [i]) {
				isCorrect = true;
			} 
		}
		return isCorrect;
	}

	private void RenderQuestion() {
		QuestionText.text = currentQuestion._question;
		for(int i = 0; i < currentQuestion._answers.Count; i++) {
			AnswerTexts[i].text = currentQuestion._answers[i];
		}
	}

	private void SetOptionsState(bool state) {
		for(int i = 0; i < AnswerTexts.Count; i++) {
			AnswerTexts[i].transform.parent.gameObject.SetActive(state);
		}
	}

	private void SetNextButtonState(bool state) {
		NextQuestionButton.gameObject.SetActive(state);
	}


}
