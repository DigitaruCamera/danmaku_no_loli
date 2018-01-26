using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public float delay_bomb = 5f;
    public float delay_bullet = 0.5f;
    public float nb_bullet = 3f;
    public float angle_bullet = 15f;
    float delayed_bomb = 0;
    float delayed_bullet = 0;
    public Text UI_point;

    public void Update()
    {
        if ((Input.touchCount >= 2 || Input.GetButtonDown("Fire2")) && delayed_bomb < Time.time)
        {
            delayed_bomb = Time.time + delay_bomb;
            GetComponent<actionPhysics>().useBomb();
        }
        if (delayed_bullet < Time.time)
        {
            delayed_bullet = Time.time + delay_bullet;
            GetComponent<actionPhysics>().shotBullet(nb_bullet, angle_bullet);
        }
        GetComponentInParent<Player>().BombBar(delayed_bomb, delay_bomb);
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.tag == "enemyBullet")
        {
            ParticleSystem particleSystem = other.GetComponent<ParticleSystem>();
            ParticleSystem.Particle[] particles = new ParticleSystem.Particle[particleSystem.particleCount];
            ParticleSystem.Particle closeParticle = particles[0];
            float closeRange = Vector3.Distance(particles[0].position, transform.position);
            particleSystem.GetParticles(particles);
            foreach (ParticleSystem.Particle currentParticle in particles)
            {
                float range = Vector3.Distance(currentParticle.position, transform.position);
                if (range < closeRange)
                {
                    closeRange = range;
                    closeParticle = currentParticle;
                }
            }
            closeParticle.remainingLifetime = 0;
            GetComponentInParent<Player>().deathEnable();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemyBullet" || collision.gameObject.tag == "enemy")
        {
            Destroy(collision.gameObject);
            Time.timeScale = 0;
            GetComponentInParent<Player>().deathEnable();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "enemyBullet" || other.tag == "enemy")
        {
            Destroy(other.gameObject);
            Time.timeScale = 0;
            GetComponentInParent<Player>().deathEnable();
        }
    }
}