﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouvTactil : MonoBehaviour
{
    Vector3 BlockOnCamera(Vector3 pos)
    {
        float dist = Mathf.Abs(pos.z - Camera.main.transform.position.z);

        float leftBorder = Camera.main.ViewportToWorldPoint(
            new Vector3(0, 0, dist)).x;

        float rightBorder = Camera.main.ViewportToWorldPoint(
            new Vector3(1, 0, dist)).x;

        float topBorder = Camera.main.ViewportToWorldPoint(
            new Vector3(0, 0, dist)).y;

        float bottomBorder = Camera.main.ViewportToWorldPoint(
            new Vector3(0, 1, dist)).y;

        Debug.Log(dist);

        float width = Mathf.Abs(rightBorder);
        float heigth = Mathf.Abs(bottomBorder);
        float ratio_x = width / Camera.main.pixelWidth;
        float ratio_y = heigth / Camera.main.pixelHeight;
        //Debug.Log("player world" + width + "; " + heigth);
        //Debug.Log("screen" + Screen.width + "; " + Screen.height);
        //Debug.Log("ratio" + ratio_x + "; " + ratio_y);
        //Debug.Log(pos);
        pos = transform.position + new Vector3(pos.x * ratio_x, pos.y * ratio_y, pos.z);
        pos = new Vector3(
            Mathf.Clamp(pos.x, leftBorder, rightBorder),
            Mathf.Clamp(pos.y, topBorder, bottomBorder),
            pos.z);
        Debug.Log(pos);
        return (pos);
    }

    Vector2 mousePos = new Vector2(-1, -1);
    void FixedUpdate()
    {
        if (mousePos.x == -1 && mousePos.y == -1)
        {
            mousePos = new Vector2(Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2);
        }
        Vector3 p = new Vector3();
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            mousePos = Input.GetTouch(0).position;
            //mousePos = Input.GetTouch(0).position;
            p = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 15));
            transform.position = p;

        }
    }
    void OnGUI()
    {
    }
}
