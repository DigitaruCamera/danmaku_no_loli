using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateBuilding : MonoBehaviour {

	public GameObject[] Building;

	void Start (){

			int salut = Random.Range (0, Building.Length - 1);
		GameObject Child = Instantiate(Building[salut], transform.position, transform.rotation);
		Child.transform.parent = transform;
	}
}