using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouvTactil : MonoBehaviour {
	void Update () {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            GetComponent<Rigidbody2D>().MovePosition(Input.GetTouch(0).position);
        }
	}
}
