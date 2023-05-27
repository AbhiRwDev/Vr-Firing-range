using UnityEngine;

public class FlyCamera : MonoBehaviour
{
    public float movementSpeed = 10f;  // Speed of camera movement
    public float lookSpeed = 5f;  // Speed of camera rotation
    private bool cursorLocked = true;  // Lock or unlock cursor
   
    void Start()
    {
        // Lock the cursor to the center of the screen
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Move the camera based on keyboard input
        float horizontalMovement = Input.GetAxis("Horizontal") * movementSpeed;
        float forwardMovement = Input.GetAxis("Vertical") * movementSpeed;
        float upMovement = Input.GetAxis("Jump") * movementSpeed;
        transform.Translate(new Vector3(horizontalMovement, upMovement, forwardMovement) * Time.deltaTime);

        // Rotate the camera based on mouse movement
        float horizontalRotation = Input.GetAxis("Mouse X") * lookSpeed;
        float verticalRotation = Input.GetAxis("Mouse Y") * lookSpeed;
        transform.Rotate(new Vector3(-verticalRotation, horizontalRotation, 0), Space.Self);

        // Prevent camera from rotating around Z axis
        Vector3 eulerRotation = transform.eulerAngles;
        eulerRotation.z = 0;
        transform.eulerAngles = eulerRotation;

        // Unlock or lock the cursor based on Escape key
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            cursorLocked = !cursorLocked;
            Cursor.lockState = cursorLocked ? CursorLockMode.Locked : CursorLockMode.None;
            Cursor.visible = !cursorLocked;
        }
       
    }
}
