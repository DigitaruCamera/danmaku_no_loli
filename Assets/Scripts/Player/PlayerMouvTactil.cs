using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouvTactil : MonoBehaviour
{
    Vector3 diffPos;
    bool isTouch = true;

    Vector3 BlockOnCamera(Vector3 pos)
    {
        float dist = Mathf.Abs(pos.z - Camera.main.transform.position.z);
        float leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).x;
        float rightBorder = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, dist)).x;
        float topBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).y;
        float bottomBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, dist)).y;
        pos = new Vector3(
            Mathf.Clamp(pos.x, leftBorder, rightBorder),
            Mathf.Clamp(pos.y, topBorder, bottomBorder),
            pos.z);
        return (pos);
    }

    void FixedUpdate()
    {
        Vector3 touchPos = new Vector3();
        if (Input.touchCount > 0)
        {
            Vector2 mousePos = Input.GetTouch(0).position;
            if (Input.GetButton("Fire1"))
            {
                print("mous mouve");
                mousePos.x = Event.current.mousePosition.x;
                mousePos.y = Camera.main.pixelHeight - Event.current.mousePosition.y;
            }
            touchPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 15));
            if (isTouch == true || BlockOnCamera(touchPos + diffPos) != touchPos + diffPos)
            {
                diffPos = transform.position - touchPos;
                isTouch = false;
            }
            GetComponent<Rigidbody2D>().MovePosition(BlockOnCamera(touchPos + diffPos));
        }
        else
        {
            isTouch = true;
        }
    }
}
