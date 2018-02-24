using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossTest : MonoBehaviour {

	public float live = 100;
	public string SceneName;

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "PlayerBullet") {
			live = live - 1;
		}
		if (live < 0) {
			Destroy(gameObject);
			SceneManager.LoadScene (SceneName);
		}
	}

}