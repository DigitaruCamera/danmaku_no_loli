﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogManager : MonoBehaviour {

	public GameObject DialogueBox;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (DialogueBox.activeSelf == true) {
			Time.timeScale = 0;
			GameObject.Find ("Player_physic").GetComponent<PlayerMouvTactil> ().enabled = false;
		} 
		if (DialogueBox.activeSelf == false) {
			Time.timeScale = 1;
			GameObject.Find ("Player_physic").GetComponent<PlayerMouvTactil> ().enabled = true;
			GetComponent<DialogManager> ().enabled = false;
		} 
	}
}
