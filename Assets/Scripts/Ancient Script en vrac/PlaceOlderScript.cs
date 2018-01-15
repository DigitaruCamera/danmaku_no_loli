using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceOlderScript : MonoBehaviour
{
	public GameObject bullet;
	public GameObject bomb;
	public GameObject FailMenu;
	public bool tire = true;
	bool Dead = false ;

	IEnumerator Start ()
	{
		while (true) {
			if (tire == true){
				Instantiate (bullet, new Vector3(transform.position.x + 0.2f, transform.position.y + 0.4f, transform.position.z), transform.rotation);
				Instantiate (bullet, new Vector3(transform.position.x - 0.2f, transform.position.y + 0.4f, transform.position.z), transform.rotation);
				//	Instantiate (bullet, transform.position, new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z - angle, transform.rotation.w));
				yield return new WaitForSeconds (0.05f);
			}
			else {
				yield return new WaitForSeconds (0.01f);
			}
		}
	}

	void action()
	{
		//============BOMB==============
		if (Input.GetButtonDown("Fire2"))
		{
			Instantiate (bomb, transform.position, transform.rotation);
		}
	}

	void Update ()
	{
		action ();
		if (Dead == true) {
			Destroy(gameObject);
			FailMenu.SetActive(true);
			print ("dead");
		}
	}


	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "Enemy") {
			Dead = true;
			//Destroy (gameObject);
		}
		if (coll.gameObject.tag == "EnemyBullet") {
			Dead = true;
			//Destroy (gameObject);
		}
	}

	void OnParticleCollision (GameObject coll) {
		print ("ParticleEnemyBullethit");
		if (coll.gameObject.tag == "EnemyBullet") {
			Dead = true;
			//Destroy(gameObject);
		}
	}

}