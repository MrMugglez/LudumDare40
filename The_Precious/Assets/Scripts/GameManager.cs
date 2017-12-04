using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour 
{
	[HideInInspector]
	public static GameManager instance;

	public int PointsPerTreasureValue;
	public int PointsPerSecondWasted;

	[HideInInspector]
	public float TimeElapsed;
	[HideInInspector]
	public bool GameStart = false;
	[HideInInspector]
	public bool GameEnd = false;
	[HideInInspector]
	public Player player;
	bool restart = false;

	void Awake()
	{
		if(instance != null)
		{
			Destroy (gameObject);
		} 
		else 
		{
			instance = this;
		}
	}

	void Start () 
	{
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
		UIHandler.instance.ScoreScreen.SetActive (false);
		StartCoroutine (Ready());
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (GameStart && !GameEnd) 
		{
			TimeElapsed += Time.deltaTime;
		}
		if (GameEnd) {
			UIHandler.instance.ScoreScreen.SetActive (true);
			UIHandler.instance.ScoreScreen.GetComponentInChildren<Score> ().CalculateScore();
			UIHandler.instance.ScoreScreen.GetComponentInChildren<Score> ().CalculateOnce = true;
			UIHandler.instance.ScoreScreen.GetComponentInChildren<Score> ().DisplayScores();
		}
		if(Input.GetButton("Cancel") && GameEnd)
		{
			SceneManager.LoadScene ("Credits");
		}
		if (player.Dead && !restart) 
		{
			StartCoroutine (Restart());
			restart = true;
		}
	}

	IEnumerator Ready()
	{
		UIHandler.instance.ReadyGo.text = "Ready...";
		yield return new WaitForSeconds (2);
		UIHandler.instance.ReadyGo.text = "GO!";
		GameStart = true;
		yield return new WaitForSeconds (1);
		UIHandler.instance.ReadyGo.text = " ";
	}

	IEnumerator Restart()
	{
		UIHandler.instance.ReadyGo.text = "Dead...";
		yield return new WaitForSeconds (1);
		SceneManager.LoadScene ("Main");
	}
}
