using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouvTactil : MonoBehaviour {
	void Update () {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            var dist = (transform.position - Camera.main.transform.position).z;
            Vector3 player = Camera.main.ViewportToWorldPoint(new Vector3(
                Input.GetTouch(0).deltaPosition.x,
                Input.GetTouch(0).deltaPosition.y,
                dist));
            player = new Vector3(transform.position.x + player.x, transform.position.y + player.y, transform.position.z);
            GetComponent<Rigidbody2D>().MovePosition(player);
        }
	}
}
