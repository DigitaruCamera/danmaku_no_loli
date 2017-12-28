using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour {

	void Start() {
		StartCoroutine(Example());
		Time.timeScale = 1;

	}

	IEnumerator Example() {
		yield return new WaitForSeconds(1);
		Application.Quit();
		Debug.Log ("Quited");
	}
}