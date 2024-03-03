using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroOpenChest : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite heroPistol;
    public Animator anim;
    public bool chestOpened;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Chest")
        {
            spriteRenderer.sprite = heroPistol;
        }
        if (other.tag == "Chest")
        {
            anim.SetBool("running", false);
            anim.SetBool("hasGun", true);
           
        }


    }

    public void OpenedChest()
    {
        chestOpened = true;
        GetComponent<Shooting>().enabled = true;
    }
}
