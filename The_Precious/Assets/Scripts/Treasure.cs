using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : MonoBehaviour 
{
	public float Weight;
	public float Value;
	public float GatherTime;

	void OnTriggerStay(Collider coll)
	{
		if(coll.tag == "Player")
		{
			coll.GetComponent<Player> ().Gather (this, GatherTime);
			UIHandler.instance.GatherTime = GatherTime;
		}
	}
	void OnTriggerExit(Collider coll)
	{
		if (coll.tag == "Player") {
			coll.GetComponent<Player> ().timer = 0;
		}
	}
}
