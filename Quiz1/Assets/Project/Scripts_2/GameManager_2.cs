/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameManager_2 : MonoBehaviour {

	Question_2[] _question_2 = null;
	public Question_2[] Questions { get { return _question_2; } }

	[SerializeField]
	private float timeBetweenQuestions = 1f;

	[SerializeField] GameEvents events = null;

	private List<AnswerData> PickedAnswers = new List<AnswerData> ();
	private List<int> finishedQuestion = new List<int>();
	private int currentQuestion = 0;

	private IEnumerator IE_WaitTillNextRound = null;

	void Start()
	{
		LoadQuestions ();

		foreach (var Question__1 in Questions) 
		{
			Debug.Log(Question__1.Info);
			
		}
		Display ();
	}

	public void UpdateAnswer(AnswerData newAnswer)
	{
		if (Question_2[currentQuestion].GetAnswerType == Question_2.answerType.Single) {
			foreach (var answer in PickedAnswers) {
				answer.Reset ();
			}
			PickedAnswers.Clear ();
			PickedAnswers.Add (newAnswer);
		} else 
		{
			bool alreadyPicked = PickedAnswers.Exists(x => x ==newAnswer);//lambada )))
			if (alreadyPicked) {
				PickedAnswers.Remove (newAnswer);	
			} else 
			{
				PickedAnswers.Add (newAnswer);
			}
		}
	}

	public void EraseAnswers()
	{
		PickedAnswers = new List<AnswerData> ();
	}

	void Display()
	{
		EraseAnswers ();
		var question = GetRandomQuestion ();

		if (events.updateQuestionUI != null) {
			events.updateQuestionUI (question);
			
		} else 
		{
			Debug.LogWarning (" Warning ");
		}
		
	}

	public void Accept()
	{
		bool isCorrect = CheckAnswers();
		finishedQuestion.Add (currentQuestion);

		UpdateScore ((isCorrect)?Question_2[currentQuestion].AddScore : -Question_2[currentQuestion].AddScore);

		if (IE_WaitTillNextRound != null) 
		{
			StopCoroutine (IE_WaitTillNextRound);
			
		}
		IE_WaitTillNextRound = WaitTillNextRound ();
		StartCoroutine (IE_WaitTillNextRound); ///////
	}

	IEnumerator WaitTillNextRound()
	{
		yield return new WaitForSeconds (GameUtility.ResolutionDelayTime);
		Display ();
		//SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
	}

	Question_2 GetRandomQuestion()
	{
		var randomIndex = GetRandomQuestionIndex ();
		currentQuestion = randomIndex;

		return Questions [currentQuestion];
	}

	int GetRandomQuestionIndex()
	{
		var random = 0;
		if(finishedQuestion.Count < Questions.Length)
		{
			do 
			{
				random = Random.Range(0, Questions.Length);
				
			} while (finishedQuestion.Contains(random) || random == currentQuestion);
			
		}
		return random;
	}

	void LoadQuestions()
	{
		Object[] objs = Resources.LoadAll ("Questions", typeof(Question_2));
		_question_2 = new Question_2[objs.Length];
		for (int i = 0; i < objs.Length; i++) 
		{
			_question_2 [i] = (Question_2)objs [i];
			
		}	
	}

	bool CheckAnswers()
	{
		if (!CompareAnswers()) 
		{
			return false;
		}
		return true;
	}
	bool CompareAnswers()
	{
		if (PickedAnswers.Count > 0) 
		{
			List<int> c = Question_2 [currentQuestion].GetCorrectAnswers ();
			List<int> p = PickedAnswers.Select (x => x.AnswerIndex).ToList();

			var f = c.Except (p).ToList();
			var s = p.Except (c).ToList ();

			return !f.Any () && !s.Any (); //if contain any elements then false, else true
		}
		return false;
	}

	private void UpdateScore(int add)
	{
		events.currentFinalScore += add;

		if (events.ScoreUpdated != null) 
		{
			events.ScoreUpdated ();
			
		}
	}
}
*/