using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private Rigidbody rigidbody;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
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
}
