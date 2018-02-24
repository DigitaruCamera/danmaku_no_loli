using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleTest : MonoBehaviour {

	public float live = 50;

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "PlayerBullet") {
			live = live - 1;
		}
		if (live < 0) {
			Destroy(gameObject);
		}
	}
		
}
