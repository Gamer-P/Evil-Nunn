using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    public float senX;
    public float senY;

    public Transform orientation;

    float xRotation;
    float yRotation;

    private void Start() {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void Update() {
        float mouseX = Input.GetAxisRaw("Mouse X") * senX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * senY;

        yRotation += mouseX;
        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0f);
        orientation.rotation = Quaternion.Euler(0f, yRotation, 0f);

        Debug.Log(xRotation + " " + yRotation);
    }
}
