using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeFloor : MonoBehaviour {

	public float ActivationTime;
	public float DeactivationTime;
	public Transform SpikesBellow;

	// Use this for initialization
	void Start () 
	{
		timer = (ActivationTime + DeactivationTime);
	}
	void Update()
	{
		timer += Time.deltaTime;
	}

	float timer;
	void OnTriggerStay(Collider coll)
	{
		if(coll.tag == "Player")
		{			
			if (timer >= (ActivationTime + DeactivationTime)) {						
				StartCoroutine (ActivateSpikes());
				timer = 0f;
			}
		}
	}

	IEnumerator ActivateSpikes()
	{
		yield return new WaitForSeconds (ActivationTime);
		SpikesBellow.localPosition = Vector3.zero; 
		yield return new WaitForSeconds (DeactivationTime);
		SpikesBellow.localPosition = new Vector3(0f, -0.75f, 0); 
	}

	//void 
}
