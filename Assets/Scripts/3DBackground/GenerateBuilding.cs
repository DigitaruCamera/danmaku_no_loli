using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateBuilding : MonoBehaviour {

	public GameObject[] Building;

	void Awake (){

		int RandomResult = Random.Range (0, Building.Length);
		GameObject Child = Instantiate(Building[RandomResult], transform.position, transform.rotation);
		Child.transform.parent = transform;
	}
}