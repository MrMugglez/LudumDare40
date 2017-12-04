using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingingGuillotineTrap : MonoBehaviour 
{

	public Transform Pendulum;
	public float StartTimeOffset;
	public float Speed;
	bool swingLeft = true;

	Quaternion maxRotation;

	void Start ()
	{
		maxRotation = Pendulum.rotation;
		//Remove this later;
		Pendulum.eulerAngles += Vector3.forward * StartTimeOffset;
	}

	//FIX LATER NEARLY EVERYTHING IS BROKEN
	void Update () 
	{
		if (swingLeft) 
		{
			//Debug.Log (Pendulum.eulerAngles.z + " Swinging Left until " + -maxRotation.eulerAngles.z);
			if (Pendulum.eulerAngles.z == 360-maxRotation.eulerAngles.z) 
			{
				//StartCoroutine (SwingLeft());
				swingLeft = false;
			}
			Pendulum.eulerAngles -= new Vector3 (0f, 0f, 1f) * Speed;
		}
		if (!swingLeft) 
		{
			Debug.Log ("Swinging Right");
			if (Pendulum.eulerAngles.z == maxRotation.eulerAngles.z) 
			{
				//StartCoroutine (SwingRight());
				swingLeft = true;
			}
			Pendulum.eulerAngles += new Vector3 (0f, 0f, 1f);
		}
	}
	/*
	IEnumerator SwingRight()
	{
		Debug.Log ("Swinging Right");
		Quaternion inverse = new Quaternion (maxRotation.x, maxRotation.y,-maxRotation.z, maxRotation.w);
		while (Pendulum.rotation.z != maxRotation.z) 
		{		
			//Pendulum.rotation = Quaternion.Lerp (inverse, maxRotation, 0.5f);
			Pendulum.eulerAngles += new Vector3 (0f, 0f, 1f);
			yield return null;
		}
	}

	IEnumerator SwingLeft()
	{
		Debug.Log ("Swinging Left");
		Quaternion inverse = new Quaternion (maxRotation.x, maxRotation.y, -maxRotation.z, maxRotation.w);
		while (Pendulum.rotation.z != inverse.z) 
		{
			//Pendulum.rotation = Quaternion.Lerp (maxRotation, inverse, 0.5f);
			Pendulum.eulerAngles += new Vector3 (0f, 0f, -1f);
			yield return null;
		}
	}*/
}
