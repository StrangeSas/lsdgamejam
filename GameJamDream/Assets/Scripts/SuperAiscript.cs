using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperAiscript : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float moveSpeed;
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;
    private Vector2 currentPoint;
    private float different = 0.5f;
    private Vector2 startPosition;
    float distance;
    private float startTime;
    
    // Start is called before the first frame update
    void Start()
    {
       
        rb = GetComponent<Rigidbody2D>();
        
        distance = Vector2.Distance(leftEdge.position, rightEdge.position);

      
        
    }

    // Update is called once per frame
    void Update()
    {
    
        
        float distance = (Time.time - startTime) * Time.deltaTime;
        Vector2 targetposition = leftEdge.position * different;

          if (currentPoint.x == leftEdge.position.x)
           {
              transform.position = Vector2.Lerp(transform.position, rightEdge.position, distance);    
          }

        if (currentPoint.x == rightEdge.position.x)
        {
            transform.position = Vector2.Lerp(transform.position, leftEdge.position, distance);
        }
        if (currentPoint.x != leftEdge.position.x)
        {
            transform.position = Vector2.Lerp(transform.position, targetposition, distance);
        }



    }
    
}
