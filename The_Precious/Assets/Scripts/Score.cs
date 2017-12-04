using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	public Text TimeValue;
	public Text TreasureValue;
	public Text ScoreValue;

	float sumOfTreasure;
	float totalScore;

	public bool CalculateOnce;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void DisplayScores()
	{
		TimeValue.text = Mathf.Round(GameManager.instance.TimeElapsed).ToString() + " Seconds";
		TreasureValue.text = (sumOfTreasure * GameManager.instance.PointsPerTreasureValue).ToString();
		ScoreValue.text = totalScore.ToString();

	}

	public void CalculateScore()
	{
		if (!CalculateOnce) 
		{
			for (int i = 0; i < GameManager.instance.player.treasures.Count; i++) {
				sumOfTreasure += GameManager.instance.player.treasures [i].Value;
			}
			totalScore = (sumOfTreasure * GameManager.instance.PointsPerTreasureValue) - (Mathf.Round (GameManager.instance.TimeElapsed) * GameManager.instance.PointsPerSecondWasted);
		}
	}
}
