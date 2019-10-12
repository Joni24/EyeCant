using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private GameObject questions = null;
    
    private void OnTriggerEnter(Collider other)
    {
        questions.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        questions.SetActive(false);
    }
}
