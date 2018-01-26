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
        }
    }
}
