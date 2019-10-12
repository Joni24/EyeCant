using UnityEngine;
using UnityEngine.UIElements;


public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController controller = null;
    [SerializeField] private Transform cameraTransform = null;
    [SerializeField] private float movementSpeed = 100;
    [SerializeField] private float cameraRotationSpeed = 100;
    [SerializeField] private Camera camera;
    [SerializeField] private Transform carryPosition;

    private const string OBSTACLE_TAG = "Obstacle";
    private Obstacle obstacle;

    // Update is called once per frame
    private void Update()
    {
        LookAround();
        Move();
        PickUp();
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

    private void PickUp()
    {
        if (Input.GetMouseButtonDown((int) MouseButton.LeftMouse)) {
            RaycastHit hit;
            var ray = camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 10f)) {
                Debug.DrawRay(ray.origin, ray.direction, Color.red, 1f);

                if (hit.collider.tag.Equals(OBSTACLE_TAG)) {
                    obstacle = hit.collider.GetComponent<Obstacle>();
                    obstacle.PickUp(this.transform);
                    obstacle.transform.position = carryPosition.position;
                }
            }
        }
        else if (Input.GetMouseButtonUp((int) MouseButton.LeftMouse)) {
            if (obstacle != null) {
                obstacle.Drop();
            }
        }
    }
}
