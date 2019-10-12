using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private GameObject questions = null;
    [SerializeField] private Animation animation = null;

    private bool _isDown = false;
    
    private void OnTriggerEnter(Collider other)
    {
        if (!_isDown && !other.tag.Equals(PlayerMovement.OBSTACLE_TAG))
        {
            //questions.SetActive(true);
            animation.Play("MoveDown");
            _isDown = true;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        //questions.SetActive(false);
    }
}
