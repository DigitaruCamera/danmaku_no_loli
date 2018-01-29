using UnityEngine;
using System.Collections;

public class PlayerBomb : MonoBehaviour
{

    private void OnParticleCollision(GameObject other)
    {
        if (other.tag == "enemyBullet")
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
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemyBullet" || collision.gameObject.tag == "enemy")
        {
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "enemyBullet" || other.tag == "enemy")
        {
            Destroy(other.gameObject);
        }
    }
}
