using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController controller = null;
    [SerializeField] private Transform cameraTransform = null;
    [SerializeField] private float movementSpeed = 100;
    [SerializeField] private float cameraRotationSpeed = 100;
    
    
    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        LookAround();
        Move();
    }

    private void Move()
    {
        var input = Vector3.zero;

        input.x = Input.GetAxis("Horizontal");
        input.z = Input.GetAxis("Vertical");

        input = transform.TransformDirection(input);

        controller.Move(input * Time.deltaTime * movementSpeed);
    }

    private void LookAround()
    {
        var vertical = Input.GetAxis("Mouse X") * Time.deltaTime * cameraRotationSpeed;
        var horizontal = Input.GetAxis("Mouse Y") * Time.deltaTime * cameraRotationSpeed;

        transform.Rotate(0, vertical, 0);
        cameraTransform.Rotate(-horizontal, 0, 0);
    }
}
