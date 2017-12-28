using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateOthersBackground : MonoBehaviour 
{

	public int range = 4;
	public GameObject background1;
	public GameObject background2;
	public GameObject background3;
	public GameObject background4;

	void start (){
		Instantiate (background1, transform.position, transform.rotation);
	}

	void OnTriggerExit2D(Collider2D coll){

		if (coll.gameObject.tag == "BackgroundCollider") {

			int salut = Random.Range (1, range);

			if (salut == 1)
				Instantiate (background1, new Vector3(0, 25, 3), transform.rotation);

			if (salut == 2)
				Instantiate (background2, new Vector3(0, 25, 3), transform.rotation);

			if (salut == 3)
				Instantiate (background3, new Vector3(0, 25, 3), transform.rotation);

			if (salut == 4)
				Instantiate (background4, new Vector3(0, 25, 3), transform.rotation);
		}

	}

}