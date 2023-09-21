using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puas : MonoBehaviour
{
    private ParticleSystem particleSystem;
    public float alturaMinima = 0f; // Altura mínima en el eje Y para eliminar las partículas

    private void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        ParticleSystem.Particle[] particles = new ParticleSystem.Particle[particleSystem.particleCount];
        int numParticlesAlive = particleSystem.GetParticles(particles);

        for (int i = 0; i < numParticlesAlive; i++)
        {
            if (particles[i].position.z < -7)
            {
                particles[i].remainingLifetime = -1f; // Establece la vida útil en un valor negativo para eliminar la partícula
            }
        }

        particleSystem.SetParticles(particles, numParticlesAlive);
    }
    
}
