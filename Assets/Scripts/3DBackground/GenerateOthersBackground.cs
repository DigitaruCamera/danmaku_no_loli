using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateOthersBackground : MonoBehaviour 
{
	public GameObject[] Background;
	public float Profondeur = 25;
	public float Lean = 180;

	void OnTriggerExit2D(Collider2D coll){

		if (coll.gameObject.tag == "BackgroundCollider") {
			int RandomResult = Random.Range (0, Background.Length);
			Instantiate(Background[RandomResult], new Vector3(0, 25, Profondeur), Quaternion.Euler(Lean, 0 ,180));
		}

	}

	void Start(){
		Destroy (gameObject, 40f);
	}

}