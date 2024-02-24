using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRagdolling : MonoBehaviour
{
    private Rigidbody[] rigids;
    private Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        rigids = GetComponentsInChildren<Rigidbody>();
        anim = GetComponent<Animator>();
        DisableRagdoll();
    }

    public void EnableRagdoll()
    {
        foreach(Rigidbody rig in rigids)
        {
            anim.enabled = false;
            rig.useGravity = true;
        }
    }
    public bool AmIAlive()
    {
        if (anim.enabled == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void DisableRagdoll()
    {
        foreach (Rigidbody rig in rigids)
        {
            rig.useGravity = false;
        }
    }
}
