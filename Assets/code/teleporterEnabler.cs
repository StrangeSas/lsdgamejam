using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleporterEnabler : MonoBehaviour
{
    [SerializeField] GameObject teleport;

    public void OnTriggerEnter(Collider other)
    {
        teleport.SetActive(true);
    }
}
