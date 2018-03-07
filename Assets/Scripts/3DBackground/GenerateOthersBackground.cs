using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateOthersBackground : MonoBehaviour 
{
	public GameObject[] Background;
	public float Profondeur = 25;
	public float Lean = 180;

	void OnTriggerExit2D(Collider2D coll){

		if (coll.gameObject.tag == "BackgroundCollider") {
<<<<<<< HEAD
			int RandomResult = Random.Range (0, Background.Length);
			Instantiate(Background[RandomResult], new Vector3(0, 25, Profondeur), Quaternion.Euler(Lean, 0 ,180));
=======

			int salut = Random.Range (0, background.Length);
            if (background[salut] != null)
            {
                Instantiate(background[salut], new Vector3(0, 20, 25), transform.rotation);
            }
>>>>>>> EnemyEditor
		}

	}

	void Start(){
		Destroy (gameObject, 40f);
	}

}