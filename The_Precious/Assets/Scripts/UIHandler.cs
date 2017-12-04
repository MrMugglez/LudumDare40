using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour {

	public static UIHandler instance;

	public Player Player;

	public Slider Health;
	public Slider Stamina;
	public Text Weight;
	public GameObject Gathering;
	[HideInInspector]
	public float GatherTime;
	public Text ReadyGo;
	public GameObject ScoreScreen;

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

	// Use this for initialization
	void Start () 
	{
		Health.maxValue = Player.MaxHealth;
		Stamina.maxValue = Player.MaxStamina;
	}
	
	// Update is called once per frame
	void Update () 
	{
		Health.value = Player.currentHealth;
		Stamina.value = Player.currentStamina;
		Weight.text = "Weight: " + Player.currentWeight;
		if (Player.timer > 0) 
		{
			Gathering.SetActive (true);
			Gathering.GetComponentInChildren<Slider> ().maxValue = GatherTime;

			Gathering.GetComponentInChildren<Slider> ().value = Player.timer;

		} 
		else 
		{
			Gathering.SetActive (false);
		}
	}

	public void Gather(bool isGathering, float gatherTimer, float currentTime)
	{
		Gathering.SetActive (isGathering);
	}
}
