using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public GameObject Wall;
    public GameObject Wall1;
    public GameObject Wall2;
    public GameObject Wall3;
    public GameObject Wall4;
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
        Destroy(Wall);
        Destroy(Wall1);
        Destroy(Wall2);
        Destroy(Wall3);
        Destroy(Wall4);
    }
}
