using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour 
{
	public float MaxSpeed;
	private float currentSpeed;

	public float MaxHealth;
	[HideInInspector]
	public float currentHealth;

	public float MaxStamina;
	[HideInInspector]
	public float currentStamina;
	private float staminaModifier;
	private bool startRegen;

	public float MaxWeight;
	public float currentWeight;

	public bool Dead;

	[HideInInspector]
	public List<KeyValuePair<float, float>> treasures;

	// Use this for initialization
	void Start () 
	{
		currentSpeed = MaxSpeed;
		currentHealth = MaxHealth;
		currentStamina = MaxStamina;
		currentWeight = 0f;
		treasures = new List<KeyValuePair<float, float>> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (currentHealth <= 0) 
		{
			Death ();
		}
		if (!Dead && GameManager.instance.GameStart && !GameManager.instance.GameEnd) 
		{
			WeightBurden ();
			Run ();
			Regeneration ();
			Discard ();
		}
	}

	void Run()
	{
		transform.Translate (Vector3.right * Input.GetAxis ("Horizontal") * Sprint(2) * currentSpeed * Time.deltaTime, Space.World); 
		transform.Translate (Vector3.forward * Input.GetAxis ("Vertical") * Sprint(2) * currentSpeed * Time.deltaTime, Space.World);
		transform.LookAt (new Vector3(transform.position.x + Input.GetAxis ("Horizontal"), transform.position.y, transform.position.z + Input.GetAxis ("Vertical")));
	}

	float recoveryTimer;
	float Sprint(float multiplier)
	{		
		if (Input.GetButton("Sprint") && currentStamina > Tiring()) 
		{
			currentStamina -= Tiring ();
			recoveryTimer = 0f;
			startRegen = false;
		} 
		else 
		{
			multiplier = 1f;
			recoveryTimer += Time.deltaTime;
			if (recoveryTimer >= 1f) 
			{
				startRegen = true;
			}
		}
		return multiplier;
	}

	float Tiring()
	{
		if(staminaModifier > 0)
		{
			return 1f * (1f - staminaModifier);
		} 
		else 
		{
			return 0f;
		}
	}

	void Regeneration()
	{	
		if (startRegen) 
		{
			if (currentStamina < MaxStamina) 
			{
				currentStamina += (staminaModifier * 1f) + 0.1f;
			}
			if (currentStamina > MaxStamina) 
			{
				currentStamina = MaxStamina;
			}
		}
	}

	void WeightBurden()
	{
		if(currentWeight >= MaxWeight)
		{
			currentWeight = MaxWeight;
		}
		else 
		{
			currentSpeed = MaxSpeed * staminaModifier;
		}
		if (currentWeight > 0) {
			staminaModifier = 1f - (currentWeight / MaxWeight);
			//Debug.Log ("Current Stamina Modifier is " + staminaModifier);
		} 
		else 
		{
			staminaModifier = 1f;
		}
		if(currentSpeed == 0f)
		{
			currentSpeed = 0.1f;
		}
	}

	[HideInInspector]
	public float timer;
	public void Gather(Treasure treasure, float gatherTime)
	{
		
		if (Input.GetButton("Gather") && GameManager.instance.GameStart && !GameManager.instance.GameEnd) 
		{	
			timer += Time.deltaTime;
			//Debug.Log ("current timer " + timer);
			if (timer >= gatherTime) 
			{
				treasures.Add (new KeyValuePair<float, float> (treasure.Weight, treasure.Value));
				Debug.Log ("# of Treasures is " + treasures.Count);
				currentWeight += treasure.Weight;
				Destroy (treasure.gameObject);
				timer = 0f;
			} 
		}
		else 
		{
			timer = 0f;
		}
	}

	void Discard()
	{
		if (Input.GetButtonDown("Discard")) 
		{
			if (treasures.Count > 0) 
			{
				int randTreasure = Random.Range (0, treasures.Count);
				GameObject treasure = TreasureTrove.instance.TreasureFinder (treasures [randTreasure]);
				//Debug.Log (TreasureTrove.instance.TreasureFinder (treasures [randTreasure]));
				Instantiate (treasure, gameObject.transform.position, Quaternion.identity);
				currentWeight -= treasure.GetComponent<Treasure> ().Weight;
				treasures.RemoveAt (randTreasure);
			}
		}
	}

	void Death()
	{
		GetComponent<Rigidbody> ().isKinematic = true;
		GetComponent<Collider> ().isTrigger = true;
		Dead = true;
	}
}
