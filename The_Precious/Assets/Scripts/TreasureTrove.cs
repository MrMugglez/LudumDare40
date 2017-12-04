using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureTrove : MonoBehaviour {

	public static TreasureTrove instance;

	public List<GameObject> TreasureList;

	void Awake()
	{
		if(instance != null)
		{
			Destroy (gameObject);
		} 
		else 
		{
			instance = this;
		}
	}

	void Start()
	{
		instance = this;
	}

	public GameObject TreasureFinder(KeyValuePair<float, float> kvp)
	{
		for (int i = 0; i < TreasureList.Count; i++) 
		{
			Debug.Log ("Seaching list " + i + " times");
			if (kvp.Key == TreasureList[i].GetComponent<Treasure>().Weight && kvp.Value == TreasureList[i].GetComponent<Treasure>().Value) 
			{
				return TreasureList [i];
			}
		}
		return null;
	}
}
