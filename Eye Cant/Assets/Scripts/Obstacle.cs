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
        rigidbody.useGravity = false;
    }
    
    public void Drop()
    {
        transform.SetParent(null);
        rigidbody.useGravity = true;
    }

    private void OnCollisionEnter(Collision other)
    {
        audioSource.PlayOneShot(bounceSound);
    }
}
