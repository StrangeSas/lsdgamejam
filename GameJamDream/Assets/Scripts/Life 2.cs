using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Life2 : MonoBehaviour
{
    //  public int maxHealth = 100;
    public int currentHealth;
    Vector2 startPos;
    public HealthBar healthBar;
    private Animator anim;
    public bool hasGun;
    public int respawn;
    // Start is called before the first frame update

    private void Awake()
    {

    }

    void Start()
    {
        anim = GetComponent<Animator>();

        startPos = transform.position;

        healthBar.SetMaxHealth(currentHealth);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Spikes")
        {
            TakeDamage(20);
        }

        if (collision.gameObject.tag == "Enemy")
        {
            TakeDamage(20);
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }




    private void Update()
    {
        if (currentHealth < 1)
        {
            Respawn();
        }
    }

    void Respawn()
    {
        //   transform.position = startPos;
        //  currentHealth = 100;

        SceneManager.LoadScene(respawn);


    }
}
