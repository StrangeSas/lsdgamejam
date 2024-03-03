using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestOpen : MonoBehaviour
{

    public GameObject chest;
    public GameObject chestIsOpen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        chest.SetActive(false);
        if(collision.tag == "Player")
        {
            chestIsOpen.SetActive(true);
            collision.GetComponent<HeroOpenChest>().OpenedChest();
        }

    }


}
