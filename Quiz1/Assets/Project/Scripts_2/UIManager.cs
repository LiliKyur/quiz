/*using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

[Serializable()] //viewing in the inspector
public struct UIManagerParameters
{
	[Header("Answers Option")]
	[SerializeField] 
	private float Margins;
}
[Serializable()]
public struct UIElements
{
	[SerializeField]
	private RectTransform AnswersContentArea;

	[SerializeField]
	private Text questionInfoTextObj;

	[SerializeField]
	private Text scoreText;

	[Space]
	[SerializeField]
	private Image resolutionBackgrnd;

	[SerializeField]
	private Text resolutionStateInfo;

	[SerializeField]
	private Text resolutionScoreInfo;

	[Space]
	[SerializeField]
	private Text highScoreText;

	[SerializeField]
	private CanvasGroup mainCanvasGroup;

	[SerializeField]
	private RectTransform finishUIElements;
}
public class UIManager : MonoBehaviour {

	public enum ResolutionScreenType { Correct, Incorrect, Finish }  
	[Header("References")]
	[SerializeField] GameEvents events;

	[Header("UI Elements (Prefabs)")]
	[SerializeField] AnswerData answerPrefab;

	[SerializeField] UIElements uiElements;

	[Space]
	[SerializeField] UIManagerParameters parameters;

	List<AnswerData> currentAnswer = new List<AnswerData> ();

	void OnEnable()
	{
		events.UpdateQuestionUI += UpdateQuestionUI;
	}
	void OnDisable()
	{
		
	}
	void UpdateQuestionUI (Question_2 question)
	{
		uiElements.questionInfoTextObj.text = question.Info;
		CreateAnswers ();

	}
	void CreateAnswers(Question_2 question)
	{
		EraseAnswers ();

		//creating answers
		float offset = 0 - parameters.Margins;
		for (int i = 0; i < question.Answer.Length; i++) 
		{
			AnswerData newAnswer = (AnswerData)Instantiate (answerPrefab, uiElements.AnswersContentArea);
			newAnswer.UpdateData (question.Answer[i].Info, i);

			newAnswer.Rect.anchoredPosition = new Vector2 (0, offset);

			offset -= (newAnswer.Rect.sizeDelta.y + parameters.Margins);
			uiElements.AnswersContentArea.sizeDelta = new Vector2 (uiElements.AnswersContentArea.sizeDelta.x, offset * (-1));

			currentAnswer.Add (newAnswer);
			
		}
	}
	void EraseAnswers()
	{
		foreach (var answer in currentAnswer) 
		{
			Destroy (answer.gameObject);	
		}
		currentAnswer.Clear ();
	}
}
*/