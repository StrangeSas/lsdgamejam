using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberGenerator : MonoBehaviour, IInteractable
{
    [SerializeField] AudioSource yeah;
    [SerializeField] Animator _animator;
    
    void Start()
    {
        _animator = gameObject.GetComponent<Animator>();
    }
    public void Interact()
    {
        if (gameObject.name == "PortalDoor (1)")
        {
            gameObject.GetComponent<BoxCollider>().enabled = false;

            _animator.Play("Door");
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    public void Yeah()
    {

        AudioSource currentStuff = Instantiate(yeah, gameObject.transform.position, Quaternion.identity);

        Destroy(currentStuff, 4f);
        Destroy(currentStuff.gameObject, 4f);
    }
    public void Yeah2()
    {

        AudioSource currentStuff = Instantiate(yeah, gameObject.transform.position, Quaternion.identity);
        currentStuff.volume = 0.2f;
        Destroy(currentStuff, 4f);
        Destroy(currentStuff.gameObject, 4f);
    }
}
