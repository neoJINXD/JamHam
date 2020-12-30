using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTest : MonoBehaviour
{
    
    public string name;
    void OnTriggerEnter(Collider other) 
    {
        print($"zooweemama from {name} just got hit by {other.name}");
    }
    void OnCollisionEnter(Collision other)
    {    
        print($"zooweemama from {name} just got hit by {other.collider.name}");
    }
    
    
}
