using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundOffset : MonoBehaviour
{
	public float scrollspeed = 2f;
	private GameObject[] AllBackground;

	void Update (){
		
		AllBackground = GameObject.FindGameObjectsWithTag ("Background");
		foreach (GameObject B in AllBackground) {
		B.transform.Translate (new Vector2(0, -1) * Time.deltaTime * scrollspeed);
		}
	}
}
