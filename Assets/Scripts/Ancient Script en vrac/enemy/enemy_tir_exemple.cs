using UnityEngine;
using System.Collections;

public class enemy_tir_exemple : MonoBehaviour {

	public GameObject EbulletA;
	public GameObject EbulletB;
	double current_time = 0;
	double time_delayed_switch = 0;
	double delay_switch = 1;
	double time_delayed_tir = 0;
	double delay_tir = 0.01;
	int bol = 1;

	void Update ()
	{
		current_time += Time.deltaTime;
		if (current_time >= time_delayed_switch) {
			time_delayed_switch += delay_switch;
			bol = bol * -1;
		}
		if (current_time >= time_delayed_tir) {
			time_delayed_tir += delay_tir;
			if (bol == 1)
				Instantiate (EbulletA, transform.position, transform.rotation);
			else if (bol == -1)
				Instantiate (EbulletA, transform.position, transform.rotation);
		}
	}
}
