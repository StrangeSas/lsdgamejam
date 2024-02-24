using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleportBox : MonoBehaviour
{
    [SerializeField] GameObject teleportPoint;
    [SerializeField] walk persona;
    [SerializeField] bool oneWay = false;

    public void Start()
    {
    }

    public void OnTriggerEnter(Collider other)
    {
        persona = other.gameObject.GetComponent<walk>();
        other.gameObject.transform.position = new Vector3(teleportPoint.transform.position.x, other.transform.position.y, teleportPoint.transform.position.z) - new Vector3(0, 0, gameObject.transform.position.z - other.transform.position.z);



        persona.enabled = false;

        other.gameObject.transform.rotation = teleportPoint.transform.rotation;


        persona.enabled = true;

        if (oneWay)
        {
            gameObject.SetActive(false);
        }
    }

}
