using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleSpawner : MonoBehaviour {

	public int range = 4;
	public GameObject Module1;
	public GameObject Module2;
	public GameObject Module3;
	public GameObject Module4;

/*	void Start (){
		Instantiate (Module1, transform.position, transform.rotation);
	}*/

	void Start (){

			int salut = Random.Range (1, range);

			if (salut == 1)
				Instantiate (Module1, transform.position, transform.rotation);

			if (salut == 2)
				Instantiate (Module2, transform.position, transform.rotation);

			if (salut == 3)
				Instantiate (Module3, transform.position, transform.rotation);

			if (salut == 4)
				Instantiate (Module4, transform.position, transform.rotation);
	}

	void Update(){

		int NbModule = GameObject.FindGameObjectsWithTag ("Module").Length;

		if (NbModule < 4) {

			print ("NeedModule");

		}
	}
}