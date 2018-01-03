using System.Collections;
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
			print ("In To Dialogue");
			Time.timeScale = 0;
			GameObject.Find ("Player_physic").GetComponent<PlayerMainScript_old> ().enabled = false;
		} 
		if (DialogueBox.activeSelf == false) {
			print ("Out Of Dialogue");
			Time.timeScale = 1;
			GameObject.Find ("Player_physic").GetComponent<PlayerMainScript_old> ().enabled = true;
			GameObject.Find ("UI_Manager").GetComponent<DialogManager> ().enabled = false;
		} 
	}
}
