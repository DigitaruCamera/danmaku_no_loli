using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouvTactil : MonoBehaviour
{
    Vector3 BlockOnCamera(Vector3 pos)
    {
        float dist = (pos - Camera.main.transform.position).z;

        float leftBorder = Camera.main.ViewportToWorldPoint(
            new Vector3(0, 0, dist)).x;

        float rightBorder = Camera.main.ViewportToWorldPoint(
            new Vector3(1, 0, dist)).x;

        float topBorder = Camera.main.ViewportToWorldPoint(
            new Vector3(0, 0, dist)).y;

        float bottomBorder = Camera.main.ViewportToWorldPoint(
            new Vector3(0, 1, dist)).y;

        pos = new Vector3(
            Mathf.Clamp(pos.x, leftBorder, rightBorder),
            Mathf.Clamp(pos.y, topBorder, bottomBorder),
            pos.z);
        return (pos);
    }

    void Update()
    {
        Camera c = Camera.main;
        Vector3 p = new Vector3();
        Event e = Event.current;
        float dist = (transform.position - Camera.main.transform.position).z;
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            Vector2 mousePos = Input.GetTouch(0).position;
            p = c.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, dist));
            Vector3 final_pos = transform.position - p;
            final_pos = BlockOnCamera(final_pos);
            GetComponent<Rigidbody2D>().MovePosition(p);
        }
    }
}
