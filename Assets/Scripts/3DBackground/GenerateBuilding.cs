using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateBuilding : MonoBehaviour {

	public GameObject[] Building;
<<<<<<< HEAD

	void Awake (){

		int RandomResult = Random.Range (0, Building.Length);
		GameObject Child = Instantiate(Building[RandomResult], transform.position, transform.rotation);
		Child.transform.parent = transform;
=======
    int timeCalled = 0;
	void Start (){
>>>>>>> EnemyEditor
	}

    private void OnEnable()
    {
        int salut = Random.Range(0, Building.Length);
        if (Building[salut] != null)
        {
            GameObject Child = Instantiate(Building[salut], transform.position, transform.rotation);
            Child.transform.parent = transform;
        }

    }
}