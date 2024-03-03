using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryCoin3 : MonoBehaviour
{
    public GameObject banana;
    
    public ScoreManager cm;
    public GameObject memory;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       if (collision.gameObject)
        {
           banana.SetActive(true);           
            cm.memoryCount++;
            Destroy(memory);
        }       
    }
}
