using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pit : MonoBehaviour {

	void OnCollisionEnter(Collision coll)
	{
		if(coll.gameObject.tag == "Player")
		{
			coll.gameObject.GetComponent<Player> ().currentHealth = 0;
		}
		if(coll.gameObject.tag == "Boulder")
		{
			coll.gameObject.GetComponent<Boulder> ().Stop();
		}
	}
}
