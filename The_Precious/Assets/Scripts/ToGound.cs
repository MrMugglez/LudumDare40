using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToGound : MonoBehaviour {

	void Awake()
	{
		Ray ray = new Ray();
		ray.origin = transform.position;
		ray.direction = Vector3.down;

		RaycastHit hit;
		if (Physics.Raycast (ray, out hit)) 
		{
			transform.position = new Vector3(transform.position.x, hit.transform.position.y, transform.position.z);
		}
	}
}
