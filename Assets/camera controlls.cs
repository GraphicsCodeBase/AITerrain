using UnityEngine;

public class cameracontrolls : MonoBehaviour
{
    public float moveSpeed = 20f;
    public float mouseSensitivity = 100f;
    public float scrollSpeed = 200f;

    float rotationX = 0f;
    float rotationY = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Position the camera
        transform.position = new Vector3(0, 100, -100);

        // Rotate the camera to look down at the terrain
        transform.rotation = Quaternion.Euler(45f, 0f, 0f);

        Cursor.lockState = CursorLockMode.Locked; // Lock cursor to screen center
    }

    // Update is called once per frame
    void Update()
    {
        // Mouse look
        rotationX -= Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        rotationY += Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f); // Limit vertical look

        transform.rotation = Quaternion.Euler(rotationX, rotationY, 0f);

        // Movement (WASD)
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        transform.Translate(move * moveSpeed * Time.deltaTime, Space.Self);

        // Zoom (Scroll wheel)
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        transform.Translate(Vector3.forward * scroll * scrollSpeed * Time.deltaTime, Space.Self);

        // Unlock cursor (Escape)
        if (Input.GetKeyDown(KeyCode.Escape))
            Cursor.lockState = CursorLockMode.None;
    }
}
