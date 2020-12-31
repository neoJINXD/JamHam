using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{

    private CharacterController controller;
    private PlayerInputControls controls;
    private Transform cam;
    [SerializeField]private bool isFocusing;
    [SerializeField] private Vector3 playerVelocity;
    [SerializeField] private bool groundedPlayer;
    [SerializeField] private float playerSpeed = 2.0f;
    [SerializeField] private float sprintMultiplier = 2.0f;
    [SerializeField] private float jumpHeight = 1.0f;
    [SerializeField] private float gravityValue = -9.81f;
    [SerializeField] private float rotationSpeed = 4f;
    [SerializeField] InputActionReference movementControl;
    [SerializeField] PlayerAnimationController animationController;

    public float timer = 0f;
    public float crankTimer = 10f;

    void Awake()
    {
        controls = new PlayerInputControls();
    }

    void Start()
    {
        Cursor.visible = false;
        controller = gameObject.GetComponent<CharacterController>();
        cam = Camera.main.transform;
    }

    void Update()
    {
        
        // Ground check
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }


        if (!GameManager.instance.isAttacking)
        {
            // Movement
            Vector2 movement = controls.Player.Move.ReadValue<Vector2>();
            Vector3 move = new Vector3(movement.x, 0, movement.y);
            // if (controls.Player.Sprint.ReadValue<float>() > 0f)
            // {
                move *= sprintMultiplier;
            // }

            move = move.z * cam.forward + move.x * cam.right;
            move.y = 0f; 
            animationController.setMovement(move * playerSpeed);
            controller.Move(move * Time.deltaTime * playerSpeed);

            // Focus
            // // TODO can add a focus on right click to rotate character with the cam
            if (movement != Vector2.zero || controls.Player.Focus.ReadValue<float>() > 0f)
            {
                float targetAngle = Mathf.Atan2(movement.x, movement.y) * Mathf.Rad2Deg + cam.eulerAngles.y;
                Quaternion rotation = Quaternion.Euler(0f, targetAngle, 0f);
                transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);
            }

            if (controls.Player.Sprint.ReadValue<float>() > 0f && timer > crankTimer)
            {
                AudioManager.instance.Play("rewind");
                StartCoroutine(CRANK());
                timer = 0f;
            }

            timer += Time.deltaTime;
        }
        
        // Grravity
        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }

    void OnEnable() 
    {
        // movementControl.action.Enable();
        controls.Enable();
    }
    void OnDisable() 
    {
        // movementControl.action.Disable();
        controls.Disable();
    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Enemy"))
        {
            // TODO should stagger player or something
            print($"GOT HIT {other.name}");    
        }
    }

    IEnumerator CRANK()
    {
        // print("CRANK IT UP");
        GameManager.instance.crankTarget = 0f;
        GameManager.instance.isCranking = true;
        yield return null;
    }

}
