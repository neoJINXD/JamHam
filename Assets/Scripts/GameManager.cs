using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public bool isAttacking { get; set; }

    public GameObject coil;
    public GameObject player;
   
    [SerializeField] int health;

    public float weaponCrank = 100f;
    public float crankTarget = 0f;
    public bool isCranking = false;
    [SerializeField] Material swordGlowMat;

    [SerializeField] Animator swordAnimator;
    // [SerializeField]Color glowColor;
    // [SerializeField]Color nonGlowColor;

    public int currentWave = 1;
    public int coilHealth = 10;

    void Awake()
    {
        base.Awake();
        coil = GameObject.FindWithTag("Target");
        player = GameObject.FindWithTag("Player");
        
        // glowColor = swordGlowMat.GetColor("Color_");
        
    }

    void Update()
    {
        print($"WE ARE {currentWave+1}");

        if (coilHealth == 0)
        {
            // TODO fade out
            SceneManager.LoadScene(3);
        }

        // is cranking up
        if (isCranking)
        {
            // print($"{weaponCrank} Goinf up {crankTarget}");
            crankTarget += Time.deltaTime;
            weaponCrank = Mathf.Lerp(0f, 100f, crankTarget);
            // weaponCrank
            if (crankTarget >= 1f)
                isCranking = false;
        }



        swordGlowMat.SetFloat("Intensity_", Map(weaponCrank, 0f, 100f, 0f, 35f));
        // if (weaponCrank < 1)
        // {
        //     // No charge, no more emission
        //     swordGlowMat.SetFloat("Intensity_", 0f);
        // }
        // else
        // {
        //     // Has charge, emission :pepeScheme:
        //     swordGlowMat.SetFloat("Intensity_", 35f);
        // }

        weaponCrank = Mathf.Clamp(weaponCrank, 0f, 100f);

        if (weaponCrank > 20f)
        {
            swordAnimator.StopPlayback();
        } 
        else
        {
            swordAnimator.StartPlayback();
        }
    }

    public void Attack()
    {
        weaponCrank -= 10f;
    }


    public float Map(float input, float start, float end, float newStart, float newEnd)
    {
        float output = newStart + ((newEnd - newStart) / (end - start)) * (input - start);
        return output;
    }

}
