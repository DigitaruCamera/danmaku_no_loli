using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerBullet : MonoBehaviour {

	private GameObject GOTarget;
	private Transform TransTarget;
	private bool CanLook = true;

	void Start (){

		GOTarget = GameObject.Find ("Player_physic");
		TransTarget = GOTarget.transform;
		StartCoroutine (Wait());
	}

	void Update (){

		if (CanLook == true)
        {
			transform.LookAt (TransTarget);
		}
	}

	IEnumerator Wait(){
		CanLook = true;
		yield return new WaitForSeconds(3f);
		CanLook = false;
		yield return new WaitForSeconds(1f);
		transform.GetChild (0).gameObject.SetActive (false);
		transform.GetChild (1).gameObject.SetActive (true);
		Destroy(gameObject, 2);
	}

}
