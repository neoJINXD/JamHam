using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ragdoller : MonoBehaviour
{
    [SerializeField] Collider coll;
    [SerializeField] float vanishTime = 10f;
    Rigidbody[] rigidbodies;
    bool isRagdolled = false;

    void Start()
    {
        rigidbodies = GetComponentsInChildren<Rigidbody>();
        ToggleRagdoll(true);
    }


    void OnTriggerEnter(Collider other) 
    {
        if (!isRagdolled && other.CompareTag("Player"))
        {
            ToggleRagdoll(false);
            StartCoroutine(GetBackUp());
        }
    }

    private void ToggleRagdoll(bool isAnimated)
    {
        isRagdolled = !isAnimated;

        coll.enabled = isAnimated;
        foreach(Rigidbody bone in rigidbodies)
        {
            bone.isKinematic = isAnimated;
        }
        GetComponent<Animator>().enabled = isAnimated;
    }

    IEnumerator GetBackUp()
    {
        yield return new WaitForSeconds(vanishTime);
        ToggleRagdoll(true);
    }
}
