using Unity.VisualScripting;
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


    private bool isCrouching;

    private void Start() {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }
    
    //Update MovementInput() function every frame
    private void Update() {
        MovementInputs();
        CrouchInputs();
    }

    //PlayerMove() Update -> PlayerMovement Logic
    private void FixedUpdate() {
        PlayerMove();
    }

    //Input of player movement
    public void MovementInputs() {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    //Logic/Physics that move player
    public void PlayerMove() {
        moveDir = orientation.forward * verticalInput + orientation.right * horizontalInput;
        rb.AddForce(moveDir.normalized * moveSpeed * 10f, ForceMode.Force);
    }


    //Crouching Inputs
    public void CrouchInputs() {
        if (Input.GetKeyDown(KeyCode.LeftControl)) {
            PlayerCrouchState(true);

        } else if (Input.GetKeyUp(KeyCode.LeftControl)) {
            PlayerCrouchState(false);
        }
    }

    // Player_Crouch_State changing -> player height, camera height(orientation changing)
    // Crouch Logic
    public void PlayerCrouchState(bool crouch) {
        isCrouching = crouch;

        Transform currentPosition = orientation;
        if (isCrouching) {
            float newHeight = orientation.position.y / 2f;
            orientation.position = new Vector3(orientation.position.x, orientation.position.y, newHeight);
            Debug.Log("Position Crouch: " + orientation.position);

        } else if (!isCrouching && !crouch) {
            orientation.position = currentPosition.position;
            Debug.Log("Position NotCrouch: " + orientation.position);
        }

        
    }

}
