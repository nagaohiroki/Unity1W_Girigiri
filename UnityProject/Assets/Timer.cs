﻿using System;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
	public bool IsStop{private get; set;}
	[SerializeField]
	Text mTimer;
	float mCounter;
	int mSecond;
	public void Reset()
	{
		IsStop = false;
		mCounter = 0.0f;
		UpdateTime();
	}
	void UpdateTime()
	{
		mCounter += Time.deltaTime;
		int second = (int)mCounter;
		if(mSecond == second)
		{
			return;
		}
		mSecond = second;
		var span = TimeSpan.FromSeconds(mSecond);
		mTimer.text = span.ToString();
	}
	void Update()
	{
		if(IsStop)
		{
			return;
		}
		UpdateTime();
	}
}