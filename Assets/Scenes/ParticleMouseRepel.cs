using UnityEngine;

public class ParticleMouseRepel : MonoBehaviour
{
    public float repelRadius = 2f;
    public float repelStrength = 3f;

    ParticleSystem ps;
    ParticleSystem.Particle[] particles;
    Camera mainCam;

    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        particles = new ParticleSystem.Particle[ps.main.maxParticles];
        mainCam = Camera.main;
    }

    void Update()
    {
        int count = ps.GetParticles(particles);

        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Mathf.Abs(mainCam.transform.position.z - transform.position.z);
        Vector3 worldMouse = mainCam.ScreenToWorldPoint(mousePos);

        for (int i = 0; i < count; i++)
        {
            float dist = Vector3.Distance(worldMouse, particles[i].position);
            if (dist < repelRadius)
            {
                Vector3 dir = (particles[i].position - worldMouse).normalized;
                particles[i].velocity += dir * repelStrength;
            }
        }

        ps.SetParticles(particles, count);
    }
}
