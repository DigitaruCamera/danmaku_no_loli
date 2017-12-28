using UnityEngine;
using System.Collections;

public class Bullet_sin : MonoBehaviour
{

	public float Bspeed = 0.1f;
	public float lifeTime = 2;
	float basic_pos;
	double current_time = 0;
	double time_delayed = 0;
	double delay = 0.01;

	void Start ()
	{
		basic_pos = transform.localPosition.x;
		Destroy (gameObject, lifeTime);
	}

	void Update()
	{
		current_time += Time.deltaTime;
		if (current_time >= time_delayed && Time.deltaTime != 0) {
			time_delayed += delay;
			transform.localPosition = new Vector2 (Mathf.Cos (transform.localPosition.y) + basic_pos, transform.localPosition.y - Bspeed);
		}
	}

	IEnumerator OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "bomb") {
			GetComponent<Animation>().Play ("1to0scale");
			yield return new WaitForSeconds (0.05f);
			Destroy (gameObject);
		}
	}
}