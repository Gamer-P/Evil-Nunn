using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public PlayerInputAction playerInputAction;
    [SerializeField] private float playerSpeed;


    private void FixedUpdate() {
        Vector2 inputVector = new Vector2(0f, 0f);
        if (Input.GetKey(KeyCode.W)) {
            inputVector.x += 1f;
        }
        if (Input.GetKey(KeyCode.S)) {
            inputVector.x -= 1f;
        }
        if (Input.GetKey(KeyCode.D)) {
            inputVector.y += 1f;
        }
        if (Input.GetKey(KeyCode.A)) {
            inputVector.y -= 1f;
        }

        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);
        transform.position = inputVector * playerSpeed * Time.deltaTime; 
    }
}
