using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundOffset : MonoBehaviour
{
	public float scrollspeed = 2f;

	void start (){		

	}


	void awake (){		

	}

	void Update (){

		Destroy (gameObject, 60);

		transform.Translate (new Vector3(0, -1, 0) * Time.deltaTime * scrollspeed);
	}
}
