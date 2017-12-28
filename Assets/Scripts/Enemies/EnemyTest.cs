using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTest : MonoBehaviour {

	public float frequence = 1;
	public GameObject EnemyBullet;

	IEnumerator Start ()
	{
		while (true) {
			Instantiate (EnemyBullet, transform.position, transform.rotation);
			yield return new WaitForSeconds (frequence);
		}
	}
}
