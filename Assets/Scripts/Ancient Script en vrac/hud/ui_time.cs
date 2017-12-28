using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ui_time : MonoBehaviour {
	public Text  uitime;
	float    time;
	int      cent;
	int      sec;
	int      min;
	string   text;

	void Update () {
		time = time + Time.deltaTime;
		cent = (int)(time * 100);
		cent = cent % 100;
		sec = (int) time;
		sec = (sec % 60);
		min = (int)time;
		min = min / 60;
		text = min.ToString () + " : " + sec.ToString () + " : " +cent.ToString ();
		uitime.text = text;

		PlayerPrefs.SetString ("lasttime", text);

		if (time > PlayerPrefs.GetFloat("time", 0.0f))
			{
				PlayerPrefs.SetString ("savetime", text);
				PlayerPrefs.SetFloat ("time", time);
			}
	}
}