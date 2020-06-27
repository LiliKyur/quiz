using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Answer
{
	[SerializeField]
	private string _info;
	public string Info { get { return _info; } }

	[SerializeField]
	private bool _isCorrect;
	public bool IsCorrect { get { return _isCorrect; } }
}

[CreateAssetMenu(fileName = "Question_2", menuName = "Quiz/ new Question_2")]
public class Question_2 : ScriptableObject {

	//Answer Types
	public enum answerType { Multi, Single };

	[SerializeField]
	private string _info = string.Empty;
	public string Info { get { return _info; } }
	///

	[SerializeField]
	Answer[] answers = null;
	public Answer[] Answer{ get{ return answers; } }

	// Parameters
	[SerializeField]
	private bool _timer = false;
	public bool _Timer{ get { return _timer; } }

	[SerializeField]
	private int timer = 0;
	public int Timer { get { return timer; } }

	[SerializeField]
	private answerType _answerType = answerType.Multi;
	public answerType GetAnswerType { get { return _answerType; } }

	[SerializeField]
	private int _addScore = 0;
	public int AddScore { get { return _addScore; } }

	public List<int> GetCorrectAnswers ()
	{
		
		List<int> CorrectAnswers = new List<int>();

		for (int i = 0; i < Answer.Length; i++) 
		{
			if (Answer [i].IsCorrect) {
				CorrectAnswers.Add (i);				
			}
		}
		return CorrectAnswers;
	}
}
