using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectHUD : MonoBehaviour {

	public GameObject Hud;
	public GameObject HudLarge;
	// Update is called once per frame
	void Update () {

		if (Camera.main.aspect < 1) {
			Hud.SetActive (true);
			HudLarge.SetActive (false);
		} else {
			Hud.SetActive (false);
			HudLarge.SetActive (true);
		}

	}
}
