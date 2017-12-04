using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guillotine : MonoBehaviour {

	public float Damage;

	void OnCollisionEnter(Collision coll)
	{
		if (coll.gameObject.tag == "Player") {
			coll.gameObject.GetComponent<Player> ().currentHealth -= Damage;
		}
	}
}
