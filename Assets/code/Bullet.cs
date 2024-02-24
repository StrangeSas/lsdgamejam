using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed;
    private float gravity;
    private Vector3 startPosition;
    private Vector3 forwardPosition;
    public float damage = 10f;
    private bool isInitialized = false;
    private float startTime = -1;

    public void Initialize(Transform startPoint, float speed, float gravity)
    {
        startPosition = startPoint.position;
        forwardPosition = startPoint.forward.normalized;
        this.speed = speed;
        this.gravity = gravity;
        isInitialized = true;
    }

    private Vector3 FindPointOnParabola(float time)
    {
        Vector3 point = startPosition + (forwardPosition * speed * time);
        Vector3 gravityVec = Vector3.down * gravity * time * time;
        return point + gravityVec;  
    }

    private bool castRayBetweenPoints(Vector3 startPoint, Vector3 endPoint, out RaycastHit hit)
    {
        return Physics.Raycast(startPoint, endPoint - startPoint, out hit, (endPoint - startPoint).magnitude);
    }

    private void onHit(RaycastHit hit)
    {
        ShootableObject shootableObject = hit.transform.GetComponent<ShootableObject>();
        if (shootableObject)
        {
            shootableObject.OnHit(hit);
        }
        Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        if (!isInitialized) return;
        if(startTime < 0) startTime = Time.time;

        RaycastHit hit;
        float currentTime = Time.time - startTime;
        float prevTime = currentTime - Time.fixedDeltaTime;
        float nextTime = currentTime + Time.fixedDeltaTime;

        Vector3 currentPoint = FindPointOnParabola(currentTime);
        Vector3 nextPoint = FindPointOnParabola(nextTime);

        if (prevTime > 0) 
        {

            Vector3 prevPoint = FindPointOnParabola(prevTime);
            if (castRayBetweenPoints(prevPoint, currentPoint, out hit))
            {
                onHit(hit);
            }
        }


        if (castRayBetweenPoints(currentPoint, nextPoint, out hit))
        {
            try 
            { 
                ShootableObject shootableObject = hit.transform.GetComponent<ShootableObject>();
                if (shootableObject)
                {
                    shootableObject.OnHit(hit);
                }
            } catch(NullReferenceException e)
            {

            }

            try
            {
                Target target = hit.transform.GetComponent<Target>();
                target.Damage(damage);
            }
            catch (NullReferenceException e)
            {

            }


            onHit(hit);
        }
    }

    private void Update()
    {
        if (!isInitialized || startTime < 0) return;

        float currentTime = Time.time - startTime;
        Vector3 currentPoint = FindPointOnParabola(currentTime);
        transform.position = currentPoint;
    }

}
