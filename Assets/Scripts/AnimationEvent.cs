using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvent : MonoBehaviour
{
    private PlayerInputControls controls;
    private int AttackHash1;
    private Animator anim;

    void Awake()
    {
        controls = new PlayerInputControls();
    }
    void Start()
    {
        anim = GetComponent<Animator>();
        AttackHash1 = Animator.StringToHash("Attacking");
    }
    public void StopAttack()
    {
        // if (!(controls.Player.Attack.ReadValue<float>() > 0f))
        // {
        // anim.SetBool(AttackHash1, false);
        // GameManager.instance.isAttacking = false;
        // }
    }

    public void StartMovement()
    {
        // if (!(controls.Player.Attack.ReadValue<float>() > 0f))
        // {
        anim.SetBool(AttackHash1, false);
        GameManager.instance.isAttacking = false;
        // }
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

