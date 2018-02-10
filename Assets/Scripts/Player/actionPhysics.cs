using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using dnl;

public class actionPhysics : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject bombPrebab;
    public float delayImmortal = 2;
    Vector2 oldPosition;
    Vector2 directionBomb;

    private void FixedUpdate()
    {
        Vector2 newPosition = new Vector2(transform.position.x, transform.position.y);
        directionBomb = newPosition - oldPosition;
        directionBomb *= 5;
        oldPosition = newPosition;
    }

    public int changeMode(AnimationClip[] anims, int currentMode)
    {
        if (anims.Length != 0)
        {
            currentMode++;
            if (currentMode >= anims.Length)
            {
                currentMode = 0;
            }
            GetComponentInChildren<Animator>().Play(anims[currentMode].name);
        }
        return currentMode;
    }

    public void useBomb()
    {
        GameObject bomb = Instantiate(bombPrebab, transform.position, transform.rotation) as GameObject;
        bomb.name = bombPrebab.name;
        bomb.GetComponent<Rigidbody2D>().velocity = directionBomb;
        Destroy(bomb, 4f);
    }

    public void shotBullet(float nb_bullet, float angle_bullet)
    {
        foreach (Transform bulletSpawn in GetComponentsInChildren<Transform>())
        {
            if(bulletSpawn.gameObject.tag == "bulletSpawn")
			{
				float i = 0;
				while (i < nb_bullet)
				{
					float angle = ((i / nb_bullet) * angle_bullet) - (angle_bullet / 2);
                    Quaternion spawnRot = new Quaternion(bulletSpawn.rotation.x, 0, bulletSpawn.rotation.z, bulletSpawn.rotation.w);
                    GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, spawnRot * Quaternion.Euler(0, 0, angle)) as GameObject;
                    bullet.name = bulletPrefab.name;
					Destroy (bullet, 1f);
					i++;
                }
            }
        }
    }

    IEnumerator becameMortal(float delay)
    {
        float i = 0;
        float inc = delay / 20;
        while (i < delay)
        {
            foreach (Renderer current in GetComponentsInChildren<Renderer>())
            {
                current.enabled = !current.enabled;
            }
            i += inc;
            yield return new WaitForSecondsRealtime(inc);
        }

        foreach (Renderer current in GetComponentsInChildren<Renderer>())
        {
            current.enabled = true;
        }
        GetComponent<Collider2D>().enabled = true;
    }

    public void becameInvinsible()
    {
        GetComponent<Collider2D>().enabled = false;
        StartCoroutine(becameMortal(delayImmortal));
    }
}