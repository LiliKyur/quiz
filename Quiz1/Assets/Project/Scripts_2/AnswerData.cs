﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using TMPro;
using UnityEngine.UI;


public class AnswerData : MonoBehaviour {
	
	[Header(" UI Elements ")]
	[SerializeField]
	private Text infoTextObj;
	[SerializeField]
	private Image toggle;

	[Header(" Textures ")]
	[SerializeField] 
	private Sprite uncheckedToggle;
	[SerializeField] 
	private Sprite checkedToggle;

	[Header("References")]
	[SerializeField] 
	private GameEvents events;

	private RectTransform _rect;
	public RectTransform Rect
	{
		get
		{
			if (_rect==null) 
			{
				_rect = GetComponent<RectTransform> () ?? gameObject.AddComponent<RectTransform> ();
				
			}
			return _rect;
		}
	}

	private int _answerIndex = -1;
	public int AnswerIndex { get { return _answerIndex; }}

	private bool Checked = false;

	public void UpdateData(string info, int index)
	{
		infoTextObj.text = info;
		_answerIndex = index;
	}
	public void Reset()
	{
		Checked = false;
		UpdateUI ();
		
	}
	public void SwitchState()
	{
		Checked = !Checked;
		UpdateUI ();

		if (events.UpdateQuestionAnswer != null) 
		{
			events.UpdateQuestionAnswer (this);
		}
	}
	void UpdateUI()
	{
		toggle.sprite = (Checked) ? checkedToggle : uncheckedToggle;
	}
}
