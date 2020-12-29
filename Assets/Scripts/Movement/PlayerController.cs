using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{

    private CharacterController controller;
    private Transform cam;
    [SerializeField] private Vector3 playerVelocity;
    [SerializeField] private bool groundedPlayer;
    [SerializeField] private float playerSpeed = 2.0f;
    [SerializeField] private float jumpHeight = 1.0f;
    [SerializeField] private float gravityValue = -9.81f;
    [SerializeField] private float rotationSpeed = 4f;
    [SerializeField] InputActionReference movementControl;

    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        cam = Camera.main.transform;
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector2 movement = movementControl.action.ReadValue<Vector2>();
        print(movement);
        Vector3 move = new Vector3(movement.x, 0, movement.y);

        move = move.z * cam.forward + move.x * cam.right;
        move.y = 0f; 
        controller.Move(move * Time.deltaTime * playerSpeed);

        // if (move != Vector3.zero)
        // {
        //     gameObject.transform.forward = move;
        // }

        // Changes the height position of the player..
        // if (Input.GetButtonDown("Jump") && groundedPlayer)
        // {
        //     playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        // }

        //Grravity
        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        // TODO can add a focus on right click to rotate character with the cam
        if (movement != Vector2.zero)
        {
            float targetAngle = Mathf.Atan2(movement.x, movement.y) * Mathf.Rad2Deg + cam.eulerAngles.y;
            Quaternion rotation = Quaternion.Euler(0f, targetAngle, 0f);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);
        }
    }

    void OnEnable() 
    {
        movementControl.action.Enable();
    }
    void OnDisable() 
    {
        movementControl.action.Disable();
    }
    
}
