﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using DG;

public class EraChangeView : MonoBehaviour {

	public GameModel gameModel;
	public GameObject root;
	public Image back;
	public Text text;

	public string text16;
	public string text32;

	void Start () {
		gameModel.OnEraTransition += OnEraChange;
		root.SetActive(true);
	}
	
	void DoEra(string text)
	{
		root.SetActive(true);
	}

	public void Close()
	{
		root.SetActive(false);
	}

	void Update()
	{
		var c = back.color;
		c.a = Random.Range(0.8f, 1f);
		back.color = c;
	}

	void OnEraChange(GameModel.CurrentEra newEra)
	{
		if (newEra == GameModel.CurrentEra.Sixteenbit)
		{
			DoEra(text16);
		}
		else if (newEra == GameModel.CurrentEra.ThirtyTwoBit)
		{
			DoEra(text32);
		}
	}
}