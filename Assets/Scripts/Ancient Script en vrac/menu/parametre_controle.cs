using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class parametre_controle : MonoBehaviour {
	public float speed;
	public Slider slidespeed;

	void Awake ()
	{
		if (slidespeed) {
			speed = PlayerPrefs.GetFloat ("curspeed");
			slidespeed.value = speed;
		}
	
	}

	public void speedcontrol (float speedcontrol)
	{
		speed = speedcontrol;
		PlayerPrefs.SetFloat ("curspeed", speed);
	}
}