using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateBuilding : MonoBehaviour {

	public GameObject[] Building;
    int timeCalled = 0;
	void Start (){
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