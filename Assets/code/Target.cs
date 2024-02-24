using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour, IDamagable
{
    [SerializeField] float health = 100f;
    [SerializeField] GameObject me;
    Interaction interaction;
    walk walky;
    ShootOutput shoot;
    Animator _animator;
    Rigidbody rb;
    public void Start()
    {
        me = GameObject.Find("SoldierPlayer");
        rb = me.GetComponent<Rigidbody>();
        interaction = me.gameObject.GetComponent<Interaction>();
        walky = me.gameObject.GetComponent<walk>();
        shoot = me.gameObject.GetComponent<ShootOutput>();
        _animator = me.gameObject.GetComponent<Animator>();
    }
    public void Damage(float damage)
    {
        Debug.Log("Direct hit");
        health -= damage;
        if (health <= 0)
        {
            IMDead();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Direct hit, i guees");
    }

    private void IMDead()
    {
        
        ChangeAnimationState("dead");
        Destroy(rb);
        rb.useGravity = false;
        interaction.enabled = false;
        shoot.enabled = false;
        walky.enabled = false;
    }
    public void ChangeAnimationState(string newState)
    {
        _animator.Play(newState);
    }
}
