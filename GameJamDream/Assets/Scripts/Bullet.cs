using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    [SerializeField] float destroyTime = 1f;
    [SerializeField] LayerMask whatDestroyBullet;
    [SerializeField] float bulletDamage = 1f;
    


    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
        DestroyTime();
    }

   private void OnTriggerEnter2D(Collider2D other)
    {
        
      
        if((whatDestroyBullet.value & (1 << other.gameObject.layer)) > 0)
        {


            Damage damage = other.gameObject.GetComponent<Damage>();
            if(damage != null)
            {
                damage.Damage(bulletDamage);
                Debug.Log("Hit");
            }

            Destroy(gameObject);
        }
    }
  
    private void DestroyTime()
    {
        Destroy (gameObject, destroyTime);
    }
}
