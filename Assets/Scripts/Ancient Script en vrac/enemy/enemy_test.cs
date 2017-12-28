using UnityEngine;
using System.Collections;

public class enemy_test : MonoBehaviour {

	public float frequence = 1;
	public GameObject Ebullet;

	IEnumerator Start ()
	{
		while (true) {
			Instantiate (Ebullet, transform.position, transform.rotation);
			yield return new WaitForSeconds (frequence);
		}
	}
}
