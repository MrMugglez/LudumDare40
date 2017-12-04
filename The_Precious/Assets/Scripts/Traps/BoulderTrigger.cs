using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderTrigger : MonoBehaviour {

	BoulderTrap boulderTrap;

	void Start () 
	{
		boulderTrap = GetComponentInParent<BoulderTrap> ();
	}

	void OnTriggerEnter(Collider coll)
	{
		if (coll.tag == "Player") 
		{
			boulderTrap.Active = true;
		}
	}
}
