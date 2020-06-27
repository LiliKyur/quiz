using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct _quest {
	public string _question;
	public List<string> _answers;
	public List<int> correct_indexes;

	public _quest(Quest_Script qs) {
		_question = qs.Question;
		_answers = qs.Answers;
		correct_indexes = qs.Correct_Indexes;
	}
}

[CreateAssetMenu(fileName = "Quest_Script_", menuName = "Create Question / Scriptable Question")]
public class Quest_Script : ScriptableObject {
	

	public string Question;
	public List<string> Answers;
	public List<int> Correct_Indexes;



}


public class Question_Core : MonoBehaviour {
	public static Question_Core instance;
	private void Awake() {
		instance = this;
	}

	public List<Quest_Script> Questions = new List<Quest_Script>();
	private List<_quest> _questions = new List<_quest>();
	public List<_quest> Quest_List {
		get {
			if(_questions.Count == 0) {
				InitializeQuestions();
			}
			return _questions;
		}
	}


	private void InitializeQuestions() {
		foreach(Quest_Script q in Questions) {
			_questions.Add(new _quest(q));
		}
	}
}
