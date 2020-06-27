using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM_Core : MonoBehaviour {
	public static GM_Core instance;
	private List<_quest> _QuestionList;
	private List<bool> _questions_status = new List<bool>();
	public int quest_index = 0;

	private void Awake() {
		instance = this;
		//GameObject.Find("Core Game/Questions/Q1").active = true;
	}

	private void Start() {
		_QuestionList = Question_Core.instance.Quest_List;
		UI_Core.instance.SetupQuestion(_QuestionList[0]);
	}

	public void Iterate() {
		quest_index++;
		if(quest_index < _QuestionList.Count) {
			UI_Core.instance.SetupQuestion(_QuestionList[quest_index]);
		} else {
			UI_Core.instance.FinishQuestion(_questions_status);
		}
	}

	public void SetAnswerState(bool state) {
		_questions_status.Add(state);
	}

}
