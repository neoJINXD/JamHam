using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthUpdated : MonoBehaviour
{
    public TMP_Text healthNumber;

    // Update is called once per frame
    void Update()
    {
        healthNumber.text = $"Coil Health: {GameManager.instance.coilHealth}";

    }
}
