using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public bool isAttacking { get; set; }

    public GameObject coil;
    public GameObject player;
   
    void Awake()
    {
        base.Awake();
        coil = GameObject.FindWithTag("Target");
        player = GameObject.FindWithTag("Player");
    }

}
