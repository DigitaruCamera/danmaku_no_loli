using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonTest : MonoBehaviour {

	public float frequence = 1;
	public GameObject EnemyBullet;
	Transform Target;

	void Update (){

		Target = GameObject.Find ("Player_physic").transform;
		transform.LookAt (Target);
	}

	IEnumerator Start ()
	{
		while (true) {
//			Instantiate (EnemyBullet, transform.position, transform.rotation);
			Instantiate (EnemyBullet, transform.position, transform.rotation = Quaternion.Euler(0, 0, 180));
			yield return new WaitForSeconds (frequence);
		}
	}
}
