using UnityEngine;
using System.Collections;

public class Bullet_semiguided : MonoBehaviour
{

	public float Bspeed = 0.1f;
	public float lifeTime = 3;
	float basic_pos;

	void Start ()
	{
		Vector3 diff = GameObject.Find("player").transform.position - transform.position;
		diff.Normalize();
		float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
		Destroy (gameObject, lifeTime);
	}

	void Update()
	{
		transform.Translate (new Vector2 (0, Time.deltaTime) * Bspeed * 50);
	}

	IEnumerator OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "bomb") {
			GetComponent<Animation>().Play ("1to0scale");
			yield return new WaitForSeconds (0.05f);
			Destroy (gameObject);
		}
	}
}