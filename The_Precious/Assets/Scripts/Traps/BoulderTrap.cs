using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderTrap : MonoBehaviour {

	public bool Active;

	Boulder boulder;
	BoulderTrigger boulderTrigger;

	void Start () 
	{
		boulder = GetComponentInChildren<Boulder> ();
		boulderTrigger = GetComponentInChildren<BoulderTrigger> ();
	}

	void Update () 
	{
		if (Active) {
			boulder.Roll ();
		}
	}
}
