using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    // private Animator anim;
    // private float speedForward = 0f;
    // private float speedSide = 0f;
    // private int speedForwardHash;
    // private int speedSideHash;
    // private bool isGoingBack = false;

    // [SerializeField] float acceleration = 0.1f;
    // [SerializeField] float deceleration = 0.5f;
    void Start()
    {
        // anim = GetComponent<Animator>();
        // speedForwardHash = Animator.StringToHash("SpeedForward");
        // speedSideHash = Animator.StringToHash("SpeedSide");
    }

    void Update()
    {
        // TODO can prob be optimized
        // TODO should Lerp these for proper blending
        // TODO use the input system
        // isGoingBack = false;
        // if (Input.GetKey(KeyCode.W))
        // {
        //     print("suc");
        //     speedForward = Input.GetKey(KeyCode.LeftShift) ? 4f : 0.5f;
        //     // speed += acceleration * Time.deltaTime;
        // }
        // else if (Input.GetKey(KeyCode.S))
        // {
        //     speedForward = -0.5f;
        //     isGoingBack = true;
        //     // speed -= deceleration * Time.deltaTime;
        // }
        // else
        // {
        //     speedForward = 0f;
        // }

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

        // // speed = Mathf.Clamp(speed, 0f, 1f);
        // anim.SetFloat(speedForwardHash, speedForward);
        // anim.SetFloat(speedSideHash, speedSide);
    }
}

