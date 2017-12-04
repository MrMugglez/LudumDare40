using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boulder : MonoBehaviour {

	BoulderTrap boulderTrap;

	public float Speed;

	void Start () 
	{
		boulderTrap = GetComponentInParent<BoulderTrap> ();
		GetComponent<Rigidbody> ().isKinematic = true;
	}

	public void Roll()
	{
		transform.Translate (Vector3.forward * Speed * Time.deltaTime);
		GetComponent<Rigidbody> ().isKinematic = false;
	}

	public void Stop()
	{
		boulderTrap.Active = false;
	}

	void OnCollisionEnter(Collision coll)
	{
		if (coll.gameObject.tag == "Player") 
		{
			if (boulderTrap.Active == true) 
			{
				coll.gameObject.GetComponent<Player> ().currentHealth = 0;
			}
		}
	}
}
