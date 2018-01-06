using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouvTactil : MonoBehaviour {
    void Update()
    {
        Camera c = Camera.main;
        Vector3 p = new Vector3();
        Event e = Event.current;
        float dist = (transform.position - Camera.main.transform.position).z;
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
            {
            Vector2 mousePos = Input.GetTouch(0).position;
            mousePos.x = e.mousePosition.x;
            mousePos.y = c.pixelHeight - e.mousePosition.y;

            p = c.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, dist));
            GetComponent<Rigidbody2D>().MovePosition(p);
        }
    }
    void OnGUI()
    {
        Vector3 p = new Vector3();
        Camera c = Camera.main;
        Event e = Event.current;
        Vector2 mousePos = new Vector2();
        float dist = (transform.position - Camera.main.transform.position).z;

        // Get the mouse position from Event.
        // Note that the y position from Event is inverted.
        mousePos.x = e.mousePosition.x;
        mousePos.y = c.pixelHeight - e.mousePosition.y;

        p = c.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, dist));
        GetComponent<Rigidbody2D>().MovePosition(p);

        GUILayout.BeginArea(new Rect(20, 20, 250, 120));
        GUILayout.Label("Screen pixels: " + c.pixelWidth + ":" + c.pixelHeight);
        GUILayout.Label("Mouse position: " + mousePos);
        GUILayout.Label("World position: " + p.ToString("F3"));
        GUILayout.EndArea();
    }
}
