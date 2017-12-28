using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
	public int Bspeed = 20;
	public int lifeTime = 2;
	public double dispow = 0.2;
	public double power = 3;
	private double delay = 0.1;
	private double time_delayed = 1.0;
	private double time = 0.0;

	public double dispow_bullet()
	{
		time = time + Time.deltaTime;
		if (time >= time_delayed) {
			power = power - dispow;
			time_delayed = time_delayed + delay;
		}
		return (power);
	}

	void Start ()
	{
		power = 3.0;
		GetComponent<Rigidbody2D>().velocity = transform.up.normalized * Bspeed;
		Destroy (gameObject, lifeTime);
	}

	void Update ()
	{
		dispow_bullet ();
	}

	IEnumerator OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "Enemy") {
			GetComponent<Animation>().Play ("1to0scale");
			yield return new WaitForSeconds (0.1f);
			Destroy(gameObject);
		}
	}
}