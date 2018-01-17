using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundOffset : MonoBehaviour
{
	public float scrollspeed = 2f;

	void Update (){

		transform.Translate (new Vector3(0, -1, 0) * Time.deltaTime * scrollspeed);
	}

	void OnBecameInvisible() {
		Destroy(gameObject, 1);
	}
}
