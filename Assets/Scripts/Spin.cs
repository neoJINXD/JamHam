using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    public float speed = 50f;
    void Update()
    {
        // sowrd.rotation = sowrd.rotation + Quaternion.Euler(0f, 0f, Time.deltaTime);
        // Qua?ternion.RotateTowards(sowrd.rotation, Quaternion.Euler(0f, 0f, Time.deltaTime), 1f);
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + speed * Time.deltaTime, transform.rotation.eulerAngles.z);
    }
}
