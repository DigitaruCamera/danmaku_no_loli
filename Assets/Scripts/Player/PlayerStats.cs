﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public float delay_bomb = 5f;
    public float delay_bullet = 0.5f;
    public float nb_bullet = 3f;
    public float angle_bullet = 15f;
    public int mode = 0;
    public AnimationClip []modesAnims;
    float delayed_bomb = 0;
    float delayed_bullet = 0;
    int currentScore = 0;

    bool changedMode = false;
    public void Update()
    {
        float dist = Mathf.Abs(transform.position.z - Camera.main.transform.position.z);
        float topBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).y;
        float bottomBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, dist)).y;
        float coef_delay_bullet = ((transform.position.y - bottomBorder) / (topBorder - bottomBorder) + 1) / 2;
        GetComponentInParent<Player>().BombBar(delayed_bomb, delay_bomb);
        GetComponentInParent<Player>().affScore(currentScore);
        if (((Input.touchCount >= 2 && Input.GetTouch(1).deltaPosition.y > 5f)
            || (Input.touchCount == 0 && Input.GetButtonDown("Fire2")))
                && delayed_bomb < Time.time && Time.timeScale != 0)
        {
            delayed_bomb = Time.time + delay_bomb;
			GetComponent<actionPhysics> ().useBomb ();
        }
        if (((Input.touchCount >= 2 && Input.GetTouch(1).deltaPosition.y < -5f && changedMode == false )
            || (Input.touchCount == 0 && Input.GetButtonDown("Fire3")))
                && Time.timeScale != 0)
        {
            changedMode = true;
            mode = GetComponent<actionPhysics>().changeMode(modesAnims, mode);
        }
        if (Input.touchCount < 2)
        {
            changedMode = false;
        }
        if (delayed_bullet < Time.time)
        {
            currentScore += 1;
            delayed_bullet = Time.time + (delay_bullet * coef_delay_bullet);
            GetComponent<actionPhysics>().shotBullet(nb_bullet, angle_bullet);
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.tag == "enemyBullet" || other.tag == "Enemy")
        {
            ParticleSystem particleSystem = other.GetComponent<ParticleSystem>();
            ParticleSystem.Particle[] particles = new ParticleSystem.Particle[particleSystem.particleCount];
            int closeParticle = -1;
            float closeRange = -1f;
            particleSystem.GetParticles(particles);
            for (int i = 0; i < particles.Length; i++)
            {
                float range = Vector3.Distance(particles[i].position, transform.position);
                if (range < closeRange || closeRange == -1)
                {
                    closeRange = range;
                    closeParticle = i;
                }
            }
            particles[closeParticle].remainingLifetime = -1;
            particleSystem.SetParticles(particles, particles.Length);
            GetComponentInParent<Player>().deathEnable();
            GetComponentInParent<Player>().saveScore(currentScore);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemyBullet" || collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            Time.timeScale = 0;
            GetComponentInParent<Player>().deathEnable();
            GetComponentInParent<Player>().saveScore(currentScore);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "enemyBullet" || other.tag == "Enemy")
        {
            Destroy(other.gameObject);
            Time.timeScale = 0;
            GetComponentInParent<Player>().deathEnable();
            GetComponentInParent<Player>().saveScore(currentScore);
        }
    }
}