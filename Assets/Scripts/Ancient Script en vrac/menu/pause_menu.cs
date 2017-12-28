using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class pause_menu : MonoBehaviour 
{

	public GameObject player;
	public GameObject fail;
	public GameObject pause;
	public Text ui_timefail;
	public Text ui_scorefail;
	public Text ui_timepause;
	public Text ui_scorepause;
	public string texttime;
	public string textscore;

	void Start () {
		Time.timeScale =1;
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
	}

	void Update () {

		if (Input.GetKeyDown(KeyCode.Escape) && player != null) {
			pause.SetActive(true);
			Time.timeScale =0;
			GameObject.Find ("player").GetComponent<PlayerMainScript_old>().enabled = false;
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
		}

		if (player == null && !(Input.GetKeyDown(KeyCode.Escape))) {
			fail.SetActive(true);
			Time.timeScale = 0;
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;

		} 

		ui_timefail.text = PlayerPrefs.GetString ("lasttime");
		ui_timepause.text = PlayerPrefs.GetString ("lasttime");
		ui_scorefail.text = PlayerPrefs.GetString ("lastscore");
		ui_scorepause.text = PlayerPrefs.GetString ("lastscore");
	}

	public void resume (){
		GameObject.Find ("player").GetComponent<PlayerMainScript_old>().enabled = true;
		Time.timeScale = 1;
		pause.SetActive(false);
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
	}
}
