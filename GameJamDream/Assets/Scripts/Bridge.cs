using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{
   public GameObject bridge;

    private void Start()
    {
        bridge.SetActive(false);
    }

}
