using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coil : MonoBehaviour
{
    void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Enemy"))
        {
            print($"COIL HIT {other.name}");    
            GameManager.instance.coilHealth--;
        }  
    }
}
