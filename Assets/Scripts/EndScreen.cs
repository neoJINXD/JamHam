using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreen : MonoBehaviour
{
    private float timer = 0f;
    public Material endScreenSwordMat;
    void Update()
    {
        timer += Time.deltaTime;

        endScreenSwordMat.SetFloat("Intensity_", GameManager.instance.Map(Mathf.Sin(timer), -1f, 1f, 0f, 35f));
        
    }
}
