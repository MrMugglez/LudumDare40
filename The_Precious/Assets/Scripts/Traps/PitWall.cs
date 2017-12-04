using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitWall : MonoBehaviour {

	void OnCollisionEnter(Collision coll)
	{
		if(coll.gameObject.tag == "Boulder")
		{
			coll.gameObject.GetComponent<Boulder> ().Stop();
		}
	}
}
