using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public PlayerInputAction playerInputAction;
    [SerializeField] private float playerSpeed;

    private void Awake() {
        playerInputAction = new PlayerInputAction();
    }

    private void OnEnable() {
        playerInputAction.Enable();
    }

    private void OnDisable() {
        playerInputAction.Disable();   
    }

    private void FixedUpdate() {
        Vector2 inputVector = playerInputAction.Player.Move.ReadValue<Vector2>();
        //Debug.Log("Input: " + inputVector);
        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);
        transform.position += moveDir * playerSpeed * Time.deltaTime;
        Debug.Log(moveDir);
    }
}
