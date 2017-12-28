using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour {

	public float frequence = 5;
	public GameObject Enemy;

	IEnumerator Start ()
	{
		while (true) {
			Instantiate (Enemy, transform.position, transform.rotation);
			yield return new WaitForSeconds (frequence);
		}
	}
}
