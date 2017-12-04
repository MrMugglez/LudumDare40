using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour {

	public int Damage;

	void OnTriggerEnter(Collider coll)
	{
		//Debug.Log (coll.tag + " got Spiked!");
		if (coll.tag == "Player") 
		{
			coll.GetComponent<Player> ().currentHealth -= Damage;
			//Debug.Log (coll.tag + "'s health is now " + coll.GetComponent<Player> ().currentHealth);
		}
	}
}
