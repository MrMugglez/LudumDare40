using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {

	public int Damage;
	public float Speed;
	private int arrowDurability = 3;

	void Update()
	{
		transform.Translate (Vector3.forward * Speed * Time.deltaTime);
	}

	void OnTriggerEnter(Collider coll)
	{
		if(coll.tag == "Wall")
		{
			arrowDurability--;
		}
		//Debug.Log ("Arrow durability is " + arrowDurability);
		if (coll.tag == "Player") 
		{
			coll.GetComponent<Player> ().currentHealth -= Damage;
			Destroy (gameObject);
		}
		if (arrowDurability <= 0) 
		{
			Destroy (gameObject);
		}
	}
}
