using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ui_score : MonoBehaviour {
	public Text uiscore;		
	public float score;
	string text;
	public Text	bombused;
	public int used;
	string usedtext;
	public GameObject Enemy;

	void Start () {

		score = 0;
		used = 0;


	}

	void Update () {

		usedtext = used.ToString();
		bombused.text = usedtext;

		score = score + Time.deltaTime;

		text = ((int)score).ToString();
		uiscore.text = text;

		PlayerPrefs.SetString ("lastscore", text);

		if (score > PlayerPrefs.GetFloat("score", 0f))
		{
			PlayerPrefs.SetString ("savescore", text);
			PlayerPrefs.SetFloat ("score", score);
		}
	}
}

