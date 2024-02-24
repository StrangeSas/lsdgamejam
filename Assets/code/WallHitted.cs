using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallHitted : ShootableObject
{
    [SerializeField] GameObject particlesPrefab;
    public override void OnHit(RaycastHit hit)
    {
        GameObject particles = Instantiate(particlesPrefab, hit.point +(hit.normal * 0.05f), Quaternion.LookRotation(hit.normal), transform.root.parent);
        ParticleSystem particleSystem = particles.GetComponent<ParticleSystem>();
        MeshRenderer renderer = GetComponent<MeshRenderer>();
        if (particleSystem && renderer)
        {
            particleSystem.startColor = renderer.material.color;
        }
        Destroy(particles, 2f);
    }
}
