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

    private int AttackHash1;

    void Awake()
    {
        controls = new PlayerInputControls();
    }
    void Start()
    {
        speedForwardHash = Animator.StringToHash("SpeedForward");
        speedSideHash = Animator.StringToHash("SpeedSide");
        speedHash = Animator.StringToHash("Speed");
        AttackHash1 = Animator.StringToHash("Attacking");
    }

    void Update()
    {
        // // TODO should Lerp these for proper blending
        // // TODO Missing the side movement when focussing
        isGoingBack = false;

        if (controls.Player.Attack.ReadValue<float>() > 0f && GameManager.instance.weaponCrank > 0f)
        {

            anim.SetBool(AttackHash1, true);

            GameManager.instance.isAttacking = true;
            
        }
        else 
        {
            if (!GameManager.instance.isAttacking && !GameManager.instance.isRewinding)
            {

                // Forward Movement
                if (controls.Player.Move.ReadValue<Vector2>() != Vector2.zero)
                {
                    // print("suc");
                    // speedForward = Input.GetKey(KeyCode.LeftShift) ? 4f : 0.5f;
                    // speedForward = controls.Player.Sprint.ReadValue<float>() > 0f ? 4f : 0.5f;
                    speedForward = 4f;
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
