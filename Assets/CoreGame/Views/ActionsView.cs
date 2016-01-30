﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;

public class ActionsView : MonoBehaviour {

	public GameModel gameModel;
	public Button buttonPrefab;

	void Start()
	{
		MakeButtons();
	}

	void MakeButtons()
	{
		foreach (Transform child in transform)
		{
			Destroy(child);
		}

		string[] actions = System.Enum.GetNames(typeof(GameModel.ActionType));
		foreach (string action in actions)
		{
			Button actionButton = Instantiate<Button>(buttonPrefab);
			actionButton.transform.SetParent(transform);
			Text buttonLabel = actionButton.GetComponentInChildren<Text>();
			buttonLabel.text = action;

			GameModel.ActionType toDo = (GameModel.ActionType)System.Enum.Parse(typeof(GameModel.ActionType), action);
			print("The action is "+action+" it became "+toDo);

			actionButton.onClick.AddListener(() => {
				gameModel.PerformAction(toDo);
			});

			Vector3 originalScale = actionButton.transform.localScale;
			actionButton.transform.localScale = new Vector3 (0, 0, 0);
			actionButton.transform.DOScale (originalScale, gameModel.gameStartButtonTransitionTime);
		}
	}

}
