using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDir;
    Rigidbody rb;

    private void Start() {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }
    private void Update() {
        MovementInputs();
    }
    private void FixedUpdate() {
        PlayerMove();
    }

    public void MovementInputs() {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    public void PlayerMove() {
        moveDir = orientation.forward * verticalInput + orientation.right * horizontalInput;
        rb.AddForce(moveDir.normalized * moveSpeed * 10f, ForceMode.Force);
    }
}
