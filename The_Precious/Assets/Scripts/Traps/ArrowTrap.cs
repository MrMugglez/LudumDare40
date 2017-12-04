using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTrap : MonoBehaviour 
{
	public GameObject ArrowPrefab;
	public float FireRate;
	public Transform ExitBarrel;

	float timer;
	// Update is called once per frame
	void Update () 
	{
		timer += Time.deltaTime;
		if(timer >= FireRate)
		{
			Instantiate (ArrowPrefab, ExitBarrel.position, ExitBarrel.rotation);
			timer = 0f;
		}
	}
}
