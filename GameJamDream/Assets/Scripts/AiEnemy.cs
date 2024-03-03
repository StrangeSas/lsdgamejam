using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class AiEnemy : MonoBehaviour
{
    [Header ("Patrol Points")]

    [SerializeField] private GameObject leftEdge;
    [SerializeField] private GameObject rightEdge;

    [SerializeField] private Transform leftEdge2;
    [SerializeField] private Transform rightEdge2;
    
    [SerializeField] private Transform leftEdge3;
    [SerializeField] private Transform rightEdge3;

    [SerializeField] private Transform leftEdge4;
    [SerializeField] private Transform rightEdge4;

    [SerializeField] private Transform leftEdge5;
    [SerializeField] private Transform rightEdge5;

    [SerializeField] private Transform leftEdge6;
    [SerializeField] private Transform rightEdge6;

    [Header("Enemy")]
    [SerializeField] private Transform enemy;
    [Header("Enemy")]
    [SerializeField] private Transform enemy2;
    [Header("Enemy")]
    [SerializeField] private Transform enemy3;
    [Header("Enemy")]
    [SerializeField] private Transform enemy4;
    [Header("Enemy")]
    [SerializeField] private Transform enemy5;
    [Header("Enemy")]
    [SerializeField] private Transform enemy6;

    private Vector3 position;
    public float speed;


    private Transform currentPoint;
    private Rigidbody2D rb;

    private void Start()
    {
        currentPoint = leftEdge.transform;
        

        rb = GetComponent<Rigidbody2D>();
        
     //   position = gameObject.transform.position;
     //   if (Vector3.Distance(transform.position.enemy) = leftEdge)
     //   {
     //       enemy.transform.position = rightEdge.transform.position;
     //   }
      //  else if (enemy.position == rightEdge.position)
     //   {
     //       enemy.transform.position = leftEdge.transform.position;
     //   }
      //  else
      //  {
       //     enemy.transform.position = leftEdge.position;
       // }
    }

    private void Update()
    {
        //   Vector2 targetPosition = new Vector2(currentPoint.position.x, transform.position.y);
        //  Vector3 targetPosition2 = new Vector2(currentPoint.position.x, transform.position.y);
        //   float distanceThreshold = 2f;

        //    if(currentPoint == leftEdge.transform)
        //   {

        //   }
        if (currentPoint == leftEdge.transform)
       {
            rb.velocity = new Vector2(speed, 0);
       }

      //  else if (currentPoint != rightEdge.transform)
     //   {
     //       rb.velocity = new Vector2(-speed, 0);
      //  }
      else
        {
           rb.velocity = new Vector2(-speed, 0);
        }

       if (Vector2.Distance(transform.position,currentPoint.position) < 0.5f && currentPoint == leftEdge.transform)
        {
            currentPoint = rightEdge.transform;
        }
       if (Vector2.Distance(transform.position,currentPoint.position) < 0.5f && currentPoint == rightEdge.transform)
        {
            currentPoint = leftEdge.transform;
        }
    }


}
