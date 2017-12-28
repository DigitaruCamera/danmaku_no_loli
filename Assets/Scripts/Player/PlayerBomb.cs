using UnityEngine;
using System.Collections;

public class PlayerBomb : MonoBehaviour 
{

	public int Bspeed = 0;
	public float lifeTime = 2;

	void Start ()
	{
		GetComponent<Rigidbody2D>().velocity = transform.up.normalized * Bspeed;
//		GameObject.Find ("SceneManager").GetComponent<ui_score>().used += 1;
		Destroy (gameObject, lifeTime);
	}
}
