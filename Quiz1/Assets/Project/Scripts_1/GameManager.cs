using System.Collections;
using System.Collections.Generic;//Create List
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;//for ToList


public struct quiz_question {
	public int id;				//harci hamar
	public bool ans_status;     //harci vichak chisht\sxal

	public quiz_question(int id) {
		this.id = id;
		ans_status = false;
	}

	public quiz_question(int id, bool state) {
		this.id = id;
		ans_status = state;
	}

	public override string ToString() {
		return id + "_" + ans_status;			
	}
} 

public struct quiz_result {
	private List<quiz_question> _quest;
	public bool initialized;
	public quiz_result(int count) {
		initialized = false;
		_quest = new List<quiz_question>();
		for(int i = 0; i < count; i++) {
			_quest.Add(new quiz_question(i));
		}
	}

	public void SetStatus(int id, bool state) {
		_quest[id] = new quiz_question(id, state);
	}

	public override string ToString() {
		string retValue = "";
		for(int i = 0; i < _quest.Count; i++) {
			retValue += _quest[i].ToString();
			if(i < _quest.Count - 1) {
				retValue += ':';
			}
		}
		return retValue;
	}
}



public class GameManager : MonoBehaviour {

	public static GameManager instance;
	public Question[] question;
	private static List<Question> unansweredQuestion;
	private Question currentQuestion;

	[HideInInspector]
	public static string key_1;

	[HideInInspector]
	public static string k1;

	[SerializeField]
	private Text factText;

	[SerializeField]
	private Text trueAnswer;

	[SerializeField]
	private Text falseAnswer;

	[SerializeField]
	private Animator animator;

	[SerializeField]
	private float timeBetweenQuestions = 1f;


	[SerializeField]
	private Text last_quest;

	private static quiz_result QuizData;
	private bool _temp_AnswerIsProcessing = false;
	static int index = 0;

	void Awake()
	{
		instance = this;
	}

	void Start () 
	{
		if (unansweredQuestion == null) 
		{
			unansweredQuestion = question.ToList<Question> ();
		}
		Debug.LogWarning(QuizData.initialized);
		if (!QuizData.initialized) {
			QuizData = new quiz_result(question.Length);
			QuizData.initialized = true;
		}
		GetCurrentQuestion();
		_temp_AnswerIsProcessing = false;

	}


	void GetCurrentQuestion()
	{
		int randomQuestionIndex = Random.Range (0, unansweredQuestion.Count);
		currentQuestion = unansweredQuestion [randomQuestionIndex ];
		factText.text = currentQuestion.fact;
		trueAnswer.text = currentQuestion.isTrue ? " CORRECT " : " WRONG ";
		falseAnswer.text = currentQuestion.isTrue ? " WRONG " : " CORRECT ";

	}

	IEnumerator TransitionToTheNextQuestion()
	{
		yield return new WaitForSeconds (timeBetweenQuestions);
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
		
	}
		
	public void userSelectTrue()
	{
		if (_temp_AnswerIsProcessing)
			return;
		animator.SetTrigger ("False");
		Correcter_2();
	}

	public void userSelectFalse()
	{
		if (_temp_AnswerIsProcessing)
			return;
		animator.SetTrigger ("True");
		Correcter_1();
	}

	public void Correcter_1() {
		_temp_AnswerIsProcessing = true;
		unansweredQuestion.Remove(currentQuestion); // This way we won't meet the same question twice
		if (!currentQuestion.isTrue) {
			Debug.Log("CORRECT");
		} else {
			Debug.Log("WRONG");
		}
		QuizData.SetStatus(index, !currentQuestion.isTrue);
		index++;
		if (unansweredQuestion.Count != 0)
			StartCoroutine(TransitionToTheNextQuestion());
		if (unansweredQuestion.Count == 0) {//Questions ENDED
			Debug.Log(QuizData.ToString());
			Debug.Log(Encoder.Base64Encode(QuizData.ToString()));
			key_1 = Encoder.Base64Encode (QuizData.ToString ());
			KeysHolder.instance.SetKey1(key_1);
			//result.text = " Copy Result " + key_1; //not working
			GettingEncodeData (key_1);
		}
	}


	public void Correcter_2() {
		_temp_AnswerIsProcessing = true;
		unansweredQuestion.Remove(currentQuestion);
		if (currentQuestion.isTrue) {
			Debug.Log("CORRECT");
		} else {
			Debug.Log("WRONG");
		}
		QuizData.SetStatus(index, !currentQuestion.isTrue);
		index++;
		if (unansweredQuestion.Count != 0)
			StartCoroutine(TransitionToTheNextQuestion());
		if (unansweredQuestion.Count == 0) {//Questions ENDED
			if (last_quest.enabled == true) {
				last_quest.enabled = false;
				Debug.Log (QuizData.ToString ());
				Debug.Log (Encoder.Base64Encode (QuizData.ToString ()));
			
				key_1 = Encoder.Base64Encode (QuizData.ToString ());
				KeysHolder.instance.SetKey1 (key_1);
				//result.text = " Copy Result " + key_1;
				GettingEncodeData (key_1);
			}
		}
	}

	public static string GettingEncodeData(string k1)
	{
		k1 = key_1;
		KeysHolder.instance.SetKey1 (key_1);
		Debug.Log("1st result: " + k1 );
		return k1;
	}

}



