using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
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

public class Quest_Script : MonoBehaviour {


	public string Question;
	public List<string> Answers;
	public List<int> Correct_Indexes;
}


/*
public class Questions
{
	public string Question;
	public List<string> Answers;
	public List<int> Correct_Indexes;
}
public class Ques
{
	public string question;
	public List<string> answers;
	public List<int> correct_indexes;

	public Ques(Questions qs) {
		question = qs.Question;
		answers = qs.Answers;
		correct_indexes = qs.Correct_Indexes;
	}
}

public class Questions_Core : MonoBehaviour {

	public List<Questions> AllQuests = new List<Questions>();
	private List<Ques> _questions = new List<Ques>();
	public List<Ques> Quest_List {
		get {
			if(_questions.Count == 0) {
				InitializeQuestions();
			}
			return _questions;
		}
	}


	private void InitializeQuestions() {
		foreach(Questions q in AllQuests) {
			_questions.Add(new Ques(q));
		}
	}




}*/
