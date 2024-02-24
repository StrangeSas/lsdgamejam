using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class StuffHitted : ShootableObject
{
    [SerializeField] GameObject particlesPrefab;
    [SerializeField] EnemyRagdolling enemyRagdolling;
    [SerializeField] GameObject gameObject;
    public override void OnHit(RaycastHit hit)
    {
        GameObject particles = Instantiate(particlesPrefab, hit.point +(hit.normal * 0.05f), Quaternion.LookRotation(hit.normal), transform.root.parent);
        ParticleSystem particleSystem = particles.GetComponent<ParticleSystem>();
        MeshRenderer renderer = GetComponent<MeshRenderer>();
        if (particleSystem && renderer)
        {
            particleSystem.startColor = renderer.material.color;
        }
        try
        {
            enemyRagdolling.EnableRagdoll();
            Destroy(particles, 2f);
            Destroy(gameObject, 5f);
        }
        catch (NullReferenceException e)
        {
            Destroy(particles, 2f);
        }
    }
}
