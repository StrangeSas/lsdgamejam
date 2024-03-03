using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class NpcMovement : MonoBehaviour
{

    public GameObject pointA;
    private Rigidbody2D rb;
    private Transform point;
    public float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        point = pointA.transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pointPos = point.position - transform.position;
        if(point == pointA.transform)
        {
            rb.velocity = new Vector2(speed, 0);
        } 
     
        if(Vector2.Distance(transform.position, point.position) < 0.5f && point == pointA.transform)
        {
            speed = 0;
        }
    }
}
