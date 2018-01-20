using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerInteration : MonoBehaviour
{
    public float delay_bomb = 5f;
    public float delay_bullet = 0.5f;
    public float nb_bullet = 3f;
    public float angle_bullet = 15f;
    float delayed_bomb = 0;
    float delayed_bullet = 0;
    int point = 0;
    public Text UI_point;
    public GameObject UI_death;
    public GameObject UI_pause;

    public void Update()
    {
        if (Input.touchCount >= 2 && delayed_bomb < Time.time)
        {
            delayed_bomb = Time.time + delay_bomb;
            GetComponent<actionPhysics>().useBomb();
        }
        if (delayed_bullet < Time.time)
        {
            delayed_bullet = Time.time + delay_bullet;
            GetComponent<actionPhysics>().shotBullet(nb_bullet, angle_bullet);
        }
    }
}
