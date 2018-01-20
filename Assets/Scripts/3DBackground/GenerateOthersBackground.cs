using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateOthersBackground : MonoBehaviour 
{
	public GameObject[] background;

	void OnTriggerExit2D(Collider2D coll){

		if (coll.gameObject.tag == "BackgroundCollider") {

			int salut = Random.Range (0, background.Length - 1);
            Instantiate(background[salut], new Vector3(0, 20, 24), transform.rotation);
		}

	}

}