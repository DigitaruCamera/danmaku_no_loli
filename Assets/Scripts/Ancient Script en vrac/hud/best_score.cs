using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class best_score : MonoBehaviour {

	public Text ui_time;
	public Text ui_score;
	public string texttime;
	public string textscore;

	void Start () {
	
	}

	void Update () {

		texttime = PlayerPrefs.GetString ("savetime");
		ui_time.text = texttime;

		textscore = PlayerPrefs.GetString ("savescore");
		ui_score.text = textscore;

		if (Input.GetKeyDown ("r"))
			PlayerPrefs.DeleteAll ();
	}
}
