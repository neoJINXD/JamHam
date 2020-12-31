using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ragdoller : MonoBehaviour
{
    [SerializeField] Collider coll;
    [SerializeField] float vanishTime = 10f;
    [SerializeField] Enemy enemy;
    Rigidbody[] rigidbodies;
    bool isRagdolled = false;

    private Transform player;
    private Rigidbody rb;

    void Start()
    {
        rigidbodies = GetComponentsInChildren<Rigidbody>();
        ToggleRagdoll(true);
        player = GameObject.FindWithTag("Player").transform;
        rb = GetComponent<Rigidbody>();
        // print(rigidbodies[0].name);
    }


    void OnTriggerEnter(Collider other) 
    {
        if (!isRagdolled && other.CompareTag("Sword"))
        {
            GameManager.instance.Attack();
            ToggleRagdoll(false);
            enemy.Die();
            StartCoroutine(GetBackUp());
            foreach(Rigidbody bone in rigidbodies)
            {
                bone.AddExplosionForce(5f, player.position, 10f, 1f, ForceMode.Impulse);        
            }
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
        // ToggleRagdoll(true);
        Destroy(gameObject);
    }
}
