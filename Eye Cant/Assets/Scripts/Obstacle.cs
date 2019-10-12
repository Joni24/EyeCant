using System;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public AudioClip bounceSound;
    
    private Rigidbody rigidbody;
    private AudioSource audioSource;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    public void PickUp(Transform t)
    {
        transform.SetParent(t);
        rigidbody.isKinematic = true;
    }
    
    public void Drop()
    {
        transform.SetParent(null);
        rigidbody.isKinematic = false;
    }

    private void OnCollisionEnter(Collision other)
    {
        audioSource.PlayOneShot(bounceSound);
    }
}
