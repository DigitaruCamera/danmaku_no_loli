using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTest : MonoBehaviour {

	public float frequence = 1;
	public GameObject EnemyBullet;
	public float live = 100;

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "PlayerBullet") {
			live = live - 1;
		}
		if (live < 0) {
			Destroy(gameObject);
		}
	}


	IEnumerator Start ()
	{
		while (true) {
			Instantiate (EnemyBullet, transform.position, transform.rotation);
			yield return new WaitForSeconds (frequence);
		}
	}

	void Update () {
		transform.Rotate (Vector3.back * 50 * Time.deltaTime);
	}
}
