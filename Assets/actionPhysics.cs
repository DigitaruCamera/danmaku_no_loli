using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class actionPhysics : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject bombPrebab;
    Vector2 oldPosition;
    Vector2 directionBomb;
    private void FixedUpdate()
    {
        Vector2 newPosition = new Vector2(transform.position.x, transform.position.y);
        directionBomb = newPosition - oldPosition;
        directionBomb *= 5;
        oldPosition = newPosition;
    }

    public void useBomb()
    {
        GameObject bomb = Instantiate(bombPrebab, transform.position, transform.rotation) as GameObject;
        bomb.name = bombPrebab.name;
        bomb.GetComponent<Rigidbody2D>().velocity = directionBomb;
        Destroy(bomb, 3f);
    }

    public void shotBullet(float nb_bullet, float angle_bullet)
    {
        float i = -1;
        while (i++ < nb_bullet)
        {
            float angle = ((i / nb_bullet) * angle_bullet) - (angle_bullet / 2);
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation * Quaternion.Euler(0, 0, angle)) as GameObject;
            bullet.name = bulletPrefab.name;
            Destroy(bullet, 10f);
        }
    }
}
