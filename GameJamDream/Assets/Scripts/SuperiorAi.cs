using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperiorAi : MonoBehaviour, Damage
{
    [SerializeField] float maxHealth = 3f;
    float currentHealth;
    const string LEFT = "left";
    const string RIGHT = "right";
   
   [SerializeField] Transform castPos;
    Rigidbody2D rb;
   [SerializeField] float moveSpeed;

   [SerializeField] float baseCastDist;

    string facingDirection;

    Vector3 baseScale;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        baseScale = transform.localScale;
        facingDirection = RIGHT;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        float vX = moveSpeed;

        if (facingDirection == LEFT)
        {
            vX = -moveSpeed;
        }
        //move the game object   
        rb.velocity = new Vector2(vX, rb.velocity.y);

        if (IsHittingWall())
        {
            if(facingDirection == LEFT)
            {
                ChangeFacingDirection(RIGHT);
            }
            else if(facingDirection == RIGHT)
            {
                ChangeFacingDirection(LEFT);
            }
        }
    }

    void ChangeFacingDirection(string newDirection)
    {
        Vector3 newScale = baseScale;

        if (newDirection == LEFT)
        {
            newScale.x = -baseScale.x;
        }
        else if (newDirection == RIGHT) { }
        {
            newScale.x = baseScale.x;
        }

        transform.localScale = newScale;

        facingDirection = newDirection;

    }

    bool IsHittingWall()
    {
        bool val = false;

        float castDist = baseCastDist;
        // define cast distance

        if (facingDirection == LEFT) 
        {
            castDist = -baseCastDist;
        }
        else
        {
            castDist = baseCastDist;        
        }
        // determine target destination based on the cast distance
        Vector3 targetPos = castPos.position;
        targetPos.x += castDist;


        Debug.DrawLine(castPos.position, targetPos, Color.red);

        if(Physics2D.Linecast(castPos.position, targetPos, 1 << LayerMask.NameToLayer("Blocks")))
        {
            val = true;
        }       
        else
        {
            val = false;
        }
        return val;

    }

    public void Damage(float damageAmount)
    {
        currentHealth -= damageAmount;
        
        if (currentHealth < 0)
        {
            Destroy(gameObject);
        }
    }
    
}
