using System.Collections.Generic;

using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAnimationController : MonoBehaviour
{
    private PlayerInputControls controls;
    [SerializeField]private Animator anim;
    private float speedForward = 0f;
    private float speedSide = 0f;
    private float speed = 0f;
    private int speedForwardHash;
    private int speedSideHash;
    private int speedHash;
    private bool isGoingBack = false;
    private Vector2 movement;

    // public Queue<int> attackQueue;
    // private int[] AttackHashes;
    private int AttackHash1;
    // private int AttackHash2;
    // private int AttackHash3;

    // List<int> animList;
    // public int attackCounter = 0;
    // public float reset = 0f;
    // public float resetTime = 1f;


    // [SerializeField] float acceleration = 0.1f;
    // [SerializeField] float deceleration = 0.5f;
    void Awake()
    {
        controls = new PlayerInputControls();
    }
    void Start()
    {
        // anim = GetComponent<Animator>();
        speedForwardHash = Animator.StringToHash("SpeedForward");
        speedSideHash = Animator.StringToHash("SpeedSide");
        speedHash = Animator.StringToHash("Speed");

        // AttackHashes = new int[3];
        
        AttackHash1 = Animator.StringToHash("Attacking");
        // AttackHashes[0] = Animator.StringToHash("Attack1");
        // AttackHashes[1] = Animator.StringToHash("Attack2");
        // AttackHashes[2] = Animator.StringToHash("Attack3");
        
        // attackQueue = new Queue<int>();
    }

    void Update()
    {
        // TODO should Lerp these for proper blending
        // TODO Missing the side movement when focussing
        isGoingBack = false;

        if (controls.Player.Attack.ReadValue<float>() > 0f)
        {
            print("pew");
            // anim.SetTrigger(AttackHash1);
            anim.SetBool(AttackHash1, true);
            GameManager.instance.isAttacking = true;
            
        }
        else 
        {

            // Forward Movement
            if (controls.Player.Move.ReadValue<Vector2>() != Vector2.zero)
            {
                // print("suc");
                // speedForward = Input.GetKey(KeyCode.LeftShift) ? 4f : 0.5f;
                speedForward = controls.Player.Sprint.ReadValue<float>() > 0f ? 4f : 0.5f;
                // speed += acceleration * Time.deltaTime;
            }
            // else if (Input.GetKey(KeyCode.S))
            // {
            //     speedForward = -0.5f;
            //     isGoingBack = true;
            //     // speed -= deceleration * Time.deltaTime;
            // }
            else
            {
                speedForward = 0f;
            }
            // speedForward = movement.y;

            // Side Movement
            // if (Input.GetKey(KeyCode.A))
            // {
            //     speedSide = Input.GetKey(KeyCode.LeftShift) && !isGoingBack ? -4f : -0.5f;
            // }
            // else if (Input.GetKey(KeyCode.D))
            // { 
            //     speedSide = Input.GetKey(KeyCode.LeftShift) && !isGoingBack ? 4f : 0.5f;
            // }
            // else
            // {
            //     speedSide = 0f;
            // }
            // speedSide = movement.x;

            // print(movement.magnitude);
            // speed = movement.magnitude;

            // speed = Mathf.Clamp(speed, 0f, 1f);
            anim.SetFloat(speedForwardHash, speedForward);
            // anim.SetFloat(speedSideHash, speedSide);
            // anim.SetFloat(speedHash, speed);

        }
    }

    public void setMovement(Vector2 _movement)
    {
        movement = _movement;
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


}
